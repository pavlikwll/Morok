using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static Action<ItemDefinition> OnItemSelected;
    
    public static InventoryManager Instance;

    [SerializeField] private List<ItemDefinition> allItemsInGame;
    [SerializeField] private List<InventorySlot> inventorySlots;
    

    

    private void Awake()
    {
        Instance = this;
    }

    public void SetInventoryItems(List<Item> allItemsInInventory)
    {
        foreach (var currentSlot in inventorySlots)
        {
            currentSlot.ResetInventorySlot();
        }
        
        int currentItemIndex = 0;
        foreach (var currentItemInInventory in allItemsInInventory)
        {

            foreach (var currentItemInGame in allItemsInGame)
            {
                if (currentItemInInventory.id == currentItemInGame.id)
                {
                    inventorySlots[currentItemIndex].FillInventorySlot(currentItemInGame, currentItemInInventory.amount);
                    break;
                }
            }

            currentItemIndex++;
        }
    }
}