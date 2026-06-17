using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static Action OnInteract;
    public List<BaseInteractable> _currentInteractables;

    private void OnEnable()
    {
        OnInteract += Interact;
    }

    private void OnDisable()
    {
        OnInteract -= Interact;
    }

    private void Interact()
    {
        if (_currentInteractables.Count < 0) return;
        
        _currentInteractables[0].Interact();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        BaseInteractable currentBaseInteractable = other.GetComponent<BaseInteractable>();
        if (currentBaseInteractable)
        {
            _currentInteractables.Add(currentBaseInteractable);
            _currentInteractables[^1].Selected();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        BaseInteractable currentBaseInteractable = other.GetComponent<BaseInteractable>();
        if (currentBaseInteractable)
        {
            
            currentBaseInteractable.Unselected();
            _currentInteractables.Remove(currentBaseInteractable);
            
        }
    }
}

/*
using System;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public static Action OnInteract;

    public BaseInteractable _currentInteractable;

    private void OnEnable()
    {
        OnInteract += Interact;
    }

    private void OnDisable()
    {
        OnInteract -= Interact;
    }

    private void Interact()
    {
        if (!_currentInteractable) return;
        
        _currentInteractable.Interact();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_currentInteractable) return;
        
        _currentInteractable = other.GetComponent<BaseInteractable>();
        if (!_currentInteractable) return;
        
        _currentInteractable.Selected();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        BaseInteractable exitInteractable = other.GetComponent<BaseInteractable>();
        if (_currentInteractable == exitInteractable)
        {
            _currentInteractable.Unselected();
            _currentInteractable = null;
        }
    }
}
*/