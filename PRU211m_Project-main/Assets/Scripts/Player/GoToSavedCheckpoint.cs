using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Main character go to the checkpoint saved in file (if exist)
public class GoToSavedCheckpoint : MonoBehaviour
{
    //Current Level of MainCharacter
    public string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            //load file
            JsonHandler handler = gameObject.GetComponent<JsonHandler>();
            handler.Load();
            
            //if data empty -> not go to checkpoint
            if (handler.data.position.x == 0 && handler.data.position.y == 0)
            {
                throw new Exception();
            }
            //if level not correct -> not go to checkpoint
            if (handler.data.sceneName != SceneName)
            {
                throw new Exception();
            }

            //go to checkpoint
            gameObject.transform.position = new Vector3(handler.data.position.x, handler.data.position.y, 0);
        }
        catch (Exception)
        {
            //if file not exist -> do nothing
        }
    }
}
