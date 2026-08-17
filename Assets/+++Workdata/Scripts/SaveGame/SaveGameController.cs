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

        saveData.items = InventorySystem.Instance.GetAllItems();
        
        
        //______________________
        saveData.playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currentHealth;
        //_________________________
        
        
        
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;


            //________
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().currentHealth = saveData.playerHealth;

            InventorySystem.Instance.SetAllItems(saveData.items);
            //_______________



        }
        else
        {
            SaveGame();
        }
    }

    public void DeleteSaveData()
    {
        File.Delete(Application.persistentDataPath + "saveData.json");
    }
}
