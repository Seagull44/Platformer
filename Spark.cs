using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class Spark : MonoBehaviour
{
    private int bulletObject, enemyObject, bossObject, SparkObject, GroundObject, decorObject, destroyObject;
    Rigidbody2D rb;
    public float Speed;
    public int random;
    public float ttd;

    void Start()
    {
        bulletObject = LayerMask.NameToLayer("Bullet");
        enemyObject = LayerMask.NameToLayer("Enemy");
        bossObject = LayerMask.NameToLayer("Boss");
        SparkObject = LayerMask.NameToLayer("Spark");
        GroundObject = LayerMask.NameToLayer("Default");
        decorObject = LayerMask.NameToLayer("Decor");
        destroyObject = LayerMask.NameToLayer("Destroyed");

        rb = GetComponent<Rigidbody2D>();
        random = Random.Range(0, 2);
       
        if (random == 1)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            rb.AddForce(new Vector2(2, 7), ForceMode2D.Impulse);
        }
        if (random == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, -90);
            rb.AddForce(new Vector2(-2, 7), ForceMode2D.Impulse);
        }


    }
   void Update()
    {
        Physics2D.IgnoreLayerCollision(SparkObject, bulletObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, enemyObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, bossObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, SparkObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, GroundObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, decorObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, destroyObject, true);
        
       
        

        ttd -= Time.deltaTime;
        if (ttd <= 0)
        {
            Destroy(gameObject);
        }
    }

}
