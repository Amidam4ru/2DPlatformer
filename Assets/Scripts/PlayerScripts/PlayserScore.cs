using UnityEngine;

[RequireComponent(typeof(CoinCollector))]
public class PlayserScore : MonoBehaviour
{
    private int _score;
    private CoinCollector _collector;

    private void Awake()
    {
        _score = 0;
        _collector = GetComponent<CoinCollector>();
    }

    private void OnEnable()
    {
        _collector.OnCoin—ollected += AddScore;
    }

    private void OnDisable()
    {
        _collector.OnCoin—ollected -= AddScore;
    }

    private void AddScore()
    {
        _score++;
        Debug.Log(_score);
    }
}
