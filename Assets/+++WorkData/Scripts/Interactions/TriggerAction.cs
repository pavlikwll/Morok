using UnityEngine;

public class TriggerAction : MonoBehaviour
{
    public enum ActivationType
    {
        OnTriggerEnter,
        OnInteract
    }

    [Header("Activation")]
    [SerializeField]
    private ActivationType activationType = ActivationType.OnTriggerEnter;

    [Header("Objects")]
    [SerializeField]
    private GameObject[] objectsToDisable;

    [Header("Settings")]
    [SerializeField]
    private bool oneTimeUse = true;

    private bool playerInside;
    private bool wasUsed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        playerInside = true;

        if (activationType == ActivationType.OnTriggerEnter)
            Execute();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }
    
    public void Interact()
    {
        if (activationType != ActivationType.OnInteract)
            return;

        if (!playerInside)
            return;

        Execute();
    }

    private void Execute()
    {
        if (wasUsed && oneTimeUse)
            return;

        wasUsed = true;

        foreach (GameObject obj in objectsToDisable)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        if (oneTimeUse)
            gameObject.SetActive(false);
    }
}