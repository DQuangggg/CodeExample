using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject touchedCharacter = collision.gameObject;
        if (touchedCharacter.tag == "Player")
        {
            //Destroy(touchedCharacter);
        }

    }
}
