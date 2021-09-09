using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustFall : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 0f;
    private Vector2 asoi;
    public float x;
    public float y;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 0;
    }
    void Update()
    {
        if (speed != 0)
        {
            asoi = new Vector2(x, y);
            rb.MovePosition(asoi);
            y -= 0.1f * speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            speed = 0.1f;
        }
    }
}
