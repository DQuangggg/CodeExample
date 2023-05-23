using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWall : MonoBehaviour
{
    private GameObject fallingWall;
    [SerializeField]
    GameObject wallPivot;
    [SerializeField]
    GameObject[] spikes;
    Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        fallingWall = (GameObject)Resources.Load(@"Prefabs\FallingWall");


        startPosition = transform.position;
        GameObject trigger = GameObject.Find("fallingWallTrigger");
    }

    // Update is called once per frame
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            Instantiate(fallingWall, startPosition, Quaternion.identity);
            GameObject trigger = GameObject.Find("fallingWallTrigger");

            trigger.GetComponent<FallingWallTrigger>().isTriggered = false;

        }

        
    }

    public void RotateWall()
    {
        foreach (GameObject spike in spikes)
        {
            float spikewidth = spike.GetComponent<Renderer>().bounds.size.x;

            Vector3 targetPosition = new Vector3(spike.transform.position.x + spikewidth / 2, spike.transform.position.y, spike.transform.position.z);
            spike.transform.position = Vector3.MoveTowards(spike.transform.position, targetPosition, 1f);
        }
        gameObject.transform.RotateAround(wallPivot.transform.position, new Vector3(0, 0, 1), -20);

    }
}
