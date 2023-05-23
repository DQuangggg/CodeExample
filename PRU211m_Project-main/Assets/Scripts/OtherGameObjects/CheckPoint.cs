using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class controls a checkpoint
public class CheckPoint : MonoBehaviour
{
    [SerializeField]
    public JsonHandler handler;
    //The Scene of this Checkpoint, used to Write to File
    [SerializeField]
    public string SceneName;

    //When MainCharacter passes the Checkpoint
    //-> update the checkpoint of the MainCharacter so that it will respawn here
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject touchedObject = collision.gameObject;
        if (touchedObject.tag == "Player")
        {
             touchedObject.GetComponent<PlayerMovement>().checkPointPassed = transform.position;

            UpdateSavedPositionFile();
        }
    }

    //Update Checkpoint Data to file
    private void UpdateSavedPositionFile()
    {
        handler.data = new SavedPositionData();

        //Update Position
        handler.data.position = transform.position;
        handler.data.sceneName = SceneName;

        //Update Health
        GameObject mainCharacter = GameObject.Find("MainCharacter");
        handler.data.health = mainCharacter.GetComponent<HeartManager>().health;

        handler.Save();
    }
}
