using System;
using UnityEngine;

public class Enemy01AttackBehaviour : MonoBehaviour
{
    private Animator _anim;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    public void EnterAggroDistance()
    {
        //_anim.SetBool("e1Transformed" = true);
    }

    public void ExitAggroDistance()
    {
        
    }
    
    
    public void EnterAttackDistance()
    {
        
    }

    public void ExitAttackDistance()
    {
        
    }
}
