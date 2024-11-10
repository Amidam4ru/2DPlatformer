using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    public event Action Died;

    public int Health => _health;

    private void Die()
    {
        Died?.Invoke();
    }

    public void AddHealth(int numberOfHealth)
    {
        _health += numberOfHealth;
        Debug.Log(_health);
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        Debug.Log(_health);

        if (_health <= 0)
        {
            Die();
        }
    }
}
