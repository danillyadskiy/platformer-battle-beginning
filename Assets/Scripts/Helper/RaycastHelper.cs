using System.Collections.Generic;
using UnityEngine;

public class RaycastHelper
{
    public IEnumerable<RaycastHit2D> GetHits(Transform transform, Collider2D collider)
    {
        float offsetX = collider.bounds.max.x - collider.bounds.center.x;
        float offsetY = 0;
        Vector3 offset = new Vector3(offsetX, offsetY);
        
        Vector2 origin = collider.bounds.center + offset * transform.right.x;
        Vector2 size = collider.bounds.size;
        Vector2 direction = transform.right;
        float angle = 0;
        float distance = collider.bounds.size.x;
        
        return Physics2D.BoxCastAll(origin, size, angle, direction, distance);
    }
}