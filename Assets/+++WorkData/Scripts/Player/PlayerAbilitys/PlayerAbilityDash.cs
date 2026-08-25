using System;
using UnityEngine;

public class PlayerAbilityDash : MonoBehaviour
{
    public static Action OnDashInput;
    
    [SerializeField] private int actionId;

    [SerializeField] private float dashForce;

    private PlayerStates _playerStates;

    private void Awake()
    {
        _playerStates = GetComponent<PlayerStates>();
    }

    private void OnEnable()
    {
        OnDashInput += SetDashInput;
    }

    private void OnDisable()
    {
        OnDashInput -= SetDashInput;
    }

    private void SetDashInput()
    {
        if (_playerStates.GetCurrentActionState() == PlayerActionState.Default)
        {
            //PlayerAnimation.OnAction?.Invoke(actionId);
            PlayerController.OnAddForce?.Invoke(dashForce);
        }
        
    }
}