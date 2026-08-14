using System;
using System.IO;
using UnityEngine;

public class SaveGameController : MonoBehaviour
{
    private string saveLocation;

    private void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        
        
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData();
        
        
        saveData.playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        
        
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
        }
        else
        {
            SaveGame();
        }
    }
}
