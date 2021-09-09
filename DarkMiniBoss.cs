using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkMiniBoss : MonoBehaviour
{
    public float speed;

    public float startWaitTime;
    Rigidbody2D rb;
    public int HPboss;
    private float waitTime;
    private float TPwaitTime;
    public float TPStartWaitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    public GameObject[] GravUp;
    public GameObject[] GravDown;

    private int BossObject, DecorObject, EnBulletObject;

   /* public GameObject weapon1, weapon2, weapon3, Hweapon1, Hweapon2;*/
    public Slider BossHpBar;
    public int i;
    public int dropChance;
    public int itIsDrop;
    public GameObject Drop;
    public bool Invincibility;
    public int Lenght;
    
    void Start()
    {
        Lenght = 8;
        i = 5;
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        TPwaitTime = TPStartWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        DecorObject = LayerMask.NameToLayer("Decor");
        BossObject = LayerMask.NameToLayer("Boss");
        EnBulletObject = LayerMask.NameToLayer("EnBullet");
        BossHpBar.maxValue = HPboss;
        Hide();
       
        Invincibility = true;
    }
    void Update()
    {
       if (HPboss <=200)
        {
            for (int index = 0; index < Lenght; index++)
            {
                GravDown [index].SetActive(true);
                GravUp [index].SetActive(false);
            }
        }
        BossHpBar.value = HPboss;
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
       
        if (i == 0)
        {
            Invincibility = false;
            TPwaitTime -= Time.deltaTime;
            if (TPwaitTime <=0)
            {
                i = 5;
                Invincibility = true;
                TPwaitTime = TPStartWaitTime;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if (Invincibility == true)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            transform.position = moveSpots[randomSpot].transform.position;
            i--;
        }
        if (Invincibility == false)
        {
            HPboss -= damage; 
        }
        if (HPboss <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        theEndDoor.HP++;
        Destroy(gameObject);
       /* Destroy(weapon1); Destroy(weapon2); Destroy(weapon3); */
        Player.Coins += 350;
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

