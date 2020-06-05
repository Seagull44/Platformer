using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float horisontalSpeed;
    float speedX;
    public float verticalImpulse;
    Rigidbody2D rb;
    bool isGrounded;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            speedX = -horisontalSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horisontalSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Ground")

            isGrounded = true;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")

            isGrounded = false;

    }
}
