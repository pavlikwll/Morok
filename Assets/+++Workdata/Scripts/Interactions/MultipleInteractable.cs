using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MultipleInteractable : BaseInteractable
{
    [SerializeField] private float timeForNextInteraction;
    
    private bool _isStillSelected;
    
    public override void Interact()
    {
        if (!canInteract) return;
        canInteract = false;
        
        StartCoroutine(WaitForInteraction());
        
        base.Interact();
        base.Unselected();
    }

    public override void Selected()
    {
        _isStillSelected = true;
        
        if (!canInteract) return;
        base.Selected();
    }

    public override void Unselected()
    {
        _isStillSelected = false;
        
        if (!canInteract) return;
        
        base.Unselected();
    }

    IEnumerator WaitForInteraction()
    {
        yield return new WaitForSeconds(timeForNextInteraction);
        canInteract = true;

        if (_isStillSelected)
        {
            base.Selected();
        }
    }
}