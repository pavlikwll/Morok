using UnityEngine;

public class PlayerAnimationEventController : MonoBehaviour
{
    #region Attack1
    public Collider2D attack1DownCollider, attack1UpCollider, attack1SideCollider;
    
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
        attack1SideCollider.enabled = !attack1SideCollider.enabled;
    }
    #endregion
}
