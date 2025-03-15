using UnityEngine;

public class MiniBossFollow : MonoBehaviour
{
    public float speed = 1f; // Slower speed for the mini-boss
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            FindPlayer(); // Keep checking if the player wasn't found at the start
            return;
        }

        // Calculate direction towards the player (normalized to get a unit vector)
        Vector2 direction = (player.position - transform.position).normalized;
        movement = direction * speed; // Slow down the movement speed
    }

    void FixedUpdate()
    {
        // Move the mini-boss slowly toward the player
        rb.linearVelocity = movement; // Adjust using velocity (not linearVelocity)
    }

    void FindPlayer()
    {
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player"); // Look for a GameObject with the "Player" tag
        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
    }
}
