using System;
using UnityEngine;
using UnityEngine.Serialization;

public class QuestlogSystem : MonoBehaviour
{
    public static Action OnChangeQuestlog;

    public GameObject questlogContainer;

    public static bool questlogOpen;

    private void Awake()
    {
        questlogContainer.SetActive(false);
        questlogOpen = false;
    }


    private void OnEnable()
    {
        OnChangeQuestlog += ChangeQuestlogState;
        
        questlogOpen = false;
    }

    private void OnDisable()
    {
        OnChangeQuestlog -= ChangeQuestlogState;
    }
    
    public void ChangeQuestlogState()
    {
        OpenCloseQuestlog();
        print("questlog");
    }
    
    public void OpenCloseQuestlog()
    {
        if (PauseMenu_UIManager.isPaused == false && InventorySystem.inventoryOpen == false)
        {
            questlogOpen = !questlogOpen;
                    
            if (questlogOpen)
            {
                OpenQuestlog();
            }
            else
            {
                CloseQuestlog();
            }
        }
    }
    
    private void OpenQuestlog()
    {
        GameObject.Find("Player").GetComponent<PlayerInput>().enabled = false;
        questlogContainer.SetActive(true);
        //Time.timeScale = 0f;
        
        questlogOpen = true;
    }
    public void CloseQuestlog()
    {
        GameObject.Find("Player").GetComponent<PlayerInput>().enabled = true;
        questlogContainer.SetActive(false);
        //Time.timeScale = 1f;
  
        questlogOpen = false;
    }
}
