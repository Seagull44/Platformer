using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class MiniBoss : MonoBehaviour
{
    private Vector3 scaleChange;
    public float speed;
    public GameObject Boom;
    public GameObject BossSprite;
    public GameObject BossBody;
    public float startWaitTime;
    Rigidbody2D rb;
    public int HPboss;
    private float waitTime;
    private float chargeTime;
    public float startChargeTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private int BossObject, DecorObject, EnBulletObject;
    public GameObject weapon1, weapon2;
   
    public GameObject Bar;
    public Vector2 target;
    private Transform player;
    public float x;
    public float y;
    public bool Destroyed = false;
    public bool isBossHasScope = false;
    public float timerToDeath;
    public bool startTimer;
    public static int i;
    public int dropChance;
    public int itIsDrop;
    public GameObject Drop;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        DecorObject = LayerMask.NameToLayer("Decor");
        BossObject = LayerMask.NameToLayer("Boss");
        EnBulletObject = LayerMask.NameToLayer("EnBullet");
        Hide();

        isBossHasScope = false;
        timerToDeath = 1;
        startTimer = false;
        scaleChange = new Vector3(+0.0015f, +0.0015f, +0.0015f);
    }

    void Update()
    {
        if (startTimer == true)
        {
            Boom.transform.localScale += scaleChange;
            timerToDeath -= 1 * Time.deltaTime;
        }
        if (timerToDeath <= 0.5)
        {
            DestroyedBoss();
        }
        
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
        if (HPboss <= 4 && isBossHasScope == false)
        {

            player = GameObject.FindGameObjectWithTag("Unit").transform;
            target = new Vector2(player.position.x, player.position.y);

            transform.position = Vector2.MoveTowards(transform.position, target, speed * 2 * Time.deltaTime);
            isBossHasScope = true;

            if (Destroyed == true)
            {
                startTimer = true;
                Die();
            }
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                startTimer = true;
                Die();
            }

        }
        if (isBossHasScope == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * 2 * Time.deltaTime);
            if (Destroyed == true)
            {

                startTimer = true;
                Die();
            }
            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                startTimer = true;
                Die();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        HPboss -= damage;
        if (HPboss <= 0)
        {
            startTimer = true;
            Die();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
            Destroyed = true;
        if (collision.gameObject.tag == "Ground")
        { Die();
            startTimer = true;
            speed = 0;
        } 
    }
        void Die()
    { 
        Boom.SetActive(true);
        BossSprite.SetActive(false);
        speed = 0;
    }

    public void DestroyedBoss()
    {
        
        theEndDoor.MiniHp++;
        BossBody.SetActive(false);
        Player.Coins += 150;
        itIsDrop = Random.Range(1, 100);
        if (dropChance >= itIsDrop)
        {
            Instantiate(Drop, transform.position, Quaternion.identity);
        }
     }
    void Hide()
    {
        if (Player.BossIsDead == true)
        {
            Destroy(gameObject);
        }
    }
}
