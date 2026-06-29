using UnityEngine;

public class RollingBoulder : MonoBehaviour
{
    public float rollForce = 800f;
    public Vector3 rollDirection = Vector3.right;

    private Rigidbody rb;
    private bool activated = false;

    public Vector3 startPosition;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void Start()
    {
        startPosition = transform.position;
    }

    public void Activate()
    {
        if (activated) return;

        activated = true;
        rb.isKinematic = false;
        rb.AddForce(rollDirection.normalized * rollForce);
    }

    public void ResetBoulder()
    {
        activated = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        transform.position = startPosition;
    }
}