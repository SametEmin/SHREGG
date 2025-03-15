using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healAmount = 20; // The amount of health to restore when collected

    // This method will be called when the player collides with the health item
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player collided with the item
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();  // Get the PlayerHealth component

            if (playerHealth != null)  // If the player has a PlayerHealth component
            {
                playerHealth.Heal(healAmount);  // Heal the player
                Destroy(gameObject);  // Destroy the health item after it has been collected
            }
        }
    }
}
