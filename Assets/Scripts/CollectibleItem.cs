using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public string itemName = "Coin";  // The name of the collectible item
    public int scoreValue = 10;       // How much the item is worth in score

    // This method will be called when another object enters the trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        // See what collides with the item
        if (other.CompareTag("Player"))  // Check if the player collided with the item
        {
            Debug.Log("Triggered by: " + other.gameObject.name); 

            // Call the method to add score
            ScoreManager.Instance.AddScore(scoreValue);

            // Optionally, you could add a sound effect or visual effect here

            // Destroy the collectible item after it has been collected
            Destroy(gameObject);
        }
    }
}
