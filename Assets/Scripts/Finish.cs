using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Finish : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            Debug.Log("Win");
            Time.timeScale = 0f;
        }
    }
}
