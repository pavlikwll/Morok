using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SortItemsToWorlds : MonoBehaviour
{
    public List<GameObject> normalWorldItems;
    public List<GameObject> secondWorldItems;


    
    
    private void Awake()
    {
        foreach (GameObject normalWorldItems in GameObject.FindGameObjectsWithTag("normalWorldItem"))
        {
            this.normalWorldItems.Add(normalWorldItems);
        }
        
        foreach (GameObject secondWorldItems in GameObject.FindGameObjectsWithTag("secondWorldItem"))
        {
            this.secondWorldItems.Add(secondWorldItems);
        } 
        
        ActivateNormalWorldObjects();
        DeactivateSecondWorldObjects();
    }

    public void ActivateNormalWorldObjects()
    {
        foreach (var obj in normalWorldItems)
            obj.SetActive(true);
    }
    
    public void DeactivateNormalWorldObjects()
    {
        foreach (var obj in normalWorldItems)
            obj.SetActive(false);
    }
    

    public void ActivateSecondWorldObjects()
    {
        foreach (var obj in secondWorldItems)
            obj.SetActive(true);
    }
    
    public void DeactivateSecondWorldObjects()
    {
        foreach (var obj in secondWorldItems)
            obj.SetActive(false);
    }

    public void RemoveNormalWorldItemFromList(GameObject obj)
    {
        normalWorldItems.Remove(obj);
    }
    
    public void RemoveSecondWorldItemFromList(GameObject obj)
    {
        normalWorldItems.Remove(obj);
    }
    
}
