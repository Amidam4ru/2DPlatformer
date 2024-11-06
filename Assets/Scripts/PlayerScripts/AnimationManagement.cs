using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ReadingController))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Rigidbody2D))]
public class AnimationManagement : MonoBehaviour
{
    private ReadingController _controller;
    private PlayerMovement _playerMovement;
    private Animator _animator;
    private Rigidbody2D _rigidbody;
    private bool _isFall;

    private void Awake()
    {
        _isFall = false;
        _controller = GetComponent<ReadingController>();
        _playerMovement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _playerMovement.OnFly += ControlFlight;
        _controller.OnMoved += ControlMove;
    }

    private void OnDisable()
    {
        _playerMovement.OnFly -= ControlFlight;
        _controller.OnMoved -= ControlMove;
    }

    private void FixedUpdate()
    {
        _isFall = IsFall();
    }

    private void ControlMove(bool isMove)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsMove, isMove);
    }

    private void ControlFlight(bool isOnPlatform)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsInAir, !isOnPlatform);

        if (isOnPlatform == false)
        {
            if (_isFall == false)
            {
                _animator.SetBool(PlayerAnimatorData.Params.IsFall, false);
            }
            else
            {
                _animator.SetBool(PlayerAnimatorData.Params.IsFall, true);
            }
        }
    }

    private bool IsFall()
    {
        if (_rigidbody.velocity.y > 0)
        {
            return false;
        }
        else 
        {
            return true;
        }
    }
}
