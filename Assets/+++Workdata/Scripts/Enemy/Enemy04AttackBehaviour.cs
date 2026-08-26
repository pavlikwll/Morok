using System;
using UnityEngine;

public class Enemy04AttackBehaviour : MonoBehaviour
{
    public GameObject projectile;
    public Transform projPos;

    public float attackDistance;
    public float shootSpeed;

    private float timer;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }


    private void Update()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);

        if (distance < attackDistance)
        {
            timer += Time.deltaTime;
            
            if (timer >= shootSpeed)
            { 
                timer = 0;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        Instantiate(projectile, projPos.position, Quaternion.identity);
    }
}
