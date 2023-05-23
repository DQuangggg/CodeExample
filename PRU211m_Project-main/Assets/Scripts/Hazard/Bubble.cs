using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : Hazard
{
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platformer" || collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
