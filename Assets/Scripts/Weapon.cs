using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Player player;
    private Animator playerAnim;

    void Start()
    {
        if (player != null)
        {
            playerAnim = GetComponent<Animator>();
            if (playerAnim == null)
            {
                Debug.LogError("Animator component not found on the player!");
            }
        }
        else
        {
            Debug.LogError("Player reference is not assigned!");
        }
    }

    void Update(){
        // Check if the player is attacking
        // then activate the sword collision box
        if (playerAnim.GetBool("sword_swinging"))
        {
            GetComponent<BoxCollider2D>().enabled = true;
        }
        if(playerAnim.GetBool("animation_end"))
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision object is tagged as "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            Debug.Log("Collided with an enemy!");

            enemy.TakeDamage(player.damage);
            enemy.FlashRedEffect();
            Debug.Log("Enemy hit!");
        
    }
}
}