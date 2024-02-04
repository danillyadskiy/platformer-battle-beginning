using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public event Action Dead;

    private bool _isDead;
    
    public void GetDamage()
    {
        if (!_isDead)
        {
            if (gameObject.TryGetComponent(out EnemyMovement enemyMovement))
                enemyMovement.enabled = false;

            if (gameObject.TryGetComponent(out CapsuleCollider2D capsuleCollider))
                capsuleCollider.enabled = false;
            
            Dead?.Invoke();
        }
    }
}
