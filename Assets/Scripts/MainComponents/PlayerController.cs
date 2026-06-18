using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float torqueForce = 500f;

    private Rigidbody rb;

    public int score = 0;
    public float growthAmount = 0.1f;

    public TMP_Text scoreText;
    public TMP_Text rankText;

    [System.Serializable]
    public class Rank
    {
        public string rankName;
        public int requiredScore;
    }

    public Rank[] ranks;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (scoreText != null)
            scoreText.text = "Score: 0";

        UpdateRank(score);
    }

    public void CollectItem()
    {
        score++;

        transform.localScale += Vector3.one * growthAmount;

        if (scoreText != null)
            scoreText.text = "Score: " + score;

        UpdateRank(score);
    }

    void UpdateRank(int score)
    {
        string currentRank = "E";

        foreach (var rank in ranks)
        {
            if (score >= rank.requiredScore)
                currentRank = rank.rankName;
        }

        if (rankText != null)
            rankText.text = "Rank: " + currentRank;
    }

    void FixedUpdate()
    {
        Vector3 torque = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            torque += Vector3.right;

        if (Input.GetKey(KeyCode.S))
            torque += Vector3.left;

        if (Input.GetKey(KeyCode.A))
            torque += Vector3.forward;

        if (Input.GetKey(KeyCode.D))
            torque += Vector3.back;

        rb.AddTorque(torque * torqueForce);

        rb.angularVelocity = Vector3.ClampMagnitude(rb.angularVelocity, 10f);
    }

    public DeathManager deathManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death"))
        {
            deathManager.Die();
        }
    }
}