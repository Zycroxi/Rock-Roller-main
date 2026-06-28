using UnityEngine;

public class Coin : MonoBehaviour
{
    public int scoreValue = 1;

    [Header("Sound")]
    public AudioClip coinCollectSound;
    [Range(0f, 1f)]
    public float volume = 1f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            // Add score
            player.CollectItem(scoreValue);

            // Play collection sound
            PlayCollectSound();

            // Destroy the coin
            Destroy(gameObject);
        }
    }

    void PlayCollectSound()
    {
        if (coinCollectSound != null)
        {
            AudioSource.PlayClipAtPoint(
                coinCollectSound,
                transform.position,
                volume
            );
        }
    }
}