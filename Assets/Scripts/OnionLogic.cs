using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int damage = 100 ; // Damage dealt to the enemy

    private void OnTriggerEnter2D(Collider2D collision) // Use OnCollisionEnter for 3D
    {
        // Check if the collided object has an "Enemy" tag or an Enemy component
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Try to get the Enemy component from the collided object
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Call the TakeDamage function on the enemy
                enemy.TakeDamage(damage);
            }

            // Destroy the Onion after hitting the enemy
        }
    }
}
