using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private bool isFacibgRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck ;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 7f;
            rb.velocity = Vector2.up * jumpVelocity;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private void Flip()
    {
        if(isFacibgRight && horizontal < 0f || !isFacibgRight && horizontal > 0f)
        {
            isFacibgRight = !isFacibgRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
