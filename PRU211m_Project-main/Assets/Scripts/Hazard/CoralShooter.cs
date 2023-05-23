using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoralShooter : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;
    public float spawnInterval;

    // negative mean down, positive mean up
    public int verticalDirection;
    public float projectileSpeed;

    Timer timer;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = spawnInterval;
        timer.Run();
        float objectHeight = gameObject.GetComponent<Renderer>().bounds.size.y;
        if (verticalDirection >= 0) verticalDirection = 1;
        else verticalDirection = -1;
        spawnPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + verticalDirection * objectHeight, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {

            GameObject projectile = Instantiate<GameObject>(projectilePrefab, spawnPosition, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(projectileSpeed * Vector3.up * verticalDirection);
            timer.Run();
        }
    }
}
