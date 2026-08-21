using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

//Organisiert die Lebenspunkte und ggf. das Sterben des Gegners.
public class EnemyInformation : MonoBehaviour
{
    [SerializeField] private int enemyMaxLifePoints = 3;
    
    public float _currentLifePoints;

    private Collider2D _coll;
    private Rigidbody2D _rb;
    private Animator _anim;
    
    private NavMeshAgent _agent;

    //private GameObject _enemySpawner;

    private NavMeshEnemy _navMeshEnemy;
    
    private void Awake()
    {
        _currentLifePoints = enemyMaxLifePoints;
        
        _coll = GetComponentInChildren<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponentInChildren<Animator>();
        
        _agent = GetComponent<NavMeshAgent>();

        //_navMeshEnemy = GetComponent<NavMeshEnemy>();

        //_enemySpawner = GameObject.Find("EnemySpawner");

    }

    public void SetDamage(int dmg /*, float force*/)
    {
        _currentLifePoints -= dmg;

        /*
        Vector2 forceDir = Vector2.zero;
        switch (_navMeshEnemy.GetCurrentFacingDirection())
        {
            case EnemyFacingDirection.Down:
                forceDir = Vector2.down;
                break;
            
            case EnemyFacingDirection.Up:
                forceDir = Vector2.up;
                break;
            
            case EnemyFacingDirection.Left:
                forceDir = Vector2.left;
                break;
            
            case EnemyFacingDirection.Right:
                forceDir = Vector2.right;
                break;
        }
        _rb.AddForce(forceDir * force, ForceMode2D.Impulse);
        */

        if (_currentLifePoints > 0)
        {
            _anim.SetTrigger("onDamage");
        }
        else
        {
            _coll.enabled = false;
            _rb.bodyType = RigidbodyType2D.Kinematic;
            _anim.SetTrigger("onDeath");
            //Destroy(GameObject.FindWithTag("EnemyHealthbar"));

            _agent.speed = 0;
            
            //_enemySpawner.GetComponent<EnemySpawner>().SpawnEnemy();
            
            Destroy(gameObject,2f);
            //Destroy(GameObject.Find("EnemyContainer"),2f);
        }
    }
    
    
    /*
    #region Physics
    
    private void SetForce(float force)
    {
        Vector2 forceDir = Vector2.zero;
        switch (_navMeshEnemy.GetCurrentFacingDirection())
        {
            case EnemyFacingDirection.Down:
                forceDir = Vector2.down;
                break;
            
            case EnemyFacingDirection.Up:
                forceDir = Vector2.up;
                break;
            
            case EnemyFacingDirection.Left:
                forceDir = Vector2.left;
                break;
            
            case EnemyFacingDirection.Right:
                forceDir = Vector2.right;
                break;
        }
        _rb.AddForce(forceDir * force, ForceMode2D.Impulse);
    }
    
    #endregion
    */
    
}