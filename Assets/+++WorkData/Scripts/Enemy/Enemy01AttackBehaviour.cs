using System;
using UnityEngine;

public class Enemy01AttackBehaviour : MonoBehaviour
{
    private Animator _anim;

    private bool _isTransformed;

    private void Awake()
    {
        _anim = GetComponentInChildren<Animator>();
        _isTransformed = false;

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isTransformed = true;
            _anim.SetBool("e1Transformed", _isTransformed);
        }
    }


    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _isTransformed = false;
            _anim.SetBool("e1Transformed", _isTransformed);
        }
    }
    
    
    public void EnterAttackDistance()
    {
        
    }

    public void ExitAttackDistance()
    {
        
    }
}
