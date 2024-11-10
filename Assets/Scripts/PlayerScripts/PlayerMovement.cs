using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ReadingController))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerAnimator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _platformCheck;
    [SerializeField] private float _platformCheckLength = 0.2f;

    private ReadingController _controller;
    private Rigidbody2D _rigidbody;
    private bool _isOnPlatform;
    private SpriteRenderer _spriteRenderer;
    private PlayerAnimator _animator;

    private void Awake()
    {
        _isOnPlatform = false;
        _rigidbody = GetComponent<Rigidbody2D>();
        _controller = GetComponent<ReadingController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<PlayerAnimator>();
    }

    private void OnEnable()
    {
        _controller.Jumped += Jump;
    }

    private void OnDisable()
    {
        _controller.Jumped -= Jump;
    }

    private void Update()
    {
        _isOnPlatform = IsOnPlatform();
        SetRotation();
        ManageAnimations();
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_controller.MovementInput * _speed, _rigidbody.velocity.y);
    }

    private void Jump()
    {
        if (_isOnPlatform == true)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }

    private bool IsOnPlatform()
    {
        RaycastHit2D hit = Physics2D.Raycast(_platformCheck.position, Vector2.down, _platformCheckLength);

        if (hit.collider != null && hit.collider.TryGetComponent(out Platform platform))
        {
            return true;
        }

        return false;
    }

    private void SetRotation()
    {
        if (_controller.MovementInput != 0)
        {
            _spriteRenderer.flipX = _controller.MovementInput < 0;
        }
    }

    private bool IsFall()
    {
        return _rigidbody.velocity.y < 0;
    }

    private void ManageAnimations()
    {
        _animator.ControlFlight(!_isOnPlatform, IsFall());

        _animator.Move(_rigidbody.velocity.x != 0);
    }
}
