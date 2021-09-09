using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    private int enemyObject;
    Rigidbody2D rb;
    public float Speed;
    public int random;
    public float i;
    public int x;
    public int health;
    public int LineOfDying;
    void Start()
    {
        health = 8;

        enemyObject = LayerMask.NameToLayer("Enemy");
        x = 1;
        i = 5;
        rb = GetComponent<Rigidbody2D>();
        random = Random.Range(0, 2);
        Physics2D.IgnoreLayerCollision(enemyObject, enemyObject, true);
       

        if (random == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            rb.AddForce(new Vector2(2, 7), ForceMode2D.Impulse);
        }
        if (random == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            rb.AddForce(new Vector2(-2, 7), ForceMode2D.Impulse);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        Physics2D.IgnoreLayerCollision(enemyObject, enemyObject, true);
        if (x ==1)
        {
            Speed = i;
        }
        if (x == 2)
        {
            Speed = 0 - i;
        }
        if (x >=3)
        {
            x = 1;
        }
        if (transform.position.y < LineOfDying)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Player.Coins += 2;
        EnergyVampire.VampiricScore++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Decor")
        {
            x++;
        }

    }

}
