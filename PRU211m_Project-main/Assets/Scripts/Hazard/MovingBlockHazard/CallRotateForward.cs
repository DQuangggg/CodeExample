using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallRotateForward : MonoBehaviour
{
    [SerializeField]
    public GameObject rotateBlock;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovingBlock movingBlock = rotateBlock.GetComponent<MovingBlock>();
        movingBlock.RotateForward();
    }
}
