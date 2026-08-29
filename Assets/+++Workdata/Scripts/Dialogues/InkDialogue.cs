using UnityEngine;

public class InkDialogue : MonoBehaviour
{
    #region Inspector

    [Tooltip("Path to a specified knot.stitch in the ink file.")]
    [SerializeField] private string dialoguePath;
    
    #endregion
    

    private void Awake()
    {
       
    }

    public void StartDialogue(string dialoguePath)
    {
        if (string.IsNullOrWhiteSpace(dialoguePath))
        {
            Debug.LogWarning("No dialogue path defined", this);
            return;
        }
    }
    
    public void StartDialogue()
    {
        if (string.IsNullOrWhiteSpace(dialoguePath))
        {
            Debug.LogWarning("No dialogue path defined", this);
            return;
        }

        if (DialogueController.Instance == null)
        {
            Debug.LogError(
                $"DialogueController.Instance is missing. Cannot start '{dialoguePath}'.",
                this);
            return;
        }

        DialogueController.Instance.StartDialogue(dialoguePath);
    }
}