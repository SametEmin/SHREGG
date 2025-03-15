using UnityEngine;
using System.Collections;
public class Coin : MonoBehaviour
{
    public int value = 1; // The value of the coin, can be used to increase score or currency
    public float moveSpeed = 5f;  // Speed at which the coin moves toward the player
    public float collectDistance = 0.5f; // Distance when the coin should be considered collected
    public GameObject coinParticleEffect; // Optional: Coin particle effect when collected
    private bool isCollecting = false;  // Flag to know when the coin is collecting
    private Transform player; // Reference to the player object

    void Start()
    {
        // Find the player by tag (assuming the player has the "Player" tag)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isCollecting)
        {
            // Move the coin toward the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

            // Optionally, rotate the coin while it moves toward the player
            transform.Rotate(0, 100 * Time.deltaTime, 0);

            // Check if the coin is close enough to the player
            if (Vector3.Distance(transform.position, player.position) <= collectDistance)
            {
                CollectCoin();
            }
        }
    }

    public void Collect()
    {
        isCollecting = true; // Start the collecting animation
    }

    private void CollectCoin()
    {
        // Play particle effect (optional)
        if (coinParticleEffect != null)
        {
            Instantiate(coinParticleEffect, transform.position, Quaternion.identity);
        }

        // Optionally, you can scale the coin down for a disappearing effect
        // We could make it shrink
        StartCoroutine(ShrinkAndDestroy());

        // Optionally, add the coin's value to the player's score
        Player playerScript = player.GetComponent<Player>();
        if (playerScript != null)
        {
            playerScript.AddCoins(value);
        }

        // Destroy the coin object after it's collected
        Destroy(gameObject);
    }

    IEnumerator ShrinkAndDestroy()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = Vector3.zero;

        float elapsedTime = 0f;
        float duration = 0.5f; // Duration for shrinking

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("pickuprange"))
        {
            Debug.Log("Player is within pickup range!");

            // Start the coin collecting animation when the player is close enough
            Collect();

            // Optionally, you can play a sound effect here as well.
            // AudioSource.PlayClipAtPoint(collectSound, transform.position);
        }
    }
}
