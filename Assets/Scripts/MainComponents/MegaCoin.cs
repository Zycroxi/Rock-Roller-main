using UnityEngine;

public class MegaCoin : MonoBehaviour
{
    public int scoreValue = 10;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();

        if (player != null)
        {
            player.CollectItem(scoreValue);
            Destroy(gameObject);
        }
    }

}
