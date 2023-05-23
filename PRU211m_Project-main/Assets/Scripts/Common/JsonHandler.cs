using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

//This class will provide actions with read/write from File JSON
public class JsonHandler : MonoBehaviour
{
    public SavedPositionData data;

    private string file = "savedPosition.txt";

    public void Save()
    {
        string json = JsonUtility.ToJson(data);
        WriteToFile(file, json);
    }

    public void Load()
    {
        data = new SavedPositionData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if(File.Exists(path))
        {
            using(StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        } else
        {
            Debug.LogWarning("File not found");
            //throw exception to handle
            throw new System.Exception("File not found");
        }
    }

    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
}

//Store the position of the main character
public class SavedPositionData
{
    public Vector3 position;
    public string sceneName;
    public int health;

    public SavedPositionData()
    {
    }
}
