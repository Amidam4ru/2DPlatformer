using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Finish _finish;

    private void OnEnable()
    {
        _player.Died += Reload;
        _finish.PlayerWon += Pause;
    }

    private void OnDisable()
    {
        _player.Died -= Reload;
        _finish.PlayerWon -= Pause;
    }

    private void Reload()
    {
        Debug.ClearDeveloperConsole();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }
}
