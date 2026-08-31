using UnityEngine;

public class InventoryItemGiver : MonoBehaviour
{
    [SerializeField] private ItemDefinition itemDefinition;
    [SerializeField] private int amount = 1;

    public void GiveItem()
    {
        if (itemDefinition == null)
        {
            Debug.LogError("ItemDefinition is not assigned.", this);
            return;
        }

        if (amount <= 0)
        {
            Debug.LogError("Amount must be greater than 0.", this);
            return;
        }

        InventorySystem.OnAddItem?.Invoke(itemDefinition, amount);
    }
}