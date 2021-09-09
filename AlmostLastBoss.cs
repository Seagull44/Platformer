using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlmostLastBoss : MonoBehaviour
{
    Rigidbody2D rb;
    CircleCollider2D cc;
    public int HPboss;
    public float speed;
    public float startWaitTime;
    private float waitTime;
    public Transform[] moveSpots;
    public GameObject[] Walls;
    private int randomSpot;
    public int dropChance;
    public int itIsDrop;
    public static bool RootsIsActive;
    public Transform rootSpot;
    public GameObject Roots;
    public GameObject AnimeWeapon;
    public GameObject Hweapon;
    public bool ragePhase;
    public bool UnNormalPhase;
    public bool tricksPhase;
    public bool movingPhase;
    private int BossObject, DecorObject, EnBulletObject;
    public int X;
    public int Y;
    public int Lenght;
    public Transform SpotForWawePhase;
    public GameObject WaweOne, WaweTwo, WaweThree;
    void Start()
    {
        X = 0;
        Y = 0;
        ragePhase = false;
        UnNormalPhase = false;
        tricksPhase = true;
        movingPhase = true;
        waitTime = startWaitTime;
        DecorObject = LayerMask.NameToLayer("Decor");
        BossObject = LayerMask.NameToLayer("Boss");
        EnBulletObject = LayerMask.NameToLayer("EnBullet");
    }


    void Update()
    {
        if (Y >= 2)
        {
            StartCoroutine(TidesOfLight());
        }
        if (X >= 10 && X <=15)
        {
            tricksPhase = true;
        }
        if (X > 15)
        {
            tricksPhase = false;
            UnNormalPhase = true;
            Y++;
        }
        if (movingPhase == false)
        {
            speed = 0;
        }
        if (movingPhase == true)
        {
            speed = 11;
        }
        if (tricksPhase == true)
        {
            waitTime -= Time.deltaTime;
            rootSpot = GameObject.FindGameObjectWithTag("Unit").transform;
            if (waitTime <= 0 && Player.isGrounded == true)
            {
                Instantiate(Roots, rootSpot.position, Quaternion.identity);
                waitTime = 15;
            }
        }

        if (ragePhase == true)
        {
            StartCoroutine(Rage());
        }

        if (UnNormalPhase == true)
        {
            movingPhase = false;
            ragePhase = true;
            tricksPhase = true;
            StartCoroutine(ShootingWithWalls());
            for (int index = 0; index < Lenght; index++)
            {
               Walls[index].SetActive(true);
            }
        }
        Physics2D.IgnoreLayerCollision(BossObject, DecorObject, true);
        Physics2D.IgnoreLayerCollision(BossObject, EnBulletObject, true);
        Physics2D.IgnoreLayerCollision(BossObject, BossObject, true);


        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f && movingPhase == true)
        {
             { 
                randomSpot = Random.Range(0, moveSpots.Length);
                X++;
             }
        }
    }

    IEnumerator Rage()
    {
        ragePhase = false;
        Hweapon.SetActive(false);
        movingPhase = false;
        AnimeWeapon.SetActive(true);
        yield return new WaitForSeconds(5);
        AnimeWeapon.SetActive(false);
        movingPhase = true;
        Hweapon.SetActive(true);
    }
    IEnumerator ShootingWithWalls()
    {
        yield return new WaitForSeconds(5);
        tricksPhase = false;
        movingPhase = true;
        X = 0;
    }

    IEnumerator TidesOfLight()
    {
        movingPhase = false;
        tricksPhase = false;
        UnNormalPhase = false;
        ragePhase = false;
        X = 0;
        Y = 0;
        transform.position = SpotForWawePhase.transform.position;
        yield return new WaitForSeconds(3);
        WaweOne.SetActive(true);
        yield return new WaitForSeconds(1);
        WaweTwo.SetActive(true);
        yield return new WaitForSeconds(1);
        WaweThree.SetActive(true);


    }


}
