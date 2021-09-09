
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportPlate : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 0f;
    public int point;
    private Vector2 asoi;
    public float y;
    public float x;
    bool isPlateMoving = false;
    public float xMax;
    public float xMin;
    public float xMiddle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();


    }
    private void FixedUpdate()
    {
        if (isPlateMoving == true)
        {     /* {
            if (x >= xMiddle && x <= xMax)
            {
                speed -= 0.018f;
                if (speed <= 0)
                {
                    isPlateMoving = false;
                }
            }
            x += 0.1f * speed;
        }
        else*/
            {
                speed += 0.004f;
                x -= 0.1f * speed;
                if (x <= xMin)
                {
                    speed = 0;
                }
            }
        }
        asoi = new Vector2(x, y);
        rb.MovePosition(asoi);
        if (point >= 3)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            isPlateMoving = true;
            if (x <= xMin)
                speed = 0.3f;
            if (x >= xMax)
                speed = 0.3f;
        }
        if (collision.gameObject.tag == "Lava")

            point++;
    }
   
}
