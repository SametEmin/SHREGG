using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float distanceFromPlayer = 1.5f; // Distance of the weapon from the player
    private Vector3 originalScale; // Stores the original scale of the weapon

    void Start()
    {
        originalScale = transform.localScale; // Save the original scale
    }

    void LateUpdate()
    {
        RotateWeaponAroundPlayer();
    }

    void RotateWeaponAroundPlayer()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Ensure the z position is zero for 2D

        // Calculate the direction from the player to the mouse
        Vector3 direction = (mousePosition - player.position).normalized;

        // Calculate the position of the weapon around the player
        Vector3 weaponPosition = player.position + direction * distanceFromPlayer;

        // Update the weapon's position
        transform.position = weaponPosition;

        // Rotate the weapon to face the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Flip the weapon if it's on the left side
        if (mousePosition.x < player.position.x)
        {
            transform.localScale = new Vector3(originalScale.x, -originalScale.y, originalScale.z);
        }
        else
        {
            transform.localScale = originalScale;
        }
    }
}