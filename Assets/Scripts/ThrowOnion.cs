using UnityEngine;

public class OnionThrower : MonoBehaviour
{
    public GameObject onionPrefab; // Reference to the Onion prefab
    float throwForce = 7f; // Force applied to the Onion
    public float cooldownTime = 1f; // Cooldown between throws
    private float currentCooldown; // Tracks the remaining cooldown time

    void Update()
    {
        // Reduce the cooldown timer by the time passed since the last frame
     
        currentCooldown -= Time.deltaTime;
        Debug.Log(currentCooldown);

        // Check if the left mouse button is clicked and cooldown is ready
        if (Input.GetMouseButtonDown(0) && currentCooldown <= 0)
        {
            ThrowOnion();
            currentCooldown = cooldownTime; // Reset the cooldown timer
        }
    }

    void ThrowOnion()
    {
        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z-coordinate is 0 for 2D

        // Calculate the direction from the character to the mouse position
        Vector2 throwDirection = (mousePosition - transform.position).normalized;

        // Instantiate the Onion prefab at the character's position
        GameObject onion = Instantiate(onionPrefab, transform.position, Quaternion.identity);

        // Apply force to the Onion in the calculated direction
        Rigidbody2D onionRb = onion.GetComponent<Rigidbody2D>();
        if (onionRb != null)
        {
            onionRb.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
        }
        else
        {
            Debug.LogError("Onion prefab is missing a Rigidbody2D component!");
        }
    }
}