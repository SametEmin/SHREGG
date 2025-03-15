using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject coinPrefab;
    public GameObject eyeballPrefab;


    public int coinsToSpawn;
    private int damage = 10;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private Rigidbody2D rb;

    public float knockbackForce = 5f; // The force of the knockback

    private Vector2 lastMoveDirection; // Store the last movement direction

    public bool isKnockback = false;
    public GameObject damagePopupPrefab;

    void Start()
    {
        currentHealth = maxHealth;
        // Randomize the number of coins to spawn
        coinsToSpawn = Random.Range(1, 5);

        rb = GetComponent<Rigidbody2D>();

        Transform childTransform = transform.Find("Square");
        if (childTransform != null)
        {
            spriteRenderer = childTransform.GetComponent<SpriteRenderer>();
            originalColor = spriteRenderer.color;
        }
        else
        {
            Debug.LogError("Child object not found!");
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemy took damage, current health: " + currentHealth);
        isKnockback = true;
        //rb.AddForce(new Vector2(10,10), ForceMode2D.Impulse);

        Vector2 lastMoveDirection = rb.linearVelocity.normalized;
        ApplyKnockback(-lastMoveDirection);
        

        ShowDamageText(damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

     private void ApplyKnockback(Vector2 direction)
    {
        Debug.Log("Knockback not applied!");
        if (rb != null)
        {
            Debug.Log("Knockback applied!");
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
        }
    }

    private void ShowDamageText(int damage)
    {
    // Instantiate the damage popup prefab

        Transform popUpTextTransform = damagePopupPrefab.transform.Find("PopupText");
        if (popUpTextTransform != null)
            {
                
                // Get the Text component of the PopUpText child
                TMP_Text popUpText = popUpTextTransform.GetComponent<TMP_Text>();

                if (popUpText != null)
                {   
                    // Set the text to the damage value
                    popUpTextTransform.GetComponent<TMP_Text>().text = damage.ToString();
                }
                else
                {
                    Debug.LogError("PopUpText does not have a Text component.");
                }
            }
        else
            {
                Debug.LogError("PopUpText child not found.");
            }
        Instantiate(damagePopupPrefab, transform.position, Quaternion.identity); // Set the position and rotation as needed
    

    }

    void Die()
    {
        Debug.Log("Enemy died!");
        // Add death logic here, such as playing an animation or removing the enemy from the scene
        SpawnCoins();
        SpawnEyeball();
        Destroy(gameObject);
    }

    void SpawnCoins()
    {
        for (int i = 0; i < coinsToSpawn; i++)
        {
            
            // Randomize the spawn position slightly around the enemy's position
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
            Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
        }
    }

    void SpawnEyeball()
    {
        // do it random %20
        int random = Random.Range(0, 100);
        if (random < 20)
        {
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
            Instantiate(eyeballPrefab, spawnPosition , Quaternion.identity);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            player.TakeDamage(damage);
            Debug.Log("Enemy den hasar aldık");
        }
    }

    public System.Collections.IEnumerator FlashRed()
    {   
        Debug.Log("Ben senin anano avradını");
        spriteRenderer.color = new Color(1f, 0f, 0f, 0.1f); // Change to red
        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
        spriteRenderer.color = originalColor; // Revert to original color
    }   

    public void FlashRedEffect()
    {
        StartCoroutine(FlashRed());
    }
}