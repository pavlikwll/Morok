using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Holds a list of conditions and reacts once these conditions are fulfilled by the <see cref="gameState"/>.
/// </summary>
public class Reactor : MonoBehaviour
{
    #region Inspector

    [Tooltip("AND connected conditions that all need to be fulfilled.")] [SerializeField]
    private List<Condition> conditions;

    [Tooltip("Invoked when all the conditions become fulfilled.")] [SerializeField]
    private UnityEvent onFulfilled;

    [Tooltip("Invoked when any of the conditions return to being unfulfilled.")] [SerializeField]
    private UnityEvent onUnfulfilled;

    [Tooltip("Optional field to reference a QuestEntry, if this reactor represents a quest.")] [SerializeField]
    private QuestEntry questEntry;

    #endregion

    /// <summary>State of the <see cref="Reactor"/>. Used to detect difference once the <see cref="gameState"/> changes.</summary>
    private bool fulfilled = false;

    private InventorySystem _inventorySystem;


    #region Unity Event Functions

    private void Awake()
    {
        // Cache the GameState as it will be accessed frequently.
        _inventorySystem = FindObjectOfType<InventorySystem>();
    }

    private void OnEnable()
    {
        _inventorySystem ??= FindFirstObjectByType<InventorySystem>();

        fulfilled = _inventorySystem.CheckConditions(conditions);

        if (questEntry != null)
        {
            questEntry.gameObject.SetActive(true);
            questEntry.SetQuestStatus(fulfilled);
        }

        InventorySystem.StateChanged += CheckConditions;
    }

    private void OnDisable()
    {
        if (questEntry != null)
        {
            questEntry.gameObject.SetActive(false);
        }

        InventorySystem.StateChanged -= CheckConditions;
    }

    #endregion

    /// <summary>
    /// Check the <see cref="conditions"/> against the <see cref="GameState"/> and perform the appropriate <see cref="UnityEvent"/> when the result changes.
    /// </summary>
    private void CheckConditions()
    {
        bool newFulfilled = _inventorySystem.CheckConditions(conditions);

        if (!fulfilled && newFulfilled)
        {
            fulfilled = true;

            if (questEntry != null)
            {
                questEntry.SetQuestStatus(true);
            }

            onFulfilled?.Invoke();
        }
        else if (fulfilled && !newFulfilled)
        {
            fulfilled = false;

            if (questEntry != null)
            {
                questEntry.SetQuestStatus(false);
            }

            onUnfulfilled?.Invoke();
        }
    }

    [Serializable]
    public class Condition
    {
        public ItemDefinition itemDefinition;
        public int amount;
    }
}