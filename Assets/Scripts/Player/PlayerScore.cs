using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    private int _numberOfPoints;

    private void Awake()
    {
        _numberOfPoints = 0;
    }

    public void AddScore(int numberOfPoints)
    {
        _numberOfPoints += numberOfPoints;
    }
}
