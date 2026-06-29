using UnityEngine;

public class BoulderTrigger : MonoBehaviour
{
    public GameObject boulders; // Parent containing all RollingBoulder objects

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            RollingBoulder[] rollingBoulders = boulders.GetComponentsInChildren<RollingBoulder>();

            foreach (RollingBoulder boulder in rollingBoulders)
            {
                boulder.Activate();
            }
        }
    }
}