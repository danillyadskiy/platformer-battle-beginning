using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    public event Action Hit;
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Hit?.Invoke();
            HitEnemy();
        }
    }

    // private void OnDrawGizmos()
    // {
    //     float offsetX = _collider.bounds.max.x - _collider.bounds.center.x + _collider.bounds.size.x;
    //     float offsetY = 0;
    //     Vector3 offset = new Vector3(offsetX, offsetY);
    //
    //     Vector3 center = _collider.bounds.center + offset * transform.right.x;
    //     Vector3 size = _collider.bounds.size;
    //     
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawCube(center, size);
    //
    // }

    private void HitEnemy()
    {
        IEnumerable<RaycastHit2D> hits = GetHits();
        MakeDamage(hits);
    }

    private IEnumerable<RaycastHit2D> GetHits()
    {
        float offsetX = _collider.bounds.max.x - _collider.bounds.center.x;
        float offsetY = 0;
        Vector3 offset = new Vector3(offsetX, offsetY);
        
        Vector2 origin = _collider.bounds.center + offset * transform.right.x;
        Vector2 size = _collider.bounds.size;
        Vector2 direction = transform.right;
        float angle = 0;
        float distance = _collider.bounds.size.x;
        
        return Physics2D.BoxCastAll(origin, size, angle, direction, distance);
    }

    private void MakeDamage(IEnumerable<RaycastHit2D> hits)
    {
        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                enemy.GetDamage();
            }
        }
    }
}
