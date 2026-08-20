using System;
using Unity.VisualScripting;
using UnityEngine;

public class SaveInWorldOneCheck : MonoBehaviour
{
    [SerializeField] private GameObject cantSaveWarningContainer;
    [SerializeField] private GameObject gameSaveSuccessfulContainer;

    public GameObject player;
    

    public void CheckIfSavePossible()
    {
        if (player.GetComponent<PlayerAbilityChangeWorld>()._inWorldOne)
        {
            GetComponent<SaveGameController>().SaveGame();
            gameSaveSuccessfulContainer.SetActive(true);
        }
        else
        {
            cantSaveWarningContainer.SetActive(true);
        }
    }
}
