using System;
using UnityEngine;

public class Enemy04AttackBehaviour : MonoBehaviour
{
    public GameObject projectile;
    public Transform projPos;

    private float timer;
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }


    private void Update()
    {
        float distance = Vector2.Distance(transform.position, _player.transform.position);

        if (distance < 5)
        {
            timer += Time.deltaTime;
            
            if (timer >= 2f)
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
