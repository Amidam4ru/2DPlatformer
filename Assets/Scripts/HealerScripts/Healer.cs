using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Healer : MonoBehaviour
{
    [SerializeField] private int _numberOfHeal = 40;
    
    public int NumberOfHeal => _numberOfHeal;

    public void Remove()
    {
        Destroy(gameObject);
    }
}
