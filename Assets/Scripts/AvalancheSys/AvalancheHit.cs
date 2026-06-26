using UnityEngine;

public class AvalancheHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<MenuManager>().TriggerDeath();
        }
    }
}