using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReadingController : MonoBehaviour
{
    private PlayerController _controller;
    private float _movementInput;

    public event Action Jumped;
    public event Action<bool> Moved;

    public float MovementInput => _movementInput;

    private void Awake()
    {
        _controller = new PlayerController();
    }

    private void OnEnable()
    {
        _controller.Movement.Enable();

        _controller.Movement.Move.performed += OnMove;
        _controller.Movement.Move.canceled += OnMove;

        _controller.Movement.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        _controller.Movement.Move.performed -= OnMove;
        _controller.Movement.Move.canceled -= OnMove;

        _controller.Movement.Jump.performed -= OnJump;

        _controller.Movement.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        _movementInput = context.ReadValue<float>();

        Moved?.Invoke(context.performed);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Jumped?.Invoke();
    }
}
