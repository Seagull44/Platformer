using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuicideEnemy : MonoBehaviour
{
    public float speed;
    public GameObject Boom;
    public GameObject BodySprite;
    private Vector3 scaleChange;
    public float startWaitTime;
    Rigidbody2D rb;
    public int HP;
    private float waitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private int BodyOfEnemy, EnBulletObject;
    public GameObject weapon1;
    public Transform destroySpot;
    public GameObject destroyedWall;
    public GameObject Body;
    public float timerToDeath;
    public bool startTimer;
    public bool Charge;
    public GameObject CenterOfRotate;
    public int OverDamage;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        BodyOfEnemy = LayerMask.NameToLayer("Enemy");
        EnBulletObject = LayerMask.NameToLayer("EnBullet");
        timerToDeath = 1;
        startTimer = false;
        Charge = false;
        scaleChange = new Vector3(+0.001f, +0.001f, +0.001f);
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
            DestroyedEnemy();
        }
        if (Charge == false)
        {
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
        }
        if (Charge == true)
        {
            speed = 10;
            transform.position = Vector2.MoveTowards(transform.position, destroySpot.position, speed * Time.deltaTime);
        }
        Physics2D.IgnoreLayerCollision(BodyOfEnemy, EnBulletObject, true);
        Physics2D.IgnoreLayerCollision(BodyOfEnemy, BodyOfEnemy, true);
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0 && HP >=OverDamage)
        {
            Charge = true;
        }
        if (HP <= OverDamage)
        {
            Body.SetActive(false);
            Player.Coins += 50;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Decor")
        {
            Die();
            startTimer = true;
        }
        if (collision.gameObject.tag == "Unit")
        {
            if (Charge == true)
            {
                Die();
                startTimer = true;
            }
        }
    }

    void Die()
    {
        Boom.SetActive(true);
        BodySprite.SetActive(false);
        speed = 0;
        EnergyVampire.VampiricScore++;
    }
    void DestroyedEnemy()
    {
        destroyedWall.SetActive(false);
        Body.SetActive(false);
        Player.Coins += 75;
        EnergyVampire.VampiricScore++;
    }
}
