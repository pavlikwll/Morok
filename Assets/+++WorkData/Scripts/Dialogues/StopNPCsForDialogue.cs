using UnityEngine;

public class StopNPCsForDialogue : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<NavMeshPatrol>() == null) return;
        
        other.GetComponent<NavMeshPatrol>().StopPatrol();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<NavMeshPatrol>() == null) return;
        
        other.GetComponent<NavMeshPatrol>().ResumePatrol();
    }
}
