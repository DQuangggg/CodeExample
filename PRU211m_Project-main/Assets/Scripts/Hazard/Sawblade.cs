using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawblade : Hazard
{
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, new Vector3(0,0,1), 90 * Time.deltaTime);
    }
}
