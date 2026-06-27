using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float torqueForce = 500f;

    private Rigidbody rb;
    private float originalTorqueForce;
    private Coroutine slowCoroutine;

    public int score = 0;
    public float growthAmount = 0.1f;

    public TMP_Text scoreText;
    public TMP_Text rankText;

    [Header("Rolling Sound")]
    public AudioSource rollingAudio;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.6f;
    private SphereCollider sphereCollider;

    private bool isGrounded;

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
        sphereCollider = GetComponent<SphereCollider>();

        originalTorqueForce = torqueForce;

        if (scoreText != null)
            scoreText.text = "Score: 0";

        UpdateRank(score);
    }

    public void CollectItem(int value)
    {
        score += value;
        Debug.Log("Score: " + score);

        if (scoreText != null)
            scoreText.text = "Score: " + score;

        // GROW PLAYER
        GrowPlayer();

        UpdateRank(score);
    }

    void GrowPlayer()
    {
        Vector3 newScale = transform.localScale;
        newScale += Vector3.one * growthAmount;
        transform.localScale = newScale;
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
        CheckGround();

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

        // Play rolling sound only while grounded and moving
        if (rollingAudio != null)
        {
            bool isRolling = rb.angularVelocity.magnitude > 0.2f;

            if (isGrounded && isRolling)
            {
                if (!rollingAudio.isPlaying)
                    rollingAudio.Play();
            }
            else
            {
                if (rollingAudio.isPlaying)
                    rollingAudio.Stop();
            }
        }
    }

    public class DeathTrigger : MonoBehaviour
    {
        public MenuManager menuManager;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                menuManager.TriggerDeath();
            }
        }
    }

    public void ApplySlow(float multiplier, float duration)
    {
        if (slowCoroutine != null)
            StopCoroutine(slowCoroutine);

        slowCoroutine = StartCoroutine(SlowCoroutine(multiplier, duration));
    }

    private System.Collections.IEnumerator SlowCoroutine(float multiplier, float duration)
    {
        torqueForce = originalTorqueForce * multiplier;

        yield return new WaitForSeconds(duration);

        torqueForce = originalTorqueForce;
    }

    public string GetCurrentRank()
    {
        string currentRank = "E";

        foreach (var rank in ranks)
        {
            if (score >= rank.requiredScore)
                currentRank = rank.rankName;
        }

        return currentRank;
    }

    void CheckGround()
    {
        float radius = sphereCollider.radius * transform.lossyScale.x;

        isGrounded = Physics.SphereCast(
            transform.position,
            radius * 0.9f,
            Vector3.down,
            out RaycastHit hit,
            radius + 0.1f,
            groundLayer
        );
    }
}