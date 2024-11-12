using UnityEngine;

public static class PlayerAnimatorData
{
    public static class Params
    {
        public static readonly int IsMove = Animator.StringToHash(nameof(IsMove));
        public static readonly int IsInAir = Animator.StringToHash(nameof(IsInAir));
        public static readonly int IsFall = Animator.StringToHash(nameof(IsFall));
    }
}
