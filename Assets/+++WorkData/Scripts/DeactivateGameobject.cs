using UnityEngine;

public class DeactivateGameobject : MonoBehaviour
{
    public GameObject gObject;
    
    public void DeactivateObject()
    {
        gObject.SetActive(false);
    }
}