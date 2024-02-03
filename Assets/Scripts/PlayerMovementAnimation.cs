using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    private readonly int IsRun = Animator.StringToHash(nameof(IsRun));
    private readonly int IsJump = Animator.StringToHash(nameof(IsJump));
    private readonly int IsFall = Animator.StringToHash(nameof(IsFall));

    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _movement;

    private void Update()
    {
        SetAnimationX();
        SetAnimationY();
    }

    private void SetAnimationX()
    {
        _animator.SetBool(IsRun, _movement.Direction != 0);
    }

    private void SetAnimationY()
    {
        switch (_movement.Rigidbody.velocity.y)
        {
            case > 0:
                _animator.SetBool(IsJump, true);
                _animator.SetBool(IsFall, false);
                break;
            
            case < 0:
                _animator.SetBool(IsJump, false);
                _animator.SetBool(IsFall, true);
                break;
            
            default:
                _animator.SetBool(IsJump, false);
                _animator.SetBool(IsFall, false);
                break;
        }
    }
}
