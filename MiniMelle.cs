using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMelle : MonoBehaviour
{
    public int health;
    public float speed;
    public float Xplus;
    public float Xminus;
    public float Yplus;
    public float Yminus;
    public float Xmiddle;
    private float waitTime;
    public float startWaitTime;
    public int RMoveDistance;
    public int LMoveDistance;
    private int enemyObject, bossObj;
    Rigidbody2D rb;
    public bool patrol;
    public bool jump;
    public Transform MS1, MS2;
    public Transform player;
    private Vector2 target;
    public GameObject TheTrapDor;
   
    private void Start()
    {
       
        enemyObject = LayerMask.NameToLayer("Enemy");
        bossObj = LayerMask.NameToLayer("Boss");
        rb = GetComponent<Rigidbody2D>();
        patrol = true;
        jump = false;
        waitTime = startWaitTime;
        player = GameObject.FindGameObjectWithTag("Unit").transform;
    }
    void Update()
    {  
        target = new Vector2(player.position.x, player.position.y);
        Physics2D.IgnoreLayerCollision(bossObj, enemyObject, true);
        Physics2D.IgnoreLayerCollision(bossObj, bossObj, true);
        if (patrol == true)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                patrol = false;
            }
            if (jump == false)
            {
                speed = 7;
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if (jump == true && transform.position.x > Xmiddle)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                transform.position = Vector2.MoveTowards(transform.position, MS1.position, (speed * 3) * Time.deltaTime);
                StartCoroutine(StopFlying());
            }
            if (jump == true && transform.position.x < Xmiddle)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                transform.position = Vector2.MoveTowards(transform.position, MS2.position, (speed * 3) * Time.deltaTime);
                StartCoroutine(StopFlying());
            }
            if (transform.position.x > Xplus)
            {
                jump = true;
            }
            if (transform.position.x <= Xminus)
            {
                jump = true;
            }
        }
       
        if (patrol == false)
        {
            speed = 12;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
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
        Player.Coins += 300;
        theEndDoor.HP++;
        EnergyVampire.VampiricScore++;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
           
            if (Shop.BoostScore >= 2)
                health -= 3;
            if (patrol == false)
            {
                waitTime = startWaitTime;
                patrol = true;
                Player.Charget = true;
            }
        }
        if (collision.gameObject.tag == "Decor")
        {
            jump = false;
            speed = 7;
        }
       

    }
   void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Decor")
        {
            rb.AddForce(new Vector2(0, 15), ForceMode2D.Impulse);
        }
    }
   IEnumerator StopFlying()
    {
        yield return new WaitForSeconds(0.8f);
        jump = false;
    }
   public void Heal()
    {
        health += 5;
    }
 }