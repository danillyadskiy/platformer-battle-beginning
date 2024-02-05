using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public event Action Jumped;
    
    private readonly float _jumpForce = 1000.0f;
    private readonly float _gravityScale = 5.0f;
    private readonly float _movementSpeed = 6.0f;
    
    [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }
    
    public float Direction { get; private set; }

    private void Start()
    {
        Rigidbody.gravityScale = _gravityScale;
    }

    private void Update()
    {
        MoveX();
        MoveY();
    }

    private void MoveX()
    {
        Direction = Input.GetAxis("Horizontal");
        
        if (Direction > 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        
        if (Direction < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
        
        float distance = Mathf.Abs(Direction) * _movementSpeed * Time.deltaTime;
        transform.Translate(Vector2.right * distance);
    }

    private void MoveY()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Rigidbody.velocity.y == 0)
        {
            Rigidbody.AddForce(Vector2.up * _jumpForce);
            Jumped?.Invoke();
        }
    }
}
