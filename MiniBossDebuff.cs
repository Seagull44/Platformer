using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class MiniBossDebuff : MonoBehaviour
{
    public float speed;

    public float startWaitTime;
    Rigidbody2D rb;
    public int HPboss;
    private float waitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private int BossObject, DecorObject, EnBulletObject;


    public GameObject weapon1;
    public bool SlovIsActive = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }
    void Update()
    {

        if (SlovIsActive == true)
        {
            StartCoroutine(Clean());
            speed = 4;
        }
        if (SlovIsActive == false)
        {
            speed = 8;
        }

        DecorObject = LayerMask.NameToLayer("Decor");
        BossObject = LayerMask.NameToLayer("Boss");
        EnBulletObject = LayerMask.NameToLayer("EnBullet");

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        Physics2D.IgnoreLayerCollision(BossObject, DecorObject, true);
        Physics2D.IgnoreLayerCollision(BossObject, EnBulletObject, true);
        Physics2D.IgnoreLayerCollision(BossObject, BossObject, true);
    }
    public void TakeDamage(int damage)
    {
        HPboss -= damage;
        if (HPboss <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        theEndDoor.HP++;
        Destroy(gameObject);

        Destroy(weapon1);
        Player.Coins += 150;
    }


    IEnumerator Slow()
    {
        SlovIsActive = true;
        yield return new WaitForSeconds(4f);
        SlovIsActive = false;
    }
    IEnumerator Clean()
    {
        yield return new WaitForSeconds(4f);
        SlovIsActive = false;
    }
    public void StartSlow()
    {
        StartCoroutine(Slow());
    }

    public void Heal()
    {
        HPboss += 5;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Synthetic Ground (92)"))
        {
            rb.AddForce(new Vector2(-4,3), ForceMode2D.Impulse);
        }
    }
     private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Synthetic Ground (92)"))
        {
            rb.AddForce(new Vector2(-4, 3), ForceMode2D.Impulse);
        }

    }
}
