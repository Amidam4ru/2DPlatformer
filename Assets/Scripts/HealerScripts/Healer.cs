using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Healer : MonoBehaviour
{
    [SerializeField] private int _numberOfHeal = 40;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out Player player))
        {
            player.AddHealth(_numberOfHeal);
            Destroy(gameObject);
        }
    }
}
