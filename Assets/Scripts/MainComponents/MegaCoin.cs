using UnityEngine;

public class MegaCoin : MonoBehaviour
{
    public int scoreValue = 10;

    [Header("Sound")]
    public AudioClip coinCollectSound;
    [Range(0f, 1f)]
    public float volume = 1f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.CollectItem(scoreValue);
            PlayCollectSound();
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
