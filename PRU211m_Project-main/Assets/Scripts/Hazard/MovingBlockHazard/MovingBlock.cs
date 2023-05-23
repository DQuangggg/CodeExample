using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    //this is the point to rotate around
    [SerializeField]
    public GameObject rotationPivot;

    //to check rotate
    bool rotateForward = false;
    bool rotateBack = false;

    //Max position: used to stop rotation
    float maxRotateX;
    float minRotateX;
    float maxRotateY;

    private void Start()
    {
        //find max/min rotate by rotationPivot
        float distance = rotationPivot.transform.position.x - transform.position.x;
        maxRotateX = transform.position.x + 2*distance;
        minRotateX = transform.position.x;
        maxRotateY = transform.position.y;
    }

    private void Update()
    {
        if (rotateForward)
        {
            Vector3 point = rotationPivot.transform.position;
            Vector3 axis = new Vector3(0, 0, 1);
            transform.RotateAround(point, axis, 50 * Time.deltaTime);

            //stop rotate if reach position
            if (transform.position.x >= maxRotateX || transform.position.y >= maxRotateY)
            {
                rotateForward = false;
            }

        } else if (rotateBack)
        {
            Vector3 point = rotationPivot.transform.position;
            Vector3 axis = new Vector3(0, 0, 1);
            transform.RotateAround(point, axis, -50 * Time.deltaTime);

            //stop rotate if reach position
            if (transform.position.x <= minRotateX || transform.position.y >= maxRotateY)
            {
                rotateBack = false;
            }
        }
        
    }

    public void RotateForward()
    {
        rotateForward = true;
    }

    public void RotateBack()
    {
        rotateBack = true;
    }
}
