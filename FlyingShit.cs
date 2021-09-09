using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingShit : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    Rigidbody2D rb;
    public int HPboss;
    private float waitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private int BossObject, DecorObject, EnBulletObject, enemyObject;
    public int i;


    void Start()
    {
        randomSpot = 0;
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        i = moveSpots.Length;
        enemyObject = LayerMask.NameToLayer("Enemy");
        DecorObject = LayerMask.NameToLayer("Decor");
        BossObject = LayerMask.NameToLayer("Boss");
        EnBulletObject = LayerMask.NameToLayer("EnBullet");
    }
    void Update()
    {
       

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot ++;
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (randomSpot == i)
        {
            randomSpot = 0;
        }
        Physics2D.IgnoreLayerCollision(BossObject, DecorObject, true);
        Physics2D.IgnoreLayerCollision(enemyObject, EnBulletObject, true);
        Physics2D.IgnoreLayerCollision(BossObject, BossObject, true);
        Physics2D.IgnoreLayerCollision(enemyObject, DecorObject, true);
        Physics2D.IgnoreLayerCollision(enemyObject, enemyObject, true);
    }
    public void TakeDamage(int damage)
    {
        HPboss -= damage;
        if (HPboss <= 0)
        {Die();}
    }
    void Die()
    {
        
        Destroy(gameObject);
        Player.Coins += 150;
        EnergyVampire.VampiricScore++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Synthetic Ground"))
        {rb.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);}
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Synthetic Ground"))
        {rb.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);}
    }
}
