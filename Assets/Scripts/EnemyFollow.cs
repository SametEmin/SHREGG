using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3f;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;

    public float knockbackDuration =0.2f;

    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        FindPlayer();
    }

    void Update()
    {
        if (player == null)
        {
            FindPlayer(); // Keep checking in case the player was not found at start
            return;
        }

        // Calculate direction towards player
        Vector2 direction = (player.position - transform.position).normalized;
        movement = direction * speed;
    }

    void FixedUpdate()
    {
        // Move the enemy
        if (enemy.isKnockback == true){

            StartCoroutine(KnockbackRecovery());
        }
        else{
            rb.linearVelocity = movement;
        }
    }

    void FindPlayer()
    {
        GameObject foundPlayer = GameObject.FindGameObjectWithTag("Player"); // Look for a GameObject with the "Player" tag
        if (foundPlayer != null)
        {
            player = foundPlayer.transform;
        }
    }

    void change_isKnockback(){
        enemy.isKnockback = !enemy.isKnockback;
    }

    private System.Collections.IEnumerator KnockbackRecovery()
    {
        yield return new WaitForSeconds(knockbackDuration);
        change_isKnockback();
    }
}
