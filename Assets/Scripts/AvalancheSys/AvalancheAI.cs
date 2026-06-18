using UnityEngine;

public class AvalancheAI : MonoBehaviour
{
    public enum State
    {
        Idle,
        Warning,
        Chasing
    }

    public State currentState = State.Idle;

    public Transform player;
    public GameObject snowWallPrefab;

    public float velocityThreshold = 5f;
    public float slowTimeLimit = 3f;

    public float playerTopSpeed = 20f;
    public float aiSpeedMultiplier = 1.1f;

    private Rigidbody playerRB;

    private float slowTimer;
    private GameObject snowWall;


    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();
    }


    void Update()
    {
        float playerSpeed = playerRB.linearVelocity.magnitude;


        switch (currentState)
        {
            case State.Idle:

                if (playerSpeed < velocityThreshold)
                {
                    slowTimer += Time.deltaTime;
                }
                else
                {
                    slowTimer = 0;
                }


                if (slowTimer >= slowTimeLimit)
                {
                    SpawnAvalanche();
                    currentState = State.Chasing;
                }

                break;



            case State.Chasing:

                ChasePlayer();

                break;
        }
    }

    void SpawnAvalanche()
    {
        Vector3 behindPlayer = -player.forward * 30f;

        // Keep the same height as the player
        behindPlayer.y = 0;

        Vector3 spawnPosition = player.position + behindPlayer;

        snowWall = Instantiate(
            snowWallPrefab,
            spawnPosition,
            Quaternion.identity
        );

        Debug.Log("Avalanche spawned behind player");
    }


    void ChasePlayer()
    {
        if (snowWall == null)
            return;

        float speed = playerTopSpeed * aiSpeedMultiplier;

        Vector3 direction = player.position - snowWall.transform.position;

        direction.y = 0; // keeps it on the mountain

        snowWall.transform.position +=
            direction.normalized * speed * Time.deltaTime;
    }
}