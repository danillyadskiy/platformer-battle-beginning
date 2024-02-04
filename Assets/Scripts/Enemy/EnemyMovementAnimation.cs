using UnityEngine;

public class EnemyMovementAnimation : MonoBehaviour
{
    private readonly int IsWalk = Animator.StringToHash(nameof(IsWalk));
    
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyMovement _movement;

    private void Update()
    {
        _animator.SetBool(IsWalk, _movement.Direction != 0);
    }
}
