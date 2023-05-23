using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartManager : MonoBehaviour
{
    //maximum number of health, set in Unity Editor
    [SerializeField]
    public int maxHealth;
    [SerializeField]
    public int numOfHearts;

    public GameObject[] hearts;
    [SerializeField]
    public Sprite fullHealth;
    [SerializeField]
    public Sprite emptyHealth;

    public int health = 0;
    public string SceneName;

    private void Start()
    {
        //Read data from File
        try
        {
            //load file
            JsonHandler handler = gameObject.GetComponent<JsonHandler>();
            handler.Load();

            //if data empty -> not
            if (handler.data.position.x == 0 && handler.data.position.y == 0)
            {
                throw new Exception();
            }
            //if level not correct -> not
            if (handler.data.sceneName != SceneName)
            {
                throw new Exception();
            }

            //Update Health
            health = handler.data.health;
            numOfHearts = health;
            ChangeHearts();
        }
        catch (Exception)
        {
            //Initiate default health if there's no previous data of health
            health = maxHealth;
            numOfHearts = maxHealth;
        }
    }

    //Change the heart animation
    public void ChangeHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].GetComponent<SpriteRenderer>().enabled = true;
                //hearts[i].GetComponent<SpriteRenderer>().sprite = fullHealth;
            }
            else
            {
                //hearts[i].GetComponent<SpriteRenderer>().sprite = emptyHealth;
                hearts[i].GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }

    //minus health by 1
    public void MinusHeart()
    {
        health--;
        ChangeHearts();
    }

    //restore full health
    public void RestoreHealth()
    {
        health = maxHealth;
        ChangeHearts();
    }
}
