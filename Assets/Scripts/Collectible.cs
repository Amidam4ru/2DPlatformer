using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    public abstract int Value { get; }

    public void Remove()
    {
        Destroy(gameObject);
    }
}
