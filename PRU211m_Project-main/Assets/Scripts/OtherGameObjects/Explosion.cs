using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    //death support for explosion
    Timer explosionTimer;
    const float explosionDuration = 1;
    // Start is called before the first frame update
    void Start()
    {
        
        //create explosion timer
        explosionTimer = gameObject.AddComponent<Timer>();
        //start explosion timer
        explosionTimer.Duration = explosionDuration;
        explosionTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // stop explosion explosion timer finished
        if (explosionTimer.Finished)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breakable")
        {
            Destroy(collision.gameObject);
        }
    }
}
