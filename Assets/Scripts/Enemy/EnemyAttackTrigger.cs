using System;
using System.Collections;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public event Action Entered;

    private readonly float _coroutineWaitingTime = 1f;
    
    private IEnumerator _coroutine;
    private bool _isCoroutineWorking;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _isCoroutineWorking = true;
            _coroutine = Coroutine(player);
            StartCoroutine(_coroutine);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _isCoroutineWorking = false;
        }
    }

    private IEnumerator Coroutine(Player player)
    {
        yield return new WaitForSeconds(_coroutineWaitingTime);

        while (player.IsAlive)
        {
            Entered?.Invoke();
            
            if (!_isCoroutineWorking)
            {
                StopCoroutine(_coroutine);
            }

            yield return new WaitForSeconds(_coroutineWaitingTime);
        }
    }
}
