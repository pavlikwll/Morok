using System;
using UnityEngine;
using UnityEngine.Serialization;

public class QuestlogSystem : MonoBehaviour
{
    public static Action OnChangeQuestlog;

    public GameObject questlogContainer;

    public static bool questlogOpen;

    private void OnEnable()
    {
        OnChangeQuestlog += ChangeQuestlogState;
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
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        //GameObject.Find("Manager").GetComponent<UIInput>().enabled = false;
        questlogContainer.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseQuestlog()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        //GameObject.Find("Manager").GetComponent<UIInput>().enabled = true;
        questlogContainer.SetActive(false);
        Time.timeScale = 1f;
  
        questlogOpen = false;
    }

    

    
}
