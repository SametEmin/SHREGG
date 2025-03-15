using System.Collections;
using UnityEngine;

public class DragonBoss2D : MonoBehaviour
{
    public GameObject fireballPrefab; // Assign fireball prefab in Inspector
    public Transform firePoint; // Assign the fireball spawn point
    public float fireballSpeed = 5f;
    public float attackCooldown = 3f;

    private Transform player;
    private bool canAttack = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (canAttack)
        {
            StartCoroutine(AttackPattern());
        }
    }

    IEnumerator AttackPattern()
    {
        canAttack = false;
        int attackType = Random.Range(0, 2); // 0 for sequential, 1 for arc

        if (attackType == 0)
        {
            yield return StartCoroutine(SequentialAttack());
        }
        else
        {
            ArcAttack();
        }

        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator SequentialAttack()
    {
        for (int i = 0; i < 3; i++)
        {
            ShootFireball((player.position - firePoint.position).normalized);
            yield return new WaitForSeconds(0.5f); // Delay between shots
        }
    }

    void ArcAttack()
    {
        float angleStep = 15f;
        float startAngle = -angleStep;

        for (int i = 0; i < 3; i++)
        {
            Vector2 direction = Quaternion.Euler(0, 0, startAngle + (angleStep * i)) * (player.position - firePoint.position).normalized;
            ShootFireball(direction);
        }
    }

    void ShootFireball(Vector2 direction)
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = direction * fireballSpeed;
        }
    }
}
