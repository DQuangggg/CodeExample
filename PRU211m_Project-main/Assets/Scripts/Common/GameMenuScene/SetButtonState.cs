using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonState : MonoBehaviour
{
    //Check if has saved Data or not -> if not: Disable [Continue button]
    private void Start()
    {
        try
        {
            //load file
            JsonHandler handler = gameObject.AddComponent<JsonHandler>();
            handler.Load();
            //if there's no data -> disable button
            if (handler.data.sceneName == "")
            {
                throw new Exception();
            }
        }
        catch (Exception)
        {
            //Disable Continue button
            GameObject continueButton = GameObject.Find("Canvas/ButtonContinue");
            continueButton.GetComponent<Button>().interactable = false;
        }
    }
}
