using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public static Action<ItemDefinition> OnItemSelected;
    
    public static Action<ItemDefinition, int> OnAddItem;
    public static Action OnChangeInventory;
    
    public List<Item> items;

    public GameObject inventoryContainer;

    public static bool inventoryOpen;
    

    [Header("Item Informations")]
    [SerializeField] private GameObject itemInformationContainer;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemId;
    [SerializeField] private Image itemImage;

    private void OnEnable()
    {
        OnAddItem += Add;
        OnChangeInventory += ChangeInventoryState;
        
        OnItemSelected += SetItemInformation;
    }

    private void OnDisable()
    {
        OnAddItem -= Add;
        OnChangeInventory -= ChangeInventoryState;
        
        OnItemSelected -= SetItemInformation;
        
        //inventoryContainer.SetActive(false);
    }

    private void SetItemInformation(ItemDefinition itemDefinition)
    {
        itemInformationContainer.SetActive(true);
        
        itemName.SetText(itemDefinition.displayName);
        itemDescription.SetText(itemDefinition.description);
        itemId.SetText(itemDefinition.id);
        itemImage.sprite = itemDefinition.sprite;
        
    }
    
    public void ChangeInventoryState()
    {
        itemInformationContainer.SetActive(false);
  
        OpenCloseInventory();
        print("inventar");
  
        InventoryManager.Instance.SetInventoryItems(items);
    }
    public void OpenCloseInventory()
    {
        if (PauseMenu_UIManager.isPaused == false && QuestlogSystem.questlogOpen == false)
        {
            inventoryOpen = !inventoryOpen;
            
            if (inventoryOpen)
            {
                OpenInventory();
            }
            else 
            { 
                CloseInventory();
            }
        }
        
    }
    private void OpenInventory()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        //GameObject.Find("Manager").GetComponent<UIInput>().enabled = false;
        inventoryContainer.SetActive(true);
        Time.timeScale = 0f;
    }
    public void CloseInventory()
    {
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
        //GameObject.Find("Manager").GetComponent<UIInput>().enabled = true;
        inventoryContainer.SetActive(false);
        Time.timeScale = 1f;
  
        inventoryOpen = false;
    }

    
    public Item GetItem(string id)
    {
        foreach (var item in items)
        {
            if (item.id == id)
            {
                return item;
            }
        }

        return null;
    }
    public void Add(ItemDefinition itemDefinition, int amount)
    {
        Add(itemDefinition.id, amount);
    }
    public void Add(string itemId, int amount = 1)
    {
        if (!ValidateItem(itemId, amount)) return;

        Item newItem = GetItem(itemId);

        if (newItem == null)
        {
            items.Add(new Item(itemId, amount));
        }
        else
        {
            newItem.amount += amount;
        }
        
        //TODO: Quest System hinzufuegen

    }
    private bool ValidateItem(string itemId, int amount)
    {
        if (string.IsNullOrWhiteSpace(itemId) || string.IsNullOrEmpty(itemId))
        {
            Debug.LogError("Item id is null or empty");
            return false;
        }

        if (amount == 0)
        {
            Debug.LogError($"Item with the Id: {itemId}. The amount is equal to 0. This is not allowed!");
            return false;
        }

        //TODO: Existiert die Id Ã¼berhaupt?
        
        return true;
    }
}