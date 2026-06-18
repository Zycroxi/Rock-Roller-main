using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    public Transform resetPoint; // where player will be sent

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = resetPoint.position;

            // Optional: reset velocity if player has Rigidbody
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
}
