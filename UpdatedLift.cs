
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedLift : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 0f;
    private float waitTime;
    public float startWaitTime;
    private Vector2 asoi;
    public float y ;
    bool isElevatorRising = true;
    public float yMax;       /* 75 в старому ліфті*/
    public float yMin;          /* 30 в старому ліфті*/
    public float yMiddle;       /*45 */

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;

    }
    private void FixedUpdate()
    {
        if (isElevatorRising == true)
        {
            if (y >= yMiddle && y <= yMax)
            {
                speed -= 0.018f;
                if (speed <= 0)
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
            if (y <= yMin)
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
            if (y <= yMin +5)
                speed = 1f;
        }
    }
}
