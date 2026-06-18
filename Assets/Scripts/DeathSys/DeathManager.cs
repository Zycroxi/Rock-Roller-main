using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public GameObject deathScreen;

    void Start()
    {
        deathScreen.SetActive(false);
    }

    public void Die()
    {
        deathScreen.SetActive(true);

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}