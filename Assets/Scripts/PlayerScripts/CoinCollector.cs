using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public event Action Coin—ollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Coin coin))
        {
            coin.Remove();
            Coin—ollected?.Invoke();
        }
    }
}
