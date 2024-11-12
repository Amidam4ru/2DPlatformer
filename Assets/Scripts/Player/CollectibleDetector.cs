using UnityEngine;

[RequireComponent(typeof(PlayerScore))]
[RequireComponent(typeof(PlayerHealth))]
public class CollectibleDetector : MonoBehaviour
{
    private PlayerScore _playerScore;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerScore = GetComponent<PlayerScore>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Collectible collectible))
        {
            if (collectible is Coin)
            {
                _playerScore.AddScore(collectible.Value);
            }
            else if (collectible is Healer)
            {
                _playerHealth.IncreaseValue(collectible.Value);
            }

            collectible.Remove();
        }
    }
}
