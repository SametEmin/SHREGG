using UnityEngine;

public class TorchLogic : MonoBehaviour
{
    public int damage = 1; // Damage dealt to the enemy
    public float rotationSpeed = 720f; // Speed of rotation in degrees per second
    public float rotationDuration = 0.5f; // How long the weapon rotates
    public float attackCooldown = 1f; // Cooldown between attacks

    private Transform player; // Reference to the player's transform
    private bool isAttacking = false; // Whether the weapon is currently attacking
    private float cooldownTimer = 0f; // Timer for attack cooldown

    private void Start()
    {
        // Find the player GameObject and get its transform
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Set the weapon's initial position relative to the player
        transform.position = player.position + new Vector3(1, 0, 0); // Adjust offset as needed
    }

    private void Update()
    {
        // Handle cooldown
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }

        // Check for attack input and cooldown
        if (Input.GetMouseButtonDown(0) && cooldownTimer <= 0)
        {
            StartAttack();
        }

        // Rotate the weapon around the player if attacking
        if (isAttacking)
        {
            transform.RotateAround(player.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    private void StartAttack()
    {
        isAttacking = true;
        cooldownTimer = attackCooldown; // Start cooldown
        Invoke("EndAttack", rotationDuration); // Stop attacking after rotationDuration
    }

    private void EndAttack()
    {
        isAttacking = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) // Use OnTriggerEnter for 3D
    {
        // Check if the collided object has an "Enemy" tag or an Enemy component
        if (collision.CompareTag("Enemy"))
        {
            // Try to get the Enemy component from the collided object
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                // Call the TakeDamage function on the enemy
                enemy.TakeDamage(damage);
                enemy.FlashRedEffect(); // Optional: Flash red when hit
            }
        }
    }
}