using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    #region InputActions
    
    private InputSystem_Actions _inputActions;
    private InputAction _moveAction;
    private InputAction _interactAction;
    private InputAction _attackAction;
    private InputAction _dashAction;

    private InputAction _changeWorldAction;
    
    
    #endregion
    
    #region UnityEvents

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        
        _inputActions = new InputSystem_Actions();
        _moveAction = _inputActions.Player.Move;
        _interactAction = _inputActions.Player.Interact;
        _attackAction = _inputActions.Player.Attack;
        _dashAction = _inputActions.Player.Dash;

        _changeWorldAction = _inputActions.Player.ChangeWorld;
    }

    private void OnEnable()
    {
        EnableInput();
        
        _moveAction.performed += Move;
        _moveAction.canceled += Move;

        _interactAction.performed += Interact;
        _attackAction.performed += Attack;
        _dashAction.performed += Dash;

        _changeWorldAction.performed += ChangeWorld;
    }
    
    private void OnDisable()
    {
        DisableInput();
        
        _moveAction.performed -= Move;
        _moveAction.canceled -= Move;
        
        _interactAction.performed -= Interact;
        _attackAction.performed -= Attack;
        _dashAction.performed -= Dash;
        
        _changeWorldAction.performed -= ChangeWorld;
    }
    
    #endregion

    public void EnableInput()
    {
        _inputActions.Enable();
    }

    public void DisableInput()
    {
        _inputActions.Disable();
    }
    
    #region Input Methodes

    private void Move(InputAction.CallbackContext ctx)
    {
        PlayerController.OnMoveInput?.Invoke(ctx.ReadValue<Vector2>());

        if (ctx.performed)
        {
            PlayerDirection.SetDirection?.Invoke(ctx.ReadValue<Vector2>());
            return;
        }
        
        GetComponent<PlayerAnimation>().SetAnimIdleValues();
    }

    private void Interact(InputAction.CallbackContext ctx)
    {
        PlayerInteraction.OnInteract?.Invoke();
    }

    private void ChangeWorld(InputAction.CallbackContext ctx)
    {
        PlayerAbilityChangeWorld.OnChangeWorld?.Invoke();
    }

    private void Attack(InputAction.CallbackContext ctx)
    {
        PlayerAbilityAttack.OnAttackInput?.Invoke();
    }
    
    private void Dash(InputAction.CallbackContext ctx)
    {
        PlayerAbilityDash.OnDashInput?.Invoke();
    }

    #endregion
}