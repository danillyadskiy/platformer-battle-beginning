using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public event Action Hit;
    
    private readonly RaycastHelper _raycastHelper = new RaycastHelper();
    private readonly int _damage = 20;
    
    [SerializeField] private Collider2D _collider;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Hit?.Invoke();
            HitEnemies();
        }
    }

    private void HitEnemies()
    {
        IEnumerable<RaycastHit2D> hits = _raycastHelper.GetHits(transform, _collider);
        MakeDamage(hits);
    }

    private void MakeDamage(IEnumerable<RaycastHit2D> hits)
    {
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                enemy.GetDamage(_damage);
            }
        }
    }
}
