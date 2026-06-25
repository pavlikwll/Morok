using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    [SerializeField] private ItemDefinition itemDefinition;
    [SerializeField] private int amount;

    [SerializeField] private UnityEvent onCollected;

    [SerializeField] private bool destroyObj = true;
    [SerializeField] private float deleteTimer = 0 ;

    public void Collect()
    {
        if (itemDefinition == null)
        {
            Debug.LogError("No IdemDefinition assigned!");
            return;
        }
        
        InventorySystem.OnAddItem?.Invoke(itemDefinition, amount);

        onCollected?.Invoke();
        
        if (destroyObj)
        {
            Invoke("DestroyObject", deleteTimer);
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}