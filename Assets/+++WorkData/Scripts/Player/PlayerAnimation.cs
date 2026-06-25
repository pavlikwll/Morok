using System;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    int _hashActionId = Animator.StringToHash("ActionId");
    int _hashActionTrigger = Animator.StringToHash("ActionTrigger");
    int _hashMovementValue = Animator.StringToHash("MovementValue");
    int _hashxDir = Animator.StringToHash("xDir");
    int _hashyDir = Animator.StringToHash("yDir");
    
    public static Action<int> OnAction;
    
    [SerializeField] private Animator[] anims;  

    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        OnAction += SetAnimationAction;
    }

    private void LateUpdate()
    {
        SetAnimationValues();
    }

    private void OnDisable()
    {
        OnAction -= SetAnimationAction;
    }

    void SetAnimationValues()
    {
        for (int i = 0; i < anims.Length; i++)
        {
            anims[i].SetFloat(_hashMovementValue, Mathf.Abs(_playerController.Rb.linearVelocity.magnitude));

            if (_playerController.MoveInput != Vector2.zero)
            {
                anims[i].SetFloat(_hashxDir, _playerController.MoveInput.x);
                anims[i].SetFloat(_hashyDir, _playerController.MoveInput.y);
            }
        }
    }

    void SetAnimationAction(int actionId)
    {
        for (int i = 0; i < anims.Length; i++)
        {
            anims[i].SetInteger(_hashActionId, actionId);
            anims[i].SetTrigger(_hashActionTrigger);
        }
    }
}