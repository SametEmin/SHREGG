using UnityEngine;

public class EnemyFollowAndShoot : MonoBehaviour
{
    public float speed = 3f;
    public float shootingInterval = 1.5f; // Time between shots
    public GameObject projectilePrefab; // Assign the projectile prefab in the Inspector
    public Transform firePoint; // Assign a fire point (empty GameObject) where bullets spawn
    public float projectileSpeed = 5f;

    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float shootTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            FindPlayer();
            return;
        }

        // Move toward player
        Vector2 direction = (player.position - transform.position).normalized;
        movement = direction * speed;

        // Handle shooting
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootingInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void FixedUpdate()
    {
        // Move the enemy
        rb.linearVelocity = movement;
    }

    void FindPlayer()
    {
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player");
        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null) return;

        // Instantiate the projectile at the fire point's position
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        
        // Get the direction towards the player
        Vector2 shootDirection = (player.position - firePoint.position).normalized;
        
        // Apply velocity to the projectile
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        if (projectileRb != null)
        {
             projectileRb.linearVelocity = shootDirection * projectileSpeed;
        }
        Debug.Log(projectile.transform.position);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enemy touched the player!");
            // Example: Reduce player health or destroy the enemy
            
        }
    }
}
