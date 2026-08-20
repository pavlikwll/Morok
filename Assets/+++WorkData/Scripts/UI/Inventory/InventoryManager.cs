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
    [SerializeField] private List<InventorySlot> storyInventorySlots;
    [SerializeField] private List<InventorySlot> puzzleInventorySlots;
    [SerializeField] private List<InventorySlot> notesInventorySlots;
    [SerializeField] private List<InventorySlot> photographInventorySlots;
    

    private void Awake()
    {
        Instance = this;
    }

    public void SetInventoryItems(List<Item> allItemsInInventory)
{
    #region ResetSlots
    foreach (var slot in storyInventorySlots) slot.ResetInventorySlot();
    foreach (var slot in puzzleInventorySlots) slot.ResetInventorySlot();
    foreach (var slot in notesInventorySlots) slot.ResetInventorySlot();
    foreach (var slot in photographInventorySlots) slot.ResetInventorySlot();
    #endregion
    
    int currentStoryItemIndex = 0;
    int currentPuzzleItemIndex = 0;
    int currentNoteIndex = 0;
    int currentPhotographItemIndex = 0;
    
    
    foreach (var currentItemInInventory in allItemsInInventory)
    {
        ItemDefinition matchingGameItem = allItemsInGame.Find(item => item.id == currentItemInInventory.id);
        
        if (matchingGameItem == null) continue;
        
        switch (matchingGameItem.itemType)
        {
            case ItemType.Story:
                if (currentStoryItemIndex < storyInventorySlots.Count)
                {
                    storyInventorySlots[currentStoryItemIndex].FillInventorySlot(matchingGameItem, currentItemInInventory.amount);
                    currentStoryItemIndex++;
                }
                break;
            
            case ItemType.Puzzle:
                if (currentPuzzleItemIndex < puzzleInventorySlots.Count)
                {
                    puzzleInventorySlots[currentPuzzleItemIndex].FillInventorySlot(matchingGameItem, currentItemInInventory.amount);
                    currentPuzzleItemIndex++;
                }
                break;
            
            case ItemType.Notes:
                if (currentNoteIndex < notesInventorySlots.Count)
                {
                    notesInventorySlots[currentNoteIndex].FillInventorySlot(matchingGameItem, currentItemInInventory.amount);
                    currentNoteIndex++;
                }
                break;
            
            case ItemType.Photograph:
                if (currentPhotographItemIndex < photographInventorySlots.Count)
                {
                    photographInventorySlots[currentPhotographItemIndex].FillInventorySlot(matchingGameItem, currentItemInInventory.amount);
                    currentPhotographItemIndex++;
                }
                break;
        }
    }
}

}