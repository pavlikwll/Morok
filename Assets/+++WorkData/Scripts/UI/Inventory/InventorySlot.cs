using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image itemDisplay;
    [SerializeField] private TextMeshProUGUI itemAmountText;

    private ItemDefinition _currentItemDefinition;

    private Button _inventorySlotButton;

    private void Awake()
    {
        _inventorySlotButton = GetComponent<Button>();
    }

    public void SelectItemSlot()
    {
        if (!_currentItemDefinition) return;
        
        InventorySystem.OnItemSelected?.Invoke(_currentItemDefinition);
    }
    
    public void ResetInventorySlot()
    {
        _currentItemDefinition = null;
        itemDisplay.sprite = null;
        itemDisplay.GetComponent<CanvasGroup>().alpha = 0;
        itemAmountText.SetText("");
        _inventorySlotButton.interactable = false;
    }
    
    public void FillInventorySlot(ItemDefinition itemDefinition, int amount)
    {
        _currentItemDefinition = itemDefinition;
        
        itemDisplay.GetComponent<CanvasGroup>().alpha = 1;
        itemDisplay.sprite = itemDefinition.sprite;
        itemAmountText.SetText(amount.ToString());
        _inventorySlotButton.interactable = true;
    }

    public void RemoveItemFromSlot()
    {
        
    }
}