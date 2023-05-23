using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWallTrigger : MonoBehaviour
{
    //public GameObject[] spikes = new GameObject[2];

    Timer timer;
    public bool isTriggered;

    private void Awake()
    {
        isTriggered = false;
    }

    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && isTriggered == false)
        {
            isTriggered = true;

            GameObject fallingWall = GameObject.Find("FallingWall");
            if (fallingWall == null)
            {
                fallingWall = GameObject.Find("FallingWall(Clone)");
            }
            fallingWall.GetComponent<FallingWall>().RotateWall();
        }
        
    }


}
