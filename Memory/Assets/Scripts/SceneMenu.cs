using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using UnityEngine.SceneManagement;

public class SceneMenu : MonoBehaviour
{
    [SerializeField] private Pause pause;
    public void ContinueGame()
    {
        gameObject.SetActive(false);
        pause.SetPause();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void MenuGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}