using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject howToPlayPanel;
    public GameObject creditsPanel;

    // Main menu objects to hide
    public GameObject playButton;
    public GameObject howToPlayButton;
    public GameObject creditsButton;
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

    // Hide the main menu
    void HideMainMenu()
    {
        playButton.SetActive(false);
        howToPlayButton.SetActive(false);
        creditsButton.SetActive(false);
        quitButton.SetActive(false);
        gameNameText.SetActive(false);
    }

    // Show the main menu
    void ShowMainMenu()
    {
        playButton.SetActive(true);
        howToPlayButton.SetActive(true);
        creditsButton.SetActive(true);
        quitButton.SetActive(true);
        gameNameText.SetActive(true);
    }

    // HOW TO PLAY
    public void OpenHowToPlay()
    {
        HideMainMenu();
        howToPlayPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
        ShowMainMenu();
    }

    // CREDITS
    public void OpenCredits()
    {
        HideMainMenu();
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        ShowMainMenu();
    }
}