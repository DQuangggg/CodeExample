using UnityEngine;

public class FallingRock : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;
    bool fell = false;
    
    //
    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        if(!fell) {
            if(other.gameObject.tag == "Player") {
                //change type body of rock to dynamic (can be effected by gravity)
               rigidbody2D.isKinematic = false;
               rigidbody2D.gravityScale = 4f;
               fell = true;
            } 
        }
    }
      void OnCollisionEnter2D(Collision2D other) {
          //if rock touch platformer 
        if(other.gameObject.tag ==  "Platformer") {
            //change tag of rock from Hazard to Untagged
                   gameObject.tag = "Untagged";
               } 
    }
   
}
