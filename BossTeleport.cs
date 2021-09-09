using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BossTeleport : MonoBehaviour
{
    public GameObject BossBody;
    public float startWaitTime;
    Rigidbody2D rb;
    public  int HPboss;
    private float waitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private int BossObject, DecorObject, EnBulletObject;
    public GameObject theEndDoor;
    public Slider BossHpBar;
    public GameObject Bar;
    public int i;
    SpriteRenderer sr;
    public GameObject[] spavnSpot;
    /*public GameObject weapon1, weapon2, weapon3, weapon4;*/
    void Start()
    {
        i = 0;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        DecorObject = LayerMask.NameToLayer("Decor");
        BossObject = LayerMask.NameToLayer("Boss");
        EnBulletObject = LayerMask.NameToLayer("EnBullet");
        BossHpBar.maxValue = HPboss;
    }
    void Update()
    {
        if (i >5 && i < 7)
        {
            sr.enabled = false;
        }
        else 
        {
            sr.enabled = true;
        }
        if (i >= 10)
        {
            i = 0;
        }
        if (HPboss <= 40)
        {
            for (int index = 0; index < 4; index++)
            {
                spavnSpot[index].SetActive(true);
            }
        }
        BossHpBar.value = HPboss;
        transform.position = moveSpots[randomSpot].transform.position;
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
                i++;
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
        Player.BossIsDead = true;
        theEndDoor.SetActive(false);
        Destroy(Bar);
        BossBody.SetActive(false);
        Player.Coins += 150;
        for (int index = 0; index < 4; index++)
        {
            spavnSpot[index].SetActive(false);
        }
    }
}
