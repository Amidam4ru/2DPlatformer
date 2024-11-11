using System;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class RegistrationOfPlayerCollisions : MonoBehaviour
{
    public event Action Coin—ollected;

    private PlayerHealth _player;

    private void Awake()
    {
        _player = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CheckForCollisionWithCoin(collision);
        CheckForCollisionWithHealer(collision);
    }

    private void CheckForCollisionWithCoin(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Coin coin))
        {
            coin.Remove();
            Coin—ollected?.Invoke();
        }
    }

    private void CheckForCollisionWithHealer(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Healer healer))
        {
            _player.IncreaseValue(healer.NumberOfHeal);
            healer.Remove();
        }
    }
}
