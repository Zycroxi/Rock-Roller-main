using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Global access states for player/enemy scripts to check
    public static bool isPaused = false;
    public static bool isDead = false;

    [Header("UI Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject deathPanel;

    [Header("Scene Settings")]
    [SerializeField] private string mainMenuSceneName = "MainMenuScene";

    void Start()
    {
        // Force clean state at level start
        isPaused = false;
        isDead = false;
        Time.timeScale = 1f;

        if (pausePanel != null) pausePanel.SetActive(false);
        if (deathPanel != null) deathPanel.SetActive(false);

        LockCursor();
    }

    void Update()
    {
        // Block pausing entirely if the player is already dead
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // --- PAUSE MENU FUNCTIONS ---
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (pausePanel != null) pausePanel.SetActive(true);
        UnlockCursor();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (pausePanel != null) pausePanel.SetActive(false);
        LockCursor();
    }

    // --- DEATH SCREEN FUNCTIONS ---
    // Call this function from your Player Health / Damage scripts when HP hits 0
    public void TriggerDeath()
    {
        isDead = true;
        Time.timeScale = 0f; // Freeze gameplay on death

        if (pausePanel != null) pausePanel.SetActive(false); // Close pause menu if open
        if (deathPanel != null) deathPanel.SetActive(true);  // Show death screen

        UnlockCursor();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        isPaused = false;
        isDead = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Exiting Game...");
        Application.Quit();
    }

    // --- CURSOR HELPERS ---
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
