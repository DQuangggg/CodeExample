using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRock : MonoBehaviour
{
    [SerializeField]
    public float thrust;


    AudioSource audioSource;
    //for recreate rock
    private GameObject RunningRockPrefab;
    private Vector3 rockPosition;

    void Start()
    {
        rockPosition = transform.position;
        RunningRockPrefab = (GameObject)Resources.Load(@"Prefabs\RunningRock");
        audioSource = gameObject.GetComponent<AudioSource>(); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //When kill mainCharacter -> Destroy & Recreate the Rock
        if (collision.gameObject.tag == "Player")
        {
            audioSource.Stop();
            recreateObject();
            Instantiate(RunningRockPrefab, rockPosition, Quaternion.identity.normalized);
        } else if(collision.gameObject.tag == "Breakable")
        {
            audioSource.Stop();
        }
    }

    public void Roll()
    {
        audioSource.Play();
        Rigidbody2D rd2d = gameObject.GetComponent<Rigidbody2D>();
        rd2d.AddForce(transform.right * thrust);
        rd2d.AddForce(transform.right * thrust, ForceMode2D.Impulse);
    }

    private void recreateObject()
    {
        Destroy(this.gameObject);

        //Reset value in RunningRockTrigger
        //GameObject rockTrigger = GameObject.Find("RunningRock_Trap/RockTrigger");
        //RunningRockTrigger rockTriggerScript = rockTrigger.GetComponent<RunningRockTrigger>();
        //rockTriggerScript.isTriggered = false;
    }
}
