using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldenMiniBoss : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    Rigidbody2D rb;
    BoxCollider2D bc;
    public int HPboss;
    private float waitTime;
    private float TPwaitTime;
    public float TPStartWaitTime;
    public Transform[] moveSpots;
    public Transform[] NewMoveSpots;
    public Transform waveSpot;
    private int randomSpot;
    public static int CrystalIsActive;
    private int BossObject, DecorObject, EnBulletObject;
    public GameObject PlayerUnit;

    public GameObject Hweapon1, Hweapon2, Weapon1, Weapon2, Weapon3;     // в3 це воідган
    public Slider BossHpBar;
    public int i;
    public int dropChance;
    public int itIsDrop;
    public GameObject Drop;
    public GameObject Portal;
    public GameObject Spot;
    public bool Invincibility;
    public int Lenght;
    public bool Heal;
    public GameObject HealingSprite;
    public static bool Agr;
    public Transform PatrolSpot;
    public int X;                               // змінна для рахування кількості зміни рухів боса щоб потім включити режим блискавок
    public int Y;
    public static bool Stoping;
    public static bool Boosting;
    public GameObject BossHpBarSliderGOB;
    public GameObject one, two, three, four, five, six, seven;
    public bool Wave;
    public GameObject ScreenGOB;
    public bool Done;
    public Transform USFTAT;
    public Transform BSFTAT;
    public GameObject SpriteOfActivity;
    public GameObject CrOne, Crtwo;




    void Start()
    {
        
        Wave = false;
        Agr = false;
        Stoping = false;
        Lenght = 8;
        i = 5;
        X = 0;
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        waitTime = startWaitTime;
        TPwaitTime = TPStartWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        DecorObject = LayerMask.NameToLayer("Decor");
        BossObject = LayerMask.NameToLayer("Boss");
        EnBulletObject = LayerMask.NameToLayer("EnBullet");
        BossHpBar.maxValue = HPboss;
        Invincibility = false;
        Done = false;
        if (MainMenu.GhostMode == -1)
        {
            Destroy(gameObject);
            Player.BossIsDead = true;
            Instantiate(Spot, transform.position, Quaternion.identity);
            Portal.SetActive(true);
        }
    }
    void Update()
    {
        if (Y >= 10)
        {
            Y = 0;
        }
        if (Agr == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, PatrolSpot.position, speed * Time.deltaTime);
            Physics2D.IgnoreLayerCollision(BossObject, DecorObject, true);
            Physics2D.IgnoreLayerCollision(BossObject, EnBulletObject, true);
            Physics2D.IgnoreLayerCollision(BossObject, BossObject, true);
            if (Stoping == true)
            {
                speed -= 20 * Time.deltaTime;
                if (speed <= 0)
                {
                    Stoping = false;
                }
            }
            if (Boosting == true)
            {
                speed += 20 * Time.deltaTime;
                if (speed >= 9)
                {
                    Boosting = false;
                }
            }
        }
        if (Agr == true)
        {
            speed = 11;
            waitTime -= Time.deltaTime;
            Weapon1.SetActive(true);
            Weapon2.SetActive(true);
            if (HPboss <= 350 && Done == false)
            {
                ScreenGOB.SetActive(true);
                StartCoroutine(StopAfterTp());
                Hweapon1.SetActive(true);
                Hweapon2.SetActive(true);
                transform.position = BSFTAT.transform.position;
                PlayerUnit.transform.position = USFTAT.transform.position;
                Done = true;
            }
            if (Done == true)
            {
                Destroy(CrOne);
                Destroy(Crtwo);
                Invincibility = false;
                Heal = false;
                i = -150;
                transform.position = Vector2.MoveTowards(transform.position, NewMoveSpots[randomSpot].position, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, NewMoveSpots[randomSpot].position) < 0.2f)
                {
                    if (waitTime <= 0)
                    {
                        randomSpot = Random.Range(0, moveSpots.Length);
                        waitTime = startWaitTime;
                        Y++;
                    }
                }
                if (Y >= 4 && Y <= 7)
                {
                    SpriteOfActivity.SetActive(false);
                    bc.enabled = false;
                    Weapon3.SetActive(true);
                }
                else
                {
                    SpriteOfActivity.SetActive(true);
                    bc.enabled = true;
                    Weapon3.SetActive(false);
                }
            }
            BossHpBarSliderGOB.SetActive(true);
            BossHpBar.value = HPboss;

            if (Wave == false && Done == false)
            {
                transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f && Wave == false)
                {
                    if (waitTime <= 0)
                    {
                        randomSpot = Random.Range(0, moveSpots.Length);
                        waitTime = startWaitTime;
                        X++;
                    }
                }
            }
            if (X >= 10)
            {
                Wave = true;
            }
            if (Wave == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, waveSpot.position, speed * Time.deltaTime);
                StartCoroutine(RayActive());
            }

            if (i == 0)
            {
                Invincibility = false;
                TPwaitTime -= Time.deltaTime;
                if (TPwaitTime <= 0)
                {
                    i = 5;
                    Invincibility = true;
                    TPwaitTime = TPStartWaitTime;
                }
            }
            if (CrystalIsActive == 2)
            {
                Invincibility = true;
                i = 2;
            }
            if (CrystalIsActive == 3)
            {
                Heal = true;
            }
            else
            {
                Heal = false;
            }
        }
    }
    public void StopingOn()
    {
        Stoping = true;
    }
    public void BoostingOn()
    {
        Boosting = true;
    }
    public void TakeDamage(int damage)
    {
        if (Invincibility == true)
        {
            randomSpot = Random.Range(0, moveSpots.Length);
            transform.position = moveSpots[randomSpot].transform.position;
            i--;
        }
        if (Invincibility == false && Heal == false)
        {
            HPboss -= damage;
        }
        if (Invincibility == false && Heal == true)
        {
            HPboss += damage;
            Instantiate(HealingSprite, transform.position, Quaternion.identity);
        }
        if (HPboss <= 0)
        {
            Die();
        }
        if (HPboss < 651 && Agr == false)
        {
            Agr = true;
        }
    }

    void Die()
    {

        Destroy(gameObject);
        Player.Coins += 550;
        itIsDrop = Random.Range(1, 100);
        
        Instantiate(Spot, transform.position, Quaternion.identity);
        MainMenu.GhostMode = -1;
        PlayerPrefs.SetInt("GhostMode", MainMenu.GhostMode);
        Portal.SetActive(true);

        if (dropChance >= itIsDrop)
        {
            Instantiate(Drop, transform.position, Quaternion.identity);
        }
    }
    IEnumerator StopAfterTp()
    {

        Player.StopIsActive = true;
        yield return new WaitForSeconds(2f);
        Player.StopIsActive = false;
    }
    IEnumerator RayActive()
    {
        yield return new WaitForSeconds(1);
        one.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        two.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        three.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        four.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        five.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        six.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        seven.SetActive(true);

        yield return new WaitForSeconds(3);
        Wave = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Lava")
        {
            HPboss -= 50;
        }

    }
}

