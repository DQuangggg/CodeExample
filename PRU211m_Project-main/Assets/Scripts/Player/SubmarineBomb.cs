using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineBomb : MonoBehaviour
{
    [SerializeField]
    GameObject explosion;

    Timer timer;

    private void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        GameObject exp = Instantiate<GameObject>(explosion, gameObject.transform.position, Quaternion.identity);
        
        if (collision.gameObject.tag == "Breakable")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);

        }
    }
}
