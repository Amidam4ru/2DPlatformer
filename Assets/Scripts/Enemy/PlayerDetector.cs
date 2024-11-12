using System.Collections;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float _playerCheckLength;

    private Transform _playerPosition;
    private Vector2[] _raysDirections;
    private bool _isPlayerDetected;
    private Coroutine _playerDetectCorutine;
    private WaitForEndOfFrame _waitForEndOfFrame;

    public Transform PlayerPosition => _playerPosition;

    private void Awake()
    {
        _raysDirections = new Vector2[2] {Vector2.right, Vector2.left };
        _isPlayerDetected = false;
        _waitForEndOfFrame = new WaitForEndOfFrame();
    }

    private void Start()
    {
        _playerDetectCorutine = StartCoroutine(DetectPlayer());
    }

    private IEnumerator DetectPlayer()
    {
        while (true)
        {
            _isPlayerDetected = false;

            foreach (Vector2 direction in _raysDirections)
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, _playerCheckLength);
                Debug.DrawLine(transform.position, new Vector2(transform.position.x, transform.position.y) + direction * _playerCheckLength, Color.red);

                foreach (RaycastHit2D hit in hits)
                {
                    if (hit.collider != null && hit.collider.TryGetComponent(out Player player))
                    {
                        _playerPosition = player.transform;
                        _isPlayerDetected = true;

                        break;
                    }
                }

                if (_isPlayerDetected)
                    break;
            }

            if (_isPlayerDetected == false)
            {
                _playerPosition = null;
            }

            yield return _waitForEndOfFrame;
        }
    }
}
