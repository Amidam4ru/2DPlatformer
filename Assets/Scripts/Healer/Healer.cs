using UnityEngine;

public class Healer : Collectible
{
    [SerializeField] private int _value = 40;
    
    public override int Value => _value;
}
