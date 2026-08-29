using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private string dialoguePath;
    [SerializeField] private bool triggerOnce = true;
    [SerializeField] private string playerTag = "Player";

    private bool wasTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (wasTriggered || !other.CompareTag(playerTag))
        {
            return;
        }

        if (DialogueController.Instance == null)
        {
            Debug.LogError(
                $"DialogueController was not found while trying to start '{dialoguePath}'.",
                this);
            return;
        }

        wasTriggered = true;

        DialogueController.Instance.StartDialogue(dialoguePath);

        if (triggerOnce)
        {
            gameObject.SetActive(false);
        }
    }
}