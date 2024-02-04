using UnityEngine;

public class PlayerDeathAnimation : MonoBehaviour
{
    private readonly int Death = Animator.StringToHash(nameof(Death));

    [SerializeField] private Animator _animator;
    [SerializeField] private Player player;

    private void OnEnable()
    {
        player.Dead += SetAnimationDeath;
    }

    private void OnDisable()
    {
        player.Dead -= SetAnimationDeath;
    }

    private void SetAnimationDeath()
    {
        _animator.SetTrigger(Death);
    }
}
