using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloorDetect : MonoBehaviour
{
    //the floor to fall
    [SerializeField]
    private GameObject Floor;

    //fall down or not
    private bool isFallDown = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FallingFloorTrap trapScript = Floor.GetComponent<FallingFloorTrap>();
        if (!isFallDown)
        {
            trapScript.Fall(-90);
            isFallDown = true;
        }
    }
}
