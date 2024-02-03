using System;
using UnityEngine;

public class PlayerMovementAnimation : MonoBehaviour
{
    private readonly int IsRun = Animator.StringToHash(nameof(IsRun));
    private readonly int IsFall = Animator.StringToHash(nameof(IsFall));
    private readonly int Jump = Animator.StringToHash(nameof(Jump));


    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMovement _movement;

    private void OnEnable()
    {
        _movement.Jumped += SetAnimationJump;
    }

    private void OnDisable()
    {
        _movement.Jumped -= SetAnimationJump;
    }

    private void Update()
    {
        SetAnimationRun();
        SetAnimationFall();
    }

    private void SetAnimationRun()
    {
        _animator.SetBool(IsRun, _movement.Direction != 0);
    }

    private void SetAnimationFall()
    {
        _animator.SetBool(IsFall, _movement.Rigidbody.velocity.y < 0);
    }
    
    private void SetAnimationJump()
    {
        _animator.SetTrigger(Jump);
    }
}
