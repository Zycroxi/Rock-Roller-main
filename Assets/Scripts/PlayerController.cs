using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;

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

        Debug.Log("Score: " + score);

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