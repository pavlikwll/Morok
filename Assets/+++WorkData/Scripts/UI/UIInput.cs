using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIInput : MonoBehaviour
{
    #region InputActions
    
    private InputSystem_Actions _inputActions;
    private InputAction _pauseAction;
    private InputAction _inventoryAction;
    
    #endregion
    
    #region Unity Events
    private void Awake()
    {
        _inputActions = new InputSystem_Actions();
        _pauseAction = _inputActions.UI.PauseGame;
        _inventoryAction = _inputActions.UI.Inventory;
    }

    private void OnEnable()
    {
        _inputActions.Enable();
        _pauseAction.performed += PauseGame;
        _inventoryAction.performed += Inventory;
    }

    private void OnDisable()
    {
        _inputActions.Disable();
        _pauseAction.performed -= PauseGame;
        _inventoryAction.performed -= Inventory;
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
    
    #endregion

}