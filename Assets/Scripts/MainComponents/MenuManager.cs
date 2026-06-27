using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Global access states for player/enemy scripts to check
    public static bool isPaused = false;
    public static bool isDead = false;
    private bool gameEnded = false;

    [Header("Player")]
    [SerializeField] private PlayerController player;

    [Header("Win UI Text")]
    [SerializeField] private TMPro.TMP_Text winScoreText;
    [SerializeField] private TMPro.TMP_Text winRankText;

    [Header("UI Panels")]
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject winPanel;

    [Header("Win Settings")]
    [SerializeField] private int playerScore = 0;
    [SerializeField] private int winningScore = 40;

    [Header("Scene Settings")]
    [SerializeField] private string mainMenuSceneName = "MainMenuScene";

    void Start()
    {
        isPaused = false;
        isDead = false;
        gameEnded = false;

        Time.timeScale = 1f;

        if (pausePanel != null) pausePanel.SetActive(false);
        if (deathPanel != null) deathPanel.SetActive(false);
        if (winPanel != null) winPanel.SetActive(false);

        LockCursor();
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // Call this whenever the player earns points
    public void AddScore(int amount)
    {
        playerScore += amount;
        Debug.Log("Score: " + playerScore);
    }

    // Call this when the level ends
    public void EndLevel()
    {
        if (gameEnded) return;
        gameEnded = true;

        Time.timeScale = 0f;
        UnlockCursor();

        int finalScore = player.score;
        string finalRank = player.GetCurrentRank();

        if (finalScore >= winningScore)
        {
            winPanel.SetActive(true);

            if (winScoreText != null)
                winScoreText.text = "Final Score: " + finalScore;

            if (winRankText != null)
                winRankText.text = "Rank: " + finalRank;
        }
        else
        {
            deathPanel.SetActive(true);
        }
    }

    // --- PAUSE MENU FUNCTIONS ---
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;

        PauseAllAudio();

        if (pausePanel != null)
            pausePanel.SetActive(true);

        UnlockCursor();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;

        ResumeAllAudio();

        if (pausePanel != null)
            pausePanel.SetActive(false);

        LockCursor();
    }

    // --- LOSE SCREEN ---
    public void TriggerDeath()
    {
        if (gameEnded) return;
        gameEnded = true;

        isDead = true;
        Time.timeScale = 0f;

        deathPanel.SetActive(true);
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

    private void PauseAllAudio()
    {
        AudioSource[] allAudio = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

        foreach (AudioSource audioSource in allAudio)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Pause();
            }
        }
    }

    private void ResumeAllAudio()
    {
        AudioSource[] allAudio = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

        foreach (AudioSource audioSource in allAudio)
        {
            audioSource.UnPause();
        }
    }
}