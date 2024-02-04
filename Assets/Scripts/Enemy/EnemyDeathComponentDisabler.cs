using UnityEngine;

public class EnemyDeathComponentDisabler : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.Dead += DisableComponents;
    }

    private void OnDisable()
    {
        _enemy.Dead -= DisableComponents;
    }

    private void DisableComponents()
    {
        if (gameObject.TryGetComponent(out EnemyMovement enemyMovement))
            enemyMovement.enabled = false;

        if (gameObject.TryGetComponent(out CapsuleCollider2D capsuleCollider))
            capsuleCollider.enabled = false;
    }
}