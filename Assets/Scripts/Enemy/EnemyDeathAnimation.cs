using System;
using UnityEngine;

public class EnemyDeathAnimation : MonoBehaviour
{
    private readonly int Death = Animator.StringToHash(nameof(Death));
    
    [SerializeField] private Animator _animator;
    [SerializeField] private Enemy _enemy;

    private void OnEnable()
    {
        _enemy.Dead += SetAnimationDeath;
    }

    private void OnDisable()
    {
        _enemy.Dead -= SetAnimationDeath;
    }

    private void SetAnimationDeath()
    {
        _animator.SetTrigger(Death);
    }
}
