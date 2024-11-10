using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action Died;

    public void Die()
    {
        Died?.Invoke();
    }
}
