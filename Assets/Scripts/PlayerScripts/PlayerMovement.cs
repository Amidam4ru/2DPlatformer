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
        _controller.OnJumped += Jump;
    }

    private void OnDisable()
    {
        _controller.OnJumped -= Jump;
    }

    private void Update()
    {
        SetRotation();
        _isOnPlatform = IsOnPlatform();

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
        if (_controller.MovementInput > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if (_controller.MovementInput < 0)
        {
            _spriteRenderer.flipX = true;
        }
    }

    private bool IsFall()
    {
        if (_rigidbody.velocity.y < 0) return true; return false;
    }

    private void ManageAnimations()
    {
        if (_isOnPlatform == false)
        {
            _animator.ControlFlight(true, IsFall());
        }
        else
        {
            _animator.ControlFlight(false, IsFall());
        }


        if (_rigidbody.velocity.x != 0)
        {
            _animator.Move(true);
        }
        else
        {
            _animator.Move(false);
        }
    }
}
