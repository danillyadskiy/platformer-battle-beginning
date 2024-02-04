using UnityEngine;

public class EnemyAttackAnimation : MonoBehaviour
{
    private readonly int Attack = Animator.StringToHash(nameof(Attack));
    
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyAttack _attack;

    private void OnEnable()
    {
        _attack.Hit += SetAnimationAttack;
    }

    private void OnDisable()
    {
        _attack.Hit -= SetAnimationAttack;
    }

    private void SetAnimationAttack()
    {
        _animator.SetTrigger(Attack);
    }
}
