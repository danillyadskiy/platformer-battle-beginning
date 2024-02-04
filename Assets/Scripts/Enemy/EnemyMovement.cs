using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private readonly float _movementSpeed = 1f;
    private readonly float _minDistanceToPlayer = 2f;
    
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
        if (TryDetectPlayer(out Player player))
            Follow(player);
        else
            PatrolArea();
    }

    private bool TryDetectPlayer(out Player player)
    {
        Vector2 origin = _point1.transform.position;
        Vector2 direction = _point2.transform.position - _point1.transform.position;
        
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction);
        
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

    private void Follow(Player player)
    {
        ChangeDirection(player.transform);
        ChangePosition(player);
    }

    private void PatrolArea()
    {
        ChangeDirection(_targetPoint);
        ChangePosition();
    }

    private void ChangeDirection(Transform point)
    {
        Direction = point.position.x - transform.position.x;

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

        ChangePosition(_targetPoint);
    }

    private void ChangePosition(Player player)
    {
        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (distance > _minDistanceToPlayer)
            ChangePosition(player.transform);
        else
            Direction = 0;
    }
    
    private void ChangePosition(Transform point)
    {
        Vector2 newPosition = transform.position;
        newPosition.x = Mathf.MoveTowards(newPosition.x, point.position.x, Time.deltaTime * _movementSpeed);
        transform.position = newPosition;
    }
}
