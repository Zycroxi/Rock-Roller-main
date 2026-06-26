using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    [Header("UI")]
    public GameObject deathPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Pause the game
            Time.timeScale = 0f;

            // Show death panel
            if (deathPanel != null)
            {
                deathPanel.SetActive(true);
            }

            // Unlock mouse cursor for UI interaction
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}