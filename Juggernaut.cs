using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggernaut : MonoBehaviour
{
    public GameObject Himself;
    public GameObject projectile;
    public GameObject Boom;
    public int HisHP;
    public int TriggerNumber;
    public Transform[] MoveSpots;
    public int i;
    private float TimeBB;
    public float startTime;
    public bool Jug;
    private int randomSpot;
    void Start()
    {
        i = 0;
        randomSpot = Random.Range(0, MoveSpots.Length);
        TimeBB = 0;
        Jug = false;
    }


    void Update()
    {
        TimeBB -= Time.deltaTime;
        FlyEnemy other = Himself.GetComponent<FlyEnemy>();
        HisHP = other.health;
        if (HisHP <= TriggerNumber)
        {
            Juggertime();
        }
        if (i == 7)
        {
            Player.Coins += 100;
            Instantiate(Boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (Jug == true && TimeBB <= 0)
        {
            transform.position = MoveSpots[0 + randomSpot].transform.position;

            TimeBB = startTime;
            randomSpot = Random.Range(0, MoveSpots.Length);
            i++;
            if (i == 2 || i == 4 || i == 6)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
            }
        }
    }
    public void Juggertime()
    {
        FlyEnemy other = Himself.GetComponent<FlyEnemy>();
        other.enabled = false;
        Jug = true;
    }
   
}
