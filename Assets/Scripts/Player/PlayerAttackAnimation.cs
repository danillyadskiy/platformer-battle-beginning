using UnityEngine;

public class PlayerAttackAnimation : MonoBehaviour
{
    private readonly int Attack = Animator.StringToHash(nameof(Attack));
    
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerAttack _attack;

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
