using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action OnDied;

    public void Die()
    {
        OnDied?.Invoke();
    }
}
