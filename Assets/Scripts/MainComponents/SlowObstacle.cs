using UnityEngine;

public class SlowObstacle : MonoBehaviour
{
    public int requiredScore = 50;
    public float slowMultiplier = 0.5f;
    public float slowDuration = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            // Player is big enough -> destroy obstacle
            if (player.score >= requiredScore)
            {
                Destroy(gameObject);
            }
            // Player is too small -> gets slowed
            else
            {
                player.ApplySlow(slowMultiplier, slowDuration);
            }
        }
    }
}