using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action Dead;

    private bool _isAlive = true;
    
    public void GetDamage()
    {
        if (_isAlive)
        {
            if (gameObject.TryGetComponent(out PlayerMovement playerMovement))
                playerMovement.enabled = false;

            if (gameObject.TryGetComponent(out CapsuleCollider2D capsuleCollider))
                capsuleCollider.enabled = false;

            if (gameObject.TryGetComponent(out Rigidbody2D rigidbody))
                rigidbody.bodyType = RigidbodyType2D.Kinematic;
            
            Dead?.Invoke();

            _isAlive = false;
        }
    }
}
