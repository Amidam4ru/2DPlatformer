using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
    [SerializeField] private PlayerHealth _playerHealth;
    [SerializeField] private Finish _finish;

    private void OnEnable()
    {
        _playerHealth.Died += Reload;
        _finish.PlayerWon += Pause;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= Reload;
        _finish.PlayerWon -= Pause;
    }

    private void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
    }
}
