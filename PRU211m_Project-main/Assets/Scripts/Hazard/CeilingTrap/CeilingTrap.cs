using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingTrap : MonoBehaviour
{
    private GameObject ceilingTrap ;

    Vector3 startPosition;


    private void Start()
    {
        ceilingTrap = (GameObject)Resources.Load(@"Prefabs\CeilingTrap");


        startPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            Instantiate(ceilingTrap, startPosition, Quaternion.identity);
        }
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1);

    }
}
