using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public MenuManager menuManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            menuManager.EndLevel();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu Screen");
    }
}