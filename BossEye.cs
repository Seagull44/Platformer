using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class BossEye : MonoBehaviour
{
    public float speed;
   
    public float startWaitTime;
    Rigidbody2D rb;
    public  int HPboss;
    private float waitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private int BossObject,  DecorObject, EnBulletObject;
  
    public GameObject weapon1, weapon2, weapon3, weapon4;
    public Slider BossHpBar;
    
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
        BossHpBar.maxValue = HPboss;
        Hide();
    }
    void Update()
    {
        BossHpBar.value = HPboss;
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) <0.2f)
        {
            if (waitTime <=0)
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
        Destroy(weapon1); Destroy(weapon2); Destroy(weapon3); Destroy(weapon4);
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
