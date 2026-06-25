using UnityEngine;

public class PlayerStates : MonoBehaviour
{
    [SerializeField] PlayerActionState playerActionState;

    public void SetActionState(PlayerActionState newPlayerActionState)
    {
        playerActionState = newPlayerActionState;

        if (playerActionState == PlayerActionState.Default)
        {
            PlayerController.OnActionEnd?.Invoke();
        }
    }

    public PlayerActionState GetCurrentActionState()
    {
        return playerActionState;
    }
}