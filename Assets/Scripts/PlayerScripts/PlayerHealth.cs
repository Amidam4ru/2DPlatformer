using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _value = 100;
    [SerializeField] private float _maxValue = 100;
    [SerializeField] private float _minValue = 0;

    public event Action Died;

    public float Value => _value;

    public void IncreaseValue(float value)
    {
        if (value > 0)
        {
            _value += value;
            _value = Math.Clamp(_value, _minValue, _maxValue);
            Debug.Log("Жизни: " + _value);
        }
    }

    public void TakeDamage(float damage)
    {
        if (damage < 0)
        {
            _value -= damage;
            _value = Math.Clamp(_value, _minValue, _maxValue);
            Debug.Log("Урон" + _value);

            if (_value == 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
