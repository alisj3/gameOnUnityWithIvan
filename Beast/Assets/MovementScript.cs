using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = true;
    public Animator animator; // Добавляем "Аниматора"

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck ;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            float jumpVelocity = 7f;
            rb.velocity = Vector2.up * jumpVelocity;
            animator.SetBool("Jumping", true); // Задаём параметру анимации Jumping значение true
        }

        if (rb.velocity.y < 0)
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", true);
        }

        if (rb.velocity.y == 0)
        {
            animator.SetBool("Falling", false);
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal)); // Задаём параметру анимации Speed значение больше 0 

        Flip();
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jumping", false); // Задаём параметру анимации Jumping значение false
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}