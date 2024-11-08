using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.OnDied += Reload;
    }

    private void OnDisable()
    {
        _player.OnDied -= Reload;
    }

    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
