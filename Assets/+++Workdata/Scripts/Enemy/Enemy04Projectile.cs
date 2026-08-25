using System;
using UnityEngine;

public class Enemy04Projectile : MonoBehaviour
{
    private GameObject _player;
    private Rigidbody2D _rb;

    public float force;
    //public Vector2 directionForce;
    public int dmg;
    
    private float timer;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindWithTag("Player");
        
        Vector3 direction = _player.transform.position - transform.position;
        _rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamageFromEnemy(dmg /*, 
                new Vector2(other.transform.position.x < GetComponentInParent<EnemyInformation>().transform.position.x ?
                    directionForce.x * -1 : directionForce.x,directionForce.y)*/);
            
            Destroy(gameObject);
        }
    }
}
