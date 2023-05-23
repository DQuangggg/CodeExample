using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBGCheck : MonoBehaviour
{
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject fakeBG = GameObject.Find("Grid/FakeBg");
            fakeBG.GetComponent<Renderer>().enabled = false;
        }

    }
}
