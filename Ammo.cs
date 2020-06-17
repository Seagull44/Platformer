using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public int damage = 1;
    private int bulletObject, playerObject;


    void Start()
    {
        rb.velocity = transform.right * speed;
        bulletObject = LayerMask.NameToLayer("Bullet");
        playerObject = LayerMask.NameToLayer("Player");
    }

    private void Update()
    {
        Physics2D.IgnoreLayerCollision(bulletObject, playerObject , true);
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Enemy enemy = hitinfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
        FlyEnemy flyEnemy = hitinfo.GetComponent<FlyEnemy>();
        if (flyEnemy != null)
        {
            flyEnemy.TakeDamage(damage);
        }
    }
    }
