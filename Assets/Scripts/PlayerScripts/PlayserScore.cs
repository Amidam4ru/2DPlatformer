using UnityEngine;

public class PlayserScore : MonoBehaviour
{
    private int _score;

    private void Awake()
    {
        _score = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Coin coin))
        {
            _score++;
            Destroy(coin.gameObject);
            Debug.Log(_score);
        }
    }
}
