using UnityEngine;
using TMPro;  // If you're using TextMeshPro for UI

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health the player can have
    public int currentHealth;   // Current health of the player

    public TextMeshProUGUI healthText;  // Reference to the health text in the UI

    private void Start()
    {
        currentHealth = maxHealth;  // Set current health to max at the start of the game
        UpdateHealthText();         // Update the health UI initially
    }

    // Method to take damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0; // Ensure health doesn't go below zero
        }
        
        UpdateHealthText(); // Update the UI when health changes

        if (currentHealth == 0)
        {
            Die();  // If health reaches zero, trigger death
        }
    }

    // Method to heal the player (optional)
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Ensure health doesn't go above max
        }

        UpdateHealthText();  // Update the UI when health changes
    }

    // Method to update the health display text in the UI
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;  // Update UI text to show current health
        }
    }

    // Method to handle death (e.g., end game or respawn)
    private void Die()
    {
        Debug.Log("Player died!");
        // Here you can handle player death, like restarting the level or displaying a game over screen
        // You can also add a respawn mechanic or trigger animations for death
    }
}
