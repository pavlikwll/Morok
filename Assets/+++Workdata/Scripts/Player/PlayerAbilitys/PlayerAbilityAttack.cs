using System;
using UnityEngine;

public class PlayerAbilityAttack : MonoBehaviour
{
    public static Action OnAttackInput;
    
    [SerializeField] private int actionId;
    
    private PlayerStates _playerStates;

    private void Awake()
    {
        _playerStates = GetComponent<PlayerStates>();
    }
    
    private void OnEnable()
    {
        OnAttackInput += SetAttack1Input;
    }

    private void OnDisable()
    {
        OnAttackInput -= SetAttack1Input;
    }

    private void SetAttack1Input()
    {
        if (_playerStates.GetCurrentActionState() == PlayerActionState.Default && _playerStates.GetCurrentMovementState() == PlayerMovementState.Idle)
        {
            print("attack");
            
            PlayerAnimation.OnAction?.Invoke(actionId);
        }
    }
}
