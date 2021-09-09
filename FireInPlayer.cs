using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireInPlayer : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public float shootingDistance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Unit").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
       transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
             player.TakeDamage(1);
            }
            DestroyBullet();
        }
        
        if (other.CompareTag("Ball"))
        {
            DestroyBullet();
        }
        if (other.CompareTag("Decor"))
        {
            DestroyBullet();
        }
        if (other.CompareTag("Ground"))
        {
            DestroyBullet();
        }

    }

   
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
 }
