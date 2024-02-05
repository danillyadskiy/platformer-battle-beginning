using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public event Action Hit;

    private readonly RaycastHelper _raycastHelper = new RaycastHelper();
    private readonly int _damage = 20;
    
    [SerializeField] private Collider2D _collider;
    [SerializeField] private EnemyAttackTrigger _trigger;

    private void OnEnable()
    {
        _trigger.Entered += HitPlayer;
    }

    private void OnDisable()
    {
        _trigger.Entered -= HitPlayer;
    }

    private void HitPlayer()
    {
        Hit?.Invoke();
        
        IEnumerable<RaycastHit2D> hits = _raycastHelper.GetHits(transform, _collider);

        if (TryGetPlayer(hits, out Player player))
            player.GetDamage(_damage);
    }
    
    private bool TryGetPlayer(IEnumerable<RaycastHit2D> hits, out Player player)
    {
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent(out Player playerLocal))
            {
                player = playerLocal;
                return true;
            }
        }

        player = null;
        return false;
    }
}
