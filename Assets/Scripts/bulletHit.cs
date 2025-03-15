using UnityEngine;

public class bulletHit : MonoBehaviour
{
    public int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if the collided object has a specific component/script
            Player otherScript = other.GetComponent<Player>();

            if (otherScript != null)
            {
                // Call a function from the other script
                otherScript.TakeDamage(damage);
            }
            
            Destroy(gameObject);
        }
    }
}
