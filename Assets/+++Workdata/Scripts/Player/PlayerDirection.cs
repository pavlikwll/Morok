using System;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{

    public static Action<Vector2> SetDirection;
    [SerializeField] PlayerDirectionState _playerDirectionState;

    private PlayerAction _playerAction;

    private void Awake()
    {
        _playerAction = GetComponent<PlayerAction>();
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
        _playerDirectionState = newPlayerDirectionState;
    }

    public void SetPlayerDirection(Vector2 moveInput)
    {
        if (_playerAction.GetCurrentActionState() != PlayerActionState.Default) return;
        
        
        if (moveInput.x < 0)
        {
            _playerDirectionState = PlayerDirectionState.Left;
        }
        else if (moveInput.x > 0)
        {
            _playerDirectionState = PlayerDirectionState.Right;
        }
        else if (moveInput.y < 0)
        {
            _playerDirectionState = PlayerDirectionState.Down;
        }
        else if (moveInput.y > 0)
        {
            _playerDirectionState = PlayerDirectionState.Up;
        }
    }

    public PlayerDirectionState GetPlayerDirection()
    {
        return _playerDirectionState;
    }
}