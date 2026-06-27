using UnityEngine;

public class SlowObstacle : MonoBehaviour
{
    public int requiredScore = 50;
    public float slowMultiplier = 0.5f;
    public float slowDuration = 3f;

    [Header("Sound")]
    public AudioClip woodBreakSound;
    public float volume = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            // Player is big enough -> play sound then destroy obstacle
            if (player.score >= requiredScore)
            {
                PlayBreakSound();
                Destroy(gameObject);
            }
            // Player is too small -> gets slowed
            else
            {
                player.ApplySlow(slowMultiplier, slowDuration);
            }
        }
    }

    void PlayBreakSound()
    {
        if (woodBreakSound != null)
        {
            AudioSource.PlayClipAtPoint(
                woodBreakSound,
                transform.position,
                volume
            );
        }
    }
}