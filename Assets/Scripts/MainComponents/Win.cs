using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public MenuManager menuManager;

    [Header("Starved UI")]
    public GameObject youStarvedPanel;
    public int requiredScore = 40;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                if (player.score < requiredScore)
                {
                    // Player didn't collect enough food
                    youStarvedPanel.SetActive(true);

                    // Stop movement and sounds
                    player.StopRollingSound();
                    Time.timeScale = 0f;
                }
                else
                {
                    // Player collected enough food
                    menuManager.EndLevel();
                }
            }
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