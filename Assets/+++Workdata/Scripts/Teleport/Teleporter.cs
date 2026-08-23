using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private GameObject player;
    
    public void Teleport()
    {
        player.transform.position = destination.position;
    }
}
