using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private readonly float _movementSpeed = 1.0f;
    
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;

    private Transform _targetPoint;
    
    public float Direction { get; private set; }
    
    private void Start()
    {
        float initialPositionX = _point1.transform.position.x;
        float initialPositionY = transform.position.y;
        
        transform.position = new Vector2(initialPositionX, initialPositionY);
        
        _targetPoint = _point2;
    }

    private void Update()
    {
        ChangeDirection();
        ChangePosition();
    }

    private void ChangeDirection()
    {
        Direction = _targetPoint.transform.position.x - transform.position.x;

        if (Direction > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        
        if (Direction < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void ChangePosition()
    {
        if (transform.position.x == _point1.position.x)
            _targetPoint = _point2;

        else if (transform.position.x == _point2.position.x)
            _targetPoint = _point1;
        
        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.MoveTowards(newPosition.x, _targetPoint.position.x, Time.deltaTime * _movementSpeed);
        transform.position = newPosition;
    }
}
