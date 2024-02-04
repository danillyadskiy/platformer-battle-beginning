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
            _coroutine = Coroutine();
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

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(_coroutineWaitingTime);

        while (true)
        {
            if (_isCoroutineWorking)
            {
                Entered?.Invoke();
            }
            else
            {
                Entered?.Invoke();
                StopCoroutine(_coroutine);
            }
            
            yield return new WaitForSeconds(_coroutineWaitingTime);
        }
    }
}
