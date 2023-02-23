using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private bool isFacingRight = true;
    private bool inAir; // Статус inAir для проверки, находится ли персонаж в воздухе

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck ;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !inAir)
        {
            float jumpVelocity = 7f;
            rb.velocity = Vector2.up * jumpVelocity;
            inAir = true; // Меняет статус inAir, чтобы персонаж не прыгал в воздухе
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) // Если персонаж на земле, то статус inAir меняется
        {
            inAir = false;
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