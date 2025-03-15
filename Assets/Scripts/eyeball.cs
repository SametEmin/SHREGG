using UnityEngine;

public class eyeball : MonoBehaviour
{   
    private int value = 25; // The value of the coin, can be used to increase score or currency


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.name);

        // Check if the object that entered the trigger is the player
        if (other.CompareTag("pickuprange"))
        {
            Debug.Log("Player collected the coin!");

            // Call a method to add the coin's value to the player's score or currency
            Player player = other.GetComponentInParent<Player>();
            if (player != null)
            {
                player.Heal(value);
            }
            else
            {
                Debug.Log("Hata Aldın Oyuncu Scripti Yok"); 
            }

            // Optionally, play a sound or animation here

            // Destroy the coin after it is collected
            Destroy(gameObject);
        }
    }
}