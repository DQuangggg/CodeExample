using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    //Function to call when click the Exit button in GamePlay
    public void ExitButtonClick()
    {
        //Get to Game Menu Scene
        GameObject canvas = GameObject.Find("Canvas");
        canvas.GetComponent<SceneSwitcher>().loadSceneByName("GameMenu");
    }
}
