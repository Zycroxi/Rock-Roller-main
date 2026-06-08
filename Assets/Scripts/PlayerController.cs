using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;
    private Rigidbody rb;

    public int score = 0;
    public float growthAmount = 0.1f;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (scoreText != null)
        {
            scoreText.text = "Score: 0";
        }
    }

    public void CollectItem()
    {
        score++;

        // Increase size
        transform.localScale += Vector3.one * growthAmount;

        Debug.Log("Score: " + score);

        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    void FixedUpdate()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            move += Vector3.forward;

        if (Input.GetKey(KeyCode.S))
            move += Vector3.back;

        if (Input.GetKey(KeyCode.A))
            move += Vector3.left;

        if (Input.GetKey(KeyCode.D))
            move += Vector3.right;

        rb.AddForce(move.normalized * moveForce, ForceMode.Force);
    }
}