using System;
using UnityEngine;

//Organisiert das Leben und ggf. den Tod des Players.
public class PlayerHealth : MonoBehaviour
{
    #region Variables
    [SerializeField] private float maxHealth;
    public float currentHealth; //{get; private set;}
    private Animator _anim;
    private Rigidbody2D _rb;
    private Collider2D _coll;
    
    private GameObject _player;
    
    private PlayerController _pc;
    
    public UIInput uiInput;
    public GameOver_UIManager gameOverUIManager;
    public PauseMenu_UIManager pauseMenuUIManager;
    
    private bool _isDead;
    
    #endregion  

    private void Awake()
    {
        currentHealth = maxHealth;
        _anim = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _pc = GetComponent<PlayerController>();
        _coll = GetComponent<Collider2D>();
        
        
        _player = GameObject.Find("Player");
    }

    #region Damage
    public void TakeDamageFromEnemy(float _damage, Vector2 dmgDirectionForce)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, maxHealth);

        if (currentHealth > 0)
        {
            _anim.SetTrigger("onDamage");
            GetComponent<PlayerStates>().SetActionStateDefault();
        }
        else
        {
            if (!_isDead)
            {
                Death();
            }
        }
        //_playerController.SetDirectionForce(dmgDirectionForce);
    }
    #endregion
    
    #region Death
    public void Death()
    {
        _anim.SetTrigger("onDeath");
        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;
        _pc.enabled = false;
        uiInput.enabled = false;
        pauseMenuUIManager.enabled = false;
        _isDead = true;
        gameOverUIManager.UIGameOver();
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _coll.enabled = false;
    }

    /*
    public void Revive()
    {
        _anim.SetTrigger("onRevive");
        _pc.enabled = true;
        _isDead = false;
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _coll.enabled = true;
        AddHealth(5);
        
        _player.transform.position = new Vector3(7.5f, 3, 0);
        
        //gameOverUIManager.Revive();
    }
    */
    
    public void InstantDeath()
    {
        currentHealth = 0;
        Death();
    }
    #endregion
    
    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, maxHealth);
    }
    
}
