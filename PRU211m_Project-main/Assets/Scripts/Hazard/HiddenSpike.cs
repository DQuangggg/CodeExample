using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpike : MonoBehaviour
{
    //Distance to main char
    [SerializeField]
    public float xDistanceToMainCharacter;
    [SerializeField]
    public float yDistanceToMainCharacter;
    //distance that this spike moves
    [SerializeField]
    public float xMoveDistance;
    [SerializeField]
    public float yMoveDistance;

    bool isMoved = false;

    //the destination the spike move to
    public Vector3 destination;

    private void Start()
    {
        //calculate destination that the spike move to
        destination = new Vector3(this.gameObject.transform.position.x + xMoveDistance, this.gameObject.transform.position.y + yMoveDistance);
    }

    // Update is called once per frame
    void Update()
    {
        //only move once
        if (!isMoved)
        {
            //get gameObject of main char
            GameObject mainCharacter = GameObject.FindGameObjectWithTag("Player");
            //calculate distance to main char
            float dis = Mathf.Abs(this.gameObject.transform.position.x - mainCharacter.transform.position.x);
            float dis1 = Mathf.Abs(this.gameObject.transform.position.y - mainCharacter.transform.position.y);
            Debug.Log(dis + " and " + dis1);


            if (Mathf.Abs(this.gameObject.transform.position.x - mainCharacter.transform.position.x) < xDistanceToMainCharacter
                || Mathf.Abs(this.gameObject.transform.position.y - mainCharacter.transform.position.y) < yDistanceToMainCharacter)
            {
                //if main char is close enough then move to make this spike appear

                //Moves the spike from it's current position to destination over time
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * 2);
                
                if (transform.position == destination)
                {
                    isMoved = true;
                }
            }
        }
    }
}
