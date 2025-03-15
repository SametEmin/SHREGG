using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance for easy access
    public int score = 0; // Player's score

    public TextMeshProUGUI scoreText; // Reference to the UI TextMeshPro component

    private void Awake()
    {
        // Singleton pattern to ensure only one ScoreManager instance exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    // Method to add score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText(); // Update the UI text whenever the score changes
    }

    // Method to update the score text on the screen
    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the UI TextMeshPro component with the score
        }
    }
}
