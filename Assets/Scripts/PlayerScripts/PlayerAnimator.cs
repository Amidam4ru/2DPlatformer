using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Move(bool isMove)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMove, isMove);
    }

    public void ControlFlight(bool isInAir, bool isFall)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsInAir, isInAir);

        _animator.SetBool(PlayerAnimatorData.Params.IsFall, isFall);
    }
}
