using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float attackRange = 1f;
    public float attackCooldown = 1.5f;

    private float lastAttackTime;
    private bool facingRight = true;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        lastAttackTime = -attackCooldown;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on the enemy object.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= attackRange && Time.time - lastAttackTime > attackCooldown)
            {
                AttackPlayer();
            }
            else
            {
                // Add your movement logic here
                UpdateFacingDirection(direction);
            }
        }
    }

    void AttackPlayer()
    {
        // Add your attack logic here

        lastAttackTime = Time.time;
    }

    void UpdateFacingDirection(Vector3 direction)
    {
        if (direction.x > 0 && !facingRight)
        {
            facingRight = true;
            // Flip the sprite renderer if needed
            spriteRenderer.flipX = false;
        }
        else if (direction.x < 0 && facingRight)
        {
            facingRight = false;
            // Flip the sprite renderer if needed
            spriteRenderer.flipX = true;
        }
    }
}