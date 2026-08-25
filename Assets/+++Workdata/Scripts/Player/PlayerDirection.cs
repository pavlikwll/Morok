using System;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerDirection : MonoBehaviour
{
    public static PlayerDirection Instance;
    public static Action<Vector2> SetDirection;
    public PlayerDirectionState playerDirectionState;

    private PlayerStates _playerStates;

    private void Awake()
    {
        Instance = this;
        _playerStates = GetComponent<PlayerStates>();
    }
    
    private void OnEnable()
    {
        SetDirection += SetPlayerDirection;
    }

    private void OnDisable()
    {
        SetDirection -= SetPlayerDirection;
    }


    public void SetPlayerDirection(PlayerDirectionState newPlayerDirectionState)
    {
        playerDirectionState = newPlayerDirectionState;
    }

    public void SetPlayerDirection(Vector2 moveInput)
    {
        if (_playerStates.GetCurrentActionState() != PlayerActionState.Default) return;
        
        
        if (moveInput.x < 0)
        {
            playerDirectionState = PlayerDirectionState.Left;
        }
        else if (moveInput.x > 0)
        {
            playerDirectionState = PlayerDirectionState.Right;
        }
        else if (moveInput.y < 0)
        {
            playerDirectionState = PlayerDirectionState.Down;
        }
        else if (moveInput.y > 0)
        {
            playerDirectionState = PlayerDirectionState.Up;
        }
    }

    public PlayerDirectionState GetPlayerDirection()
    {
        return playerDirectionState;
    }
}