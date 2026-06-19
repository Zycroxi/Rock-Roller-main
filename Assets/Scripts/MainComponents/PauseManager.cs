using UnityEngine;
using UnityEngine.SceneManagement; // Required for loading other scenes

public class PauseManager : MonoBehaviour
{
    // Tracks state across other game systems if needed
    public static bool isPaused = false;

    // Reference to the parent UI container object
    [SerializeField] private GameObject pauseMenuUI;

    void Update()
    {
        // Toggles the pause state when hitting the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    private GameObject PausePanel; // Declared at class level

    void Start()
    {
        PausePanel = GameObject.Find("PausePanel"); // Assigned here
    }
    void TogglePause()
    {
        PausePanel.SetActive(true); // Works perfectly!
    }


    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Hide the menu
        Time.timeScale = 1f;          // Reset time speed to normal
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);  // Show the menu
        Time.timeScale = 0f;          // Freeze all physics and time-based actions
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // CRITICAL: Reset time before switching scenes!
        SceneManager.LoadScene("MenuScreen"); // Replace with your exact scene name
    }

    public void QuitGame()
    {
        Debug.Log("Exiting application...");
        Application.Quit(); // Closes the built game application
    }

}
