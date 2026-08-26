using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

//Organisiert die Lebenspunkte und ggf. das Sterben des Gegners.
public class EnemyInformation : MonoBehaviour
{
    public int enemyMaxLifePoints;
    
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

    public void SetDamage(int dmg)
    {
        _currentLifePoints -= dmg;

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
            
            Destroy(gameObject,1f);
            //Destroy(GameObject.Find("EnemyContainer"),2f);
        }
    }
    
    
}