using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayPanel;

    // Main menu objects to hide
    public GameObject playButton;
    public GameObject howToPlayButton;
    public GameObject quitButton;
    public GameObject gameNameText;

    public void PlayGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    public void OpenHowToPlay()
    {
        // Show instructions
        howToPlayPanel.SetActive(true);

        // Hide main menu
        playButton.SetActive(false);
        howToPlayButton.SetActive(false);
        quitButton.SetActive(false);
        gameNameText.SetActive(false);
    }

    public void CloseHowToPlay()
    {
        // Hide instructions
        howToPlayPanel.SetActive(false);

        // Show main menu again
        playButton.SetActive(true);
        howToPlayButton.SetActive(true);
        quitButton.SetActive(true);
        gameNameText.SetActive(true);
    }
}