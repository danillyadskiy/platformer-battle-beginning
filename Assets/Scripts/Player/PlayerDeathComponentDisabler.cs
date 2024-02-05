using System.Collections;
using UnityEngine;

public class PlayerDeathComponentDisabler : MonoBehaviour
{
    private readonly float _coroutineWaitingTime = 1f;

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
        StartCoroutine(Coroutine());
    }

    private IEnumerator Coroutine()
    {
        if (gameObject.TryGetComponent(out PlayerMovement playerMovement))
            playerMovement.enabled = false;
        
        yield return new WaitForSeconds(_coroutineWaitingTime);

        if (gameObject.TryGetComponent(out CapsuleCollider2D capsuleCollider))
            capsuleCollider.enabled = false;
        
        if (gameObject.TryGetComponent(out Rigidbody2D rigidbody))
            rigidbody.bodyType = RigidbodyType2D.Static;
    }
}