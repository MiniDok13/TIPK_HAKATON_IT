using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public int maxJumps = 2;

    private int jumpsRemaining;
    private bool isGrounded;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the player object!");
        }
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        if (rb == null) return;

        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0 && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpsRemaining--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
        jumpsRemaining = maxJumps;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}


public class ScriptPlayer : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье игрока
    private int currentHealth; // Текущее здоровье игрока

    void Start()
    {
        currentHealth = maxHealth; // Инициализация текущего здоровья
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Уменьшаем здоровье игрока на значение урона
        
        if (currentHealth <= 0)
        {
            Die(); // Вызываем метод для обработки смерти игрока
        }
    }

    void Die()
    {
        Debug.Log("Игрок умер!"); // Для тестирования, замените на соответствующую логику смерти игрока
        // Дополнительная логика при смерти игрока, например перезапуск уровня или другие действия
    }
}
