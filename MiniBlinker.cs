using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniBlinker : MonoBehaviour
{
    public GameObject BossBody;
    public float startWaitTime;
    Rigidbody2D rb;
    public int HPboss;
    private float waitTime;
    public Transform[] moveSpots;
    private int randomSpot;
    private int BossObject, DecorObject, EnBulletObject;
    public GameObject weapon1, weapon2;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        DecorObject = LayerMask.NameToLayer("Decor");
        BossObject = LayerMask.NameToLayer("Boss");
        EnBulletObject = LayerMask.NameToLayer("EnBullet");
       

    }
    void Update()
    {
        
        transform.position = moveSpots[randomSpot].transform.position;
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
        Destroy(gameObject);
        Player.Coins += 400;
        EnergyVampire.VampiricScore++;
        theEndDoor.HP++;    
    }
    public void Heal()
    {
        HPboss+=5;
    }
}