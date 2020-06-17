using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public float speed = 2f;
    
    public int RMoveDistance;
    public int LMoveDistance;

    

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x >= RMoveDistance )
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
           
        }
        else if (transform.position.x <= LMoveDistance)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
           
        }
    }
    public void  TakeDamage (int damage)
    {
        health -= damage;
        if (health <=0)
        {
            Die();
        }
    }
    void Die ()
    {
        Destroy(gameObject);
        Player.Coins +=10;
    }
}
