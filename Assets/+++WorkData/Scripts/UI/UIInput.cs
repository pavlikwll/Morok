using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInput : MonoBehaviour
{
    #region InputActions
    
    private InputSystem_Actions _inputActions;
    private InputAction _pauseAction;
    private InputAction _inventoryAction;

    private InputAction _questlogAction;
    
    #endregion
    
    #region Unity Events
    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _pauseAction = _inputActions.UI.PauseGame;
        _inventoryAction = _inputActions.UI.Inventory;
        _questlogAction = _inputActions.UI.Questlog;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _pauseAction.performed += PauseGame;
        _inventoryAction.performed += Inventory;

        _questlogAction.performed += Questlog;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _pauseAction.performed -= PauseGame;
        _inventoryAction.performed -= Inventory;
        
        _questlogAction.performed -= Questlog;
    }
    #endregion
    
    #region Input Methods
    
    private void PauseGame(InputAction.CallbackContext ctx)
    {

    }
    
    private void Inventory(InputAction.CallbackContext ctx)
    {
        InventorySystem.OnChangeInventory?.Invoke();
    }

    private void Questlog(InputAction.CallbackContext ctx)
    {
        QuestlogSystem.OnChangeQuestlog?.Invoke();
    }
    
    #endregion

}