using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    // Start is called before the first frame update
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        //Load Scene Level 2
        if (other.gameObject.tag == "Player")
        {
            var currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadSceneAsync(++currentScene);
            Debug.Log(currentScene);
        }
    }
}
