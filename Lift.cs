
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lift : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 0f;
    private float waitTime;
    public float startWaitTime;
    private Vector2 asoi;
    public float y = 30;
    bool isElevatorRising = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
       
    }
        private void FixedUpdate()
    {
        if (isElevatorRising == true)
        {
           if (y >= 45 && y <= 70.5f)
            {
                speed -= 0.005f;
                if (speed <=0)
                {
                   isElevatorRising = false;
                }
            }
            
            y += 0.1f * speed;
        }
        else
        {
            speed += 0.005f;

            y -= 0.1f * speed;
            if (y <= 30f)
            {
                speed = 0;
                isElevatorRising = true;
            }
        }
        asoi = new Vector2(340, y);
        rb.MovePosition(asoi);
    } 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            if (y <=35f )
            speed = 1f; 
        }
    }
}
