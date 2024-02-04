using UnityEngine;

public class PlayerDeathComponentDisabler : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Dead += DisableComponents;
    }

    private void OnDisable()
    {
        _player.Dead -= DisableComponents;
    }

    private void DisableComponents()
    {
        if (gameObject.TryGetComponent(out PlayerMovement playerMovement))
            playerMovement.enabled = false;

        if (gameObject.TryGetComponent(out CapsuleCollider2D capsuleCollider))
            capsuleCollider.enabled = false;

        if (gameObject.TryGetComponent(out Rigidbody2D rigidbody))
            rigidbody.bodyType = RigidbodyType2D.Kinematic;
    }
}