using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningRockTrigger : MonoBehaviour
{
    AudioSource audioSource;
    //only trigger once
    public bool isTriggered = false;
    //Trigger to make rock roll when player pass here
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isTriggered)
        {
            if (collision.gameObject.tag == "Player")
            {
                //Find the runningRock object
                GameObject runningRock = GameObject.Find("RunningRock_Trap/RunningRock");
                if (runningRock == null)
                {
                    runningRock = GameObject.Find("RunningRock(Clone)");
                }
                //roll it
                RunningRock rollScript = runningRock.GetComponent<RunningRock>();
                rollScript.Roll();

                isTriggered = true;
            }
        }        
    }
}
