using UnityEngine;

//Bei Angriffen vom Player wird ein Trigger aktiviert. Befindet sich ein Gegner in diesem Trigger wird ihm im Inspector festgelegter Schaden zugefügt.
public class PlayerAttackTrigger : MonoBehaviour
{
    [SerializeField] private int attackDamage;
    //[SerializeField] private int attackForce;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyInformation>().SetDamage(attackDamage /*, attackForce*/);
        }
    }
}