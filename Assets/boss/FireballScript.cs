using UnityEngine;
using System.Collections;

public class FireballScript : MonoBehaviour
{
    private Animator animator;
    private bool hasCollided = false;
    public int damage = 20;
    public  Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Ensure the player has the correct tag
        {
            rb.linearVelocity = new Vector2(0,0);
            Debug.Log("sssssssssss");
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Debug.Log("ALIVE");
                player.TakeDamage(damage);
            }
            hasCollided = true;
            Destroy(gameObject, 0.1f);      
        }

    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Wait until the animation finishes
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}


