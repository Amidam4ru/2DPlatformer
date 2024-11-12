using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerDetector))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> _targets;
    [SerializeField] private float _speed;
    [SerializeField] private float _acceptableDistance = 0.2f;

    private List<Vector2> _targetsPosition;
    private Vector2 _target;
    private int _targetCounter;
    private Vector2 _direction;
    private SpriteRenderer _spriteRenderer;
    private PlayerDetector _playerDetection;

    private void Awake()
    {
        _targetsPosition = new List<Vector2>();
        SetTargets();
        _target = _targetsPosition[0];
        _targetCounter = 0;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerDetection = GetComponent<PlayerDetector>();
    }

    private void Update()
    {
        if (_playerDetection.PlayerPosition != null)
        {
            Move(_playerDetection.PlayerPosition.position);
        }
        else
        {
            MoveAlongTargets();
        }
    }

    private void ChangeTarget()
    {
        _targetCounter++;

        if (_targetCounter >= _targetsPosition.Count)
        {
            _targetCounter = 0;
        }

        _target = _targetsPosition[_targetCounter];
    }



    private void SetTargets()
    {
        foreach (Transform target in _targets)
        {
            _targetsPosition.Add(target.position);
        }
    }

    private void MoveAlongTargets()
    {
        Move(_target);

        if (Math.Abs(transform.position.x - _target.x) <= _acceptableDistance)
        {
            ChangeTarget();
        }
    }

    private void Move(Vector2 target)
    {
        _direction = (target - new Vector2(transform.position.x, transform.position.y)).normalized;
        transform.position += (Vector3)(_direction * _speed * Time.deltaTime);

        _spriteRenderer.flipX = transform.position.x < target.x;
    }
}
