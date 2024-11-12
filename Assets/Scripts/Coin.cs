using UnityEngine;

public class Coin : Collectible
{
    [SerializeField] private int _value = 1;

    public override int Value => _value;
}
