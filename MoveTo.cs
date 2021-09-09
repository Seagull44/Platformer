using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour
{
    Rigidbody2D rb;
    public bool moving;
    public Transform[] moveSpots;
    public float speed;
    public int i;
    public int iMax;
    public bool boosting;
    private Vector2 target;
    private Vector2 position;
    public float x;
    public float TargetX;
    public float y;
    public float TargetY;
    public Transform platform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        i = 0;
        moving = false;
        boosting = false;
        x = platform.position.x;
        y = platform.position.y;
    }

    // Update is called once per frame
     void  Update()
    {
        position = new Vector2(platform.position.x, platform.position.y);
        
       
       
        if (moving == true)
        {
            if (x < moveSpots[i].position.x)
            {
                x += speed;
            }
            if (x > moveSpots[i].position.x)
            {
                x -= speed;
            }
            if (y < moveSpots[i].position.y)
            {
                y += speed;
            }
            if (y > moveSpots[i].position.y)
            {
                y -= speed;
            }
            target = new Vector2(x, y);
            rb.MovePosition(target);
            /*transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].position, speed * Time.deltaTime);*/

            if (Vector2.Distance(transform.position, moveSpots[i].position) <= 1f)
            {
                i++;
            }
        }
        if (boosting == true)
        {
            speed += 0.0001f;
            if (speed >= 0.007f)
            {
                boosting = false;
            }
        }
        if (i >= iMax)
        {
            speed = 0;
            i = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Unit")
        {
          moving = true;
          boosting = true;
        }
        if (collision.gameObject.tag == "Costume")
        {
            Destroy(gameObject);
        }
    }
}
