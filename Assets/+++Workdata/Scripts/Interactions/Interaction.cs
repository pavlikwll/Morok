using System;
using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    #region Inspector
    [Header("References")]
    public string interactableId;
    [SerializeField] private InteractionGroup[] interactionGroups;
    [SerializeField] private int interactionIndex;
    #endregion

    private void OnEnable()
    {
        if (PlayerPrefs.HasKey(interactableId))
        {
            LoadInteractionIndex();
        }
       
    }


    #region Interaction Functions
    public void Execute()
    {
        if (interactionGroups == null || interactionGroups.Length == 0)
        {
            Debug.LogError(
                $"Interaction '{interactableId}' has no interaction groups.",
                this);
            return;
        }

        if (interactionIndex < 0 || interactionIndex >= interactionGroups.Length)
        {
            Debug.LogWarning(
                $"Interaction index {interactionIndex} is invalid for " +
                $"'{interactableId}'. Resetting to 0.",
                this);

            interactionIndex = 0;
        }

        interactionGroups[interactionIndex].onInteracted?.Invoke();

        int nextInteraction =
            interactionGroups[interactionIndex].nextInteraction;

        if (nextInteraction >= 0 &&
            nextInteraction < interactionGroups.Length)
        {
            interactionIndex = nextInteraction;
        }
    }

    /// <summary>
    /// Set the interaction index to a specific interaction 
    /// </summary>
    /// <param name="interactIndex">the new interaction index</param>
    public void SetInteractionIndex(int interactIndex)
    {
        interactionIndex = interactIndex;
        SaveInteractionIndex();
    }
    
    /// <summary>
    /// Set the interaction index to a specific interaction and executes the interaction
    /// </summary>
    /// <param name="interactIndex">the new interaction index</param>
    public void SetInteractionIndexExecute(int interactIndex)
    {
        interactionIndex = interactIndex;
        Execute();
    }
    
    
    #endregion

    #region Save

    public void SaveInteractionIndex()
    {
        PlayerPrefs.SetInt(interactableId, interactionIndex);
        PlayerPrefs.Save();
    }

    public void LoadInteractionIndex()
    {
        interactionIndex = PlayerPrefs.GetInt(interactableId);
    }

    #endregion
    
}
[Serializable]
public class InteractionGroup
{
    public string interactionName;
    public UnityEvent onInteracted;
    public int nextInteraction = -1;
}