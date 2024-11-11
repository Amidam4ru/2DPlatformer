using UnityEngine;

[RequireComponent(typeof(RegistrationOfPlayerCollisions))]
public class PlayserScore : MonoBehaviour
{
    private int _numberOfPoints;
    private RegistrationOfPlayerCollisions _collector;

    private void Awake()
    {
        _numberOfPoints = 0;
        _collector = GetComponent<RegistrationOfPlayerCollisions>();
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
    }
}
