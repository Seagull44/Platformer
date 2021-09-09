using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikadze : MonoBehaviour
{
    public float speed;
    public GameObject Boom;
    public GameObject BodySprite;
    private Vector3 scaleChange;
    public int BoomDmg;
    BoxCollider2D bc;
    public int HP;
    private int BodyOfEnemy, EnBulletObject;
    public GameObject Body;
    public Transform player;
    public float timerToDeath;
    public bool startTimer;
    public bool Charge;
    public int RMoveDistance;
    public int LMoveDistance;
    public int OverDamage;
    public float shootingDistance;
    private Vector2 target;
    public static float plus;
    


    void Start()
    {
        plus = 0;
        bc = GetComponent<BoxCollider2D>();
        BodyOfEnemy = LayerMask.NameToLayer("Enemy");
        EnBulletObject = LayerMask.NameToLayer("EnBullet");
        timerToDeath = 1;
        startTimer = false;
        Charge = false;
        scaleChange = new Vector3(+0.001f, +0.001f, +0.001f);
        player = GameObject.FindGameObjectWithTag("Unit").transform;
    }

    void Update()
    {
        target = new Vector2(player.position.x, player.position.y);

        if (startTimer == true)
        {
            Boom.transform.localScale += scaleChange;
            timerToDeath -= 1 * Time.deltaTime;
        }
        if (timerToDeath <= 0.5)
        {
            DestroyedEnemy();
        }
        if (Charge == false)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (transform.position.x >= RMoveDistance)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (transform.position.x <= LMoveDistance)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        if (Vector2.Distance(transform.position, player.position) < shootingDistance)
        {
            Charge = true;
        }
        if (Charge == true)
        {
            speed = 12;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        Physics2D.IgnoreLayerCollision(BodyOfEnemy, EnBulletObject, true);
        Physics2D.IgnoreLayerCollision(BodyOfEnemy, BodyOfEnemy, true);
        }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            DestroyedEnemy();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "Unit")
        {
            if (Shop.BoostScore >= 2)
            {
                HP -= 3;
            }
            if (Charge == true)
            {
                bc.enabled = false;
                Die();
                startTimer = true;
                if (Player.Invincible == false)
                {
                    Player.health -= BoomDmg;
                }
            }
        }
    }

    void Die()
    {
        Boom.SetActive(true);
        BodySprite.SetActive(false);
        speed = 0;
    }
    void DestroyedEnemy()
    {
        Body.SetActive(false);
        Player.Coins += 75;
        EnergyVampire.VampiricScore++;
    }
   
}
