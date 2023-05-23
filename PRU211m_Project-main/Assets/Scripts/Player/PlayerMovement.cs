using System.Collections;
using UnityEngine;

//Movement & actions of MainCharacter
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public CharacterController2D controller;
    [SerializeField]
    public float runSpeed = 30f;
    [SerializeField]
    public Animator animator;
    [SerializeField]
    public HeartManager heartManager;
    float horizontalMove = 0f;
    bool isJumping = false;

    public AudioSource audioSource;
    [Header("SoundFX")]
    [SerializeField]
    public AudioClip jumpClip;
    [SerializeField]
    public AudioClip deathClip;
    // check if player have control of main character
    bool hasControl = true;
    bool isDying = false;
    Timer timer;

    //the checkpoint at which the Character will respawn
    public Vector3 checkPointPassed;

    // Start is called before the first frame update
    void Start()
    {
        //init heart manager
        heartManager = gameObject.GetComponent<HeartManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
       // timer = gameObject.AddComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasControl)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                audioSource.PlayOneShot(jumpClip);
                animator.SetBool("isJumping", true);
            }
            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
                animator.SetBool("isJumping", false);
            }
        }        
    }

    void FixedUpdate()
    {
        if (hasControl)
        {
            controller.Move(horizontalMove * Time.deltaTime, isJumping);
            isJumping = false;
        }
        
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if touch a Hazard -> die
        if (collision.gameObject.tag == "Hazard" && !isDying)
        {
            
            animator.SetBool("dead", true);
            audioSource.PlayOneShot(deathClip);
            StartCoroutine(waiter());
        }
    }

    //Use for Delay in Death animation
    IEnumerator waiter()
    {
        isDying = true;
        // disable player control
        hasControl = false;

        //stop all movement on main character
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        yield return new WaitForSeconds(0.75f);
        animator.SetBool("dead", false);
        if (heartManager.health > 0)
        {
            //respawn in checkpoint if still have HP
            CheckpointRespawn();
        } else
        {
            //go to Game Over Scene
            SceneSwitcher.goToGameOverScene();
        }
        isDying = false;
        hasControl = true;
    }

    //respawn mainCharacter at checkPoint (when still have hearts left)
    void CheckpointRespawn()
    {
        //respawn
        transform.position = new Vector3(checkPointPassed.x, checkPointPassed.y, 0);
        //minus HP
        heartManager.MinusHeart();
    }
}
