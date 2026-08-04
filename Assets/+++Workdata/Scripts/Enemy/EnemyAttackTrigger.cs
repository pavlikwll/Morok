using System;
using UnityEngine;

//Gegner fügt Player Schaden zu und stößt ihn von sich weg.
public class EnemyAttackTrigger : MonoBehaviour
{
    public Vector2 directionForce;
    public int dmg;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamageFromEnemy(dmg,
                new Vector2(other.transform.position.x < GetComponentInParent<EnemyInformation>().transform.position.x ?
                    directionForce.x * -1 : directionForce.x,directionForce.y));
        }
    }
}