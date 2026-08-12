using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    private NavMeshEnemy _navMeshEnemy;
   
    public Collider2D attack1DownCollider, attack1UpCollider, attack1SideCollider;
    
    
    private void Awake()
    {
        _navMeshEnemy = GetComponentInParent<NavMeshEnemy>();
    }

    public void EndAttack()
    {
        _navMeshEnemy.EndAttack();
    }

    public void DeactivateAttackColliders()
    {
        attack1DownCollider.enabled = false;
        attack1SideCollider.enabled = false;
        attack1UpCollider.enabled = false;
    }
    
    
    
    
    public void AnimAttack1Down()
    {
        attack1DownCollider.enabled = !attack1DownCollider.enabled;
    }
    
    public void AnimAttack1Up()
    {
        attack1UpCollider.enabled = !attack1UpCollider.enabled;
    }
    
    public void AnimAttack1Side()
    {
        attack1UpCollider.enabled = !attack1UpCollider.enabled;
    }
    
    
    
    
    
}
