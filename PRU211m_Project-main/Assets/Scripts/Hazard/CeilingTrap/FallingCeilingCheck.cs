using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCeilingCheck : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject ceilingTrap;
        ceilingTrap = GameObject.Find("CeilingTrap");

        if (ceilingTrap == null)
        {
            ceilingTrap = GameObject.Find("CeilingTrap(Clone)");
        }
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = ceilingTrap.GetComponent<Rigidbody2D>();
            rb.angularDrag = 0;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            rb.AddForce(Vector2.down * 75f);
        }
    }
}
