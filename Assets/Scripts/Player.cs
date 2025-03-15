using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int damage = 50; // Damage dealt by the player
    public float speed = 5f; // Movement speed of the player
    public float range = 1.5f; // Attack range of the player
    public int armor = 5; // Armor reduces incoming damage
    public float attackCooldown = 0f; // Time between attacks
    public int coins = 0; // Currency or score collected by the player

    public bool isMoving = false;

    public Animator animator; // Reference to the Animator component for attack animation

    private Animator childAnimator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }



    void Attack(Enemy enemy)
    {
        // Play attack animation
        if (animator != null)
        {
            animator.SetTrigger("Attack");
        }
    }

    public void TakeDamage(int incomingDamage)
    {
        int damageTaken = Mathf.Max(incomingDamage - armor, 0);
        currentHealth -= damageTaken;
        Debug.Log("Player took damage, current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player died!");
        // Add death logic here, such as triggering a game over screen
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        Debug.Log("Player healed, current health: " + currentHealth);
    }

    public void ModifyDamage(int amount)
    {
        damage += amount;
        Debug.Log("Player damage modified, current damage: " + damage);
    }

    public void ModifySpeed(float amount)
    {
        speed += amount;
        Debug.Log("Player speed modified, current speed: " + speed);
    }

    public void ModifyRange(float amount)
    {
        range += amount;
        Debug.Log("Player range modified, current range: " + range);
    }

    public void ModifyArmor(int amount)
    {
        armor += amount;
        Debug.Log("Player armor modified, current armor: " + armor);
    }

    public void ModifyAttackCooldown(float amount)
    {
        attackCooldown += amount;
        Debug.Log("Player attack cooldown modified, current range: " + attackCooldown);
    }

    public void ModifyMaxHealth(int amount)
    {
        maxHealth += amount;
        Debug.Log("Player health modified, current health: " + maxHealth);
    }
    // Optional: Visualize the attack range in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    public void AddCoins(int value)
    {
        // Add the coin's value to the player's score or currency
        coins += value;
        Debug.Log("Player collected " + value + " coins, total coins: " + coins);
    }
}