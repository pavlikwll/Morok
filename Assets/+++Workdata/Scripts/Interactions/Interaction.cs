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
        //Fallback in case the index is out of range
        if (interactionGroups == null || interactionGroups.Length == 0)
        {
            Debug.LogError($"No Interaction Groups configured on '{name}'.", this);
            return;
        }

        if (interactionIndex < 0 || interactionIndex >= interactionGroups.Length)
        {
            Debug.LogError(
                $"Interaction Index {interactionIndex} is out of range on '{name}'. " +
                $"Available groups: {interactionGroups.Length}.",
                this);
            
            return;
        }

        InteractionGroup currentInteraction = interactionGroups[interactionIndex];
        currentInteraction.onInteracted?.Invoke();
        
        if (currentInteraction.nextInteraction != -1)
        {
            SetInteractionIndex(currentInteraction.nextInteraction);
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