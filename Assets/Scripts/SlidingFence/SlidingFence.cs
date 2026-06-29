using UnityEngine;

public class SlidingFence : MonoBehaviour
{
    public Vector3 moveDirection = Vector3.right;
    public float distance = 3f;
    public float speed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offset = Mathf.PingPong(Time.time * speed, distance * 2f) - distance;

        transform.position = startPos + moveDirection.normalized * offset;
    }
}