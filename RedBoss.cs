using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class RedBoss : MonoBehaviour
{
    
    
    public float speed;
    public float startWaitTime;
    Rigidbody2D rb;
    public int HPboss;
    private float waitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private int BossObject, DecorObject, EnBulletObject;

    public GameObject weapon1, weapon2, weapon3, weapon4;
    public Slider BossHpBar;
    public Transform player;
    public int dropChance;
    public int itIsDrop;
    public GameObject Drop;
    public bool ChargeIsActive = false;
    private Vector2 target;
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
        ChargeIsActive = false;
        player = GameObject.FindGameObjectWithTag("Unit").transform;
       
        StartCoroutine(Recharging());
    }


    void Update()
    {
        Physics2D.IgnoreLayerCollision(BossObject, DecorObject, true);
        Physics2D.IgnoreLayerCollision(BossObject, EnBulletObject, true);
        Physics2D.IgnoreLayerCollision(BossObject, BossObject, true);
        
        BossHpBar.value = HPboss;
        target = new Vector2(player.position.x, player.position.y);
        if (ChargeIsActive == false)
         {  speed = 12;
          transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
          if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) <= 0.2f)
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
        if (ChargeIsActive == true)
        {
            speed = 15;
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
    }
   public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Unit")
        {
            ChargeIsActive = false;
            StartCoroutine(Recharging());
        }
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

        Destroy(weapon1); Destroy(weapon2);
        Player.Coins += 500;

        itIsDrop = Random.Range(1, 100);
        if (dropChance >= itIsDrop)
        {
            Instantiate(Drop, transform.position, Quaternion.identity);
        }
    }

    IEnumerator Recharging()
    {
        {
            yield return new WaitForSeconds(9);
            ChargeIsActive = true;
            
            yield return new WaitForSeconds(5f);
            ChargeIsActive = false;
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
