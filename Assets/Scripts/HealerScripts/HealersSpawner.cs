using System.Collections.Generic;
using UnityEngine;

public class HealersSpawnerManager : MonoBehaviour
{
    [SerializeField] private List<HealerSpawner> _healerSpawners;
    [SerializeField] private Healer _healerPrefab;
    [SerializeField] private int _numberOfHealer;

    private void OnValidate()
    {
        if (_numberOfHealer > _healerSpawners.Count)
        {
            _numberOfHealer = _healerSpawners.Count;
        }
    }

    private void Start()
    {
        for (int i = 0; i < _numberOfHealer; i++)
        {
            HealerSpawner healerSpawner = _healerSpawners[Random.Range(0, _healerSpawners.Count)];
            Healer newHealer = Instantiate(_healerPrefab, healerSpawner.transform);
            _healerSpawners.Remove(healerSpawner);
        }
    }
}
