using UnityEngine;

public class DeActivatePlayerInput : MonoBehaviour
{
    public void EnablePlayerInput()
    {
        GameObject.Find("Player").GetComponent<PlayerInput>().enabled = true;
    }

    public void DisablePlayerInput()
    {
        GameObject.Find("Player").GetComponent<PlayerInput>().enabled = false;
    }
}
