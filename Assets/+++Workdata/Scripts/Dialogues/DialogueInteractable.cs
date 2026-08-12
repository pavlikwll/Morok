using UnityEngine;

public class DialogueInteractable : BaseInteractable
{
    [SerializeField] private bool singleInteractable;
    
    private bool _isStillSelected;
    private bool _dialogueActive;
    
    public override void Interact()
    {
        if (!canInteract) return;
        if (singleInteractable) canInteract = false;
        
        DialogueController.OnDialogueStarted?.Invoke(this);
        _dialogueActive = true;
        base.Interact();
        base.Unselected();
    }
    
    public override void Selected()
    {
        _isStillSelected = true;
        
        if (_dialogueActive) return;
        if (!canInteract) return;
        
        base.Selected();
    }

    public override void Unselected()
    {
        _isStillSelected = false;
        
        if (_dialogueActive) return;
        if (!canInteract) return;
        
        base.Unselected();
    }

    public void TrySelected()
    {
        if (!_isStillSelected) return;
        _dialogueActive = false;
        base.Selected();
    }
}