using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 2;
    public float speed = 2f;
    public int RMoveDistance;
    public int LMoveDistance;
    private int enemyObject;

    private void Start()
    {
        
        enemyObject = LayerMask.NameToLayer("Enemy");
    }
    void Update()
    {
        Physics2D.IgnoreLayerCollision(enemyObject, enemyObject, true);
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
        EnergyVampire.VampiricScore ++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            if (Shop.BoostScore >= 2)
                health -= 3;
        }

    }
}
