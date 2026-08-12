using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [SerializeField] private PlayerActionState playerActionState;
    [SerializeField] public PlayerMovementState playerMovementState;
    public PlayerMovementState PlayerMovementState => playerMovementState;

    public static PlayerStates Instance;

    private void Awake()
    {
        Instance = this;
    }


    public void SetMovementState(PlayerMovementState newPlayerMovementState)
    {
        playerMovementState = newPlayerMovementState;
    }
    
    
    public void SetActionState(PlayerActionState newPlayerActionState)
    {
        playerActionState = newPlayerActionState;

        if (playerActionState == PlayerActionState.Default)
        {
            PlayerController.OnActionEnd?.Invoke();
        }
    }

    public void SetActionStateDefault()
    {
        playerActionState = PlayerActionState.Default;
    }
    
    public PlayerActionState GetCurrentActionState()
    {
        return playerActionState;
    }

    public PlayerMovementState GetCurrentMovementState()
    {
        return playerMovementState;
    }
}