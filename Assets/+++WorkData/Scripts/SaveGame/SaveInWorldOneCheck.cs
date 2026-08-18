using System;
using Unity.VisualScripting;
using UnityEngine;

public class SaveInWorldOneCheck : MonoBehaviour
{
    [SerializeField] private GameObject cantSaveWarning;

    public GameObject player;
    

    public void CheckIfSavePossible()
    {
        if (player.GetComponent<PlayerAbilityChangeWorld>()._inWorldOne)
        {
            GetComponent<SaveGameController>().SaveGame();
        }
        else
        {
            cantSaveWarning.SetActive(true);
        }
    }
}
