using UnityEngine;

[RequireComponent(typeof(CoinCollector))]
public class PlayserScore : MonoBehaviour
{
    private int _numberOfPoints;
    private CoinCollector _collector;

    private void Awake()
    {
        _numberOfPoints = 0;
        _collector = GetComponent<CoinCollector>();
    }

    private void OnEnable()
    {
        _collector.Coin—ollected += AddScore;
    }

    private void OnDisable()
    {
        _collector.Coin—ollected -= AddScore;
    }

    private void AddScore()
    {
        _numberOfPoints++;
        Debug.Log(_numberOfPoints);
    }
}
