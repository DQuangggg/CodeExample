using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFloorTrap : MonoBehaviour
{
    [SerializeField]
    private GameObject rotationPivot;

    public void Fall(float angle)
    {
        //Rotate 90 degree
        Vector3 point = rotationPivot.transform.position;
        Vector3 axis = new Vector3(0, 0, 1);
        transform.RotateAround(point, axis, angle);
    }
}
