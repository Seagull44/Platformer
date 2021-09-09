using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using System.Collections;
using UnityEditor;

public class Player : MonoBehaviour
{
    public static int Coins;
    public static int health;
    public int armor;
    public int maxHealth;
    public Text CoinsScore;
    public Text CurrentHealth;
    public float horisontalSpeed;
    float speedX;
    public float verticalSpeed;
    float speedY;
    Rigidbody2D rb;
    CircleCollider2D Cc;
    SpriteRenderer sr;
    public static bool isGrounded;
    public int extraJumpsValue;
    public int extraJumps;
    private int playerObject, collideObject, DecorObject, LavaObject, ShardObject;
    public int trapX;
    public static bool TrapIsActive = false;
    public Button BoostBtn;
    public Button ShieldBtn;
    public Button GhModBtn;
    public Button EvBtn;
    public Button Left;
    public Button Right;
    public Button Jump;
    public GameObject Boss;
    public GameObject door;
    public GameObject testWeapon;
    public Slider hpBar;
    public Slider armorBar;
    public GameObject armorGob;
    public int LineOfDying;
    public float CheckPositionX;
    public float CheckPositionY;
    public float StartPositionX;
    public float StartPositionY;
    public float FloatPositionX;
    public float FloatPositionY;
    public static bool CheckPointActive = false;
    public static bool BossIsDead = false;
    public static bool Invincible;
    public static bool Boosting;
    public GameObject CheckPointDoor;
    public float Z;
    public Transform FirePoint;
    public Transform player;
    public Vector2 PositionForTp;
    public GameObject BoostBttnObject;
    public GameObject CentrOfRotateObject;
    public GameObject EVButtnObj;
    public GameObject ShieldObj;
    public GameObject HealingSprite;
    public float StartTimeBtwHeal;
    public float LastHealMillisecond;
    public static bool SlowDebuff;
    public static bool Charget;
    public static bool LeftImpule;
    public static bool RightImpule;
    public static bool GravityDown; 
    public static bool GravityUp;
    public static bool StopIsActive;
    public static bool GhostModeIsActive;
    public GameObject RedSkin;
    public GameObject FrostySkin;
    public GameObject ShieldSkin;
    public GameObject GhostModeSkin;
    public float Grav;
    public static int NumberOfShooted;
    public float MemoryTime;
    public static bool Inversion;
    public int Jumpforce;
    public bool sloving;
    public bool MovingRight;
    public bool MovingLeft;
 /*   public float testTime = 3;          // удали
*/


    void Start()
    {
        MovingLeft = false;
        MovingRight = false;
        sloving = false;
        StopIsActive = false;
        Charget = false;
        LeftImpule = false;
        RightImpule = false;
        SlowDebuff = false;
        GravityUp = false;
        GravityDown = false;
        Inversion = false;
        maxHealth = 8 + Shop.upgradeHealth;
        Jumpforce = 15;
        rb = GetComponent<Rigidbody2D>();
        Cc = GetComponent<CircleCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        Coins = 0;
        NumberOfShooted = 0;
        Grav = 1;
        playerObject = LayerMask.NameToLayer("Player");
        collideObject = LayerMask.NameToLayer("Collide");
        DecorObject = LayerMask.NameToLayer("Decor");
        LavaObject = LayerMask.NameToLayer("Lava");
        ShardObject = LayerMask.NameToLayer("Shard");
        CoinsScore.fontSize = 20;

        Invincible = false;
        Boosting = false;
        health = maxHealth;

        speedX = 0f;
        speedY = 0f;

        transform.position = new Vector2(StartPositionX, StartPositionY);
        if (CheckPointActive == true)
        {
            transform.position = new Vector2(CheckPositionX, CheckPositionY);
            CheckPointDoor.SetActive(true);
            door.SetActive(true);
            if (PlayerPrefs.HasKey("CurrentScore"))
            {
                Coins = PlayerPrefs.GetInt("CurrentScore");
            }
        }
        if (MainMenu.SkillBoost == false && MainMenu.SkillEV == false && MainMenu.SkillShield == false)
        {
            BoostBttnObject.SetActive(false);
            CentrOfRotateObject.SetActive(false);
            EVButtnObj.SetActive(false);
            ShieldObj.SetActive(false);
        }
        if (MainMenu.SkillBoost == true)
        {
            BoostBttnObject.SetActive(true);
            CentrOfRotateObject.SetActive(false);
            EVButtnObj.SetActive(false);
            ShieldObj.SetActive(false);
        }
        if (MainMenu.SkillEV == true)
        {
            BoostBttnObject.SetActive(false);
            CentrOfRotateObject.SetActive(true);
            EVButtnObj.SetActive(true);
            ShieldObj.SetActive(false);
        }
        if (MainMenu.SkillShield == true)
        {
            BoostBttnObject.SetActive(false);
            CentrOfRotateObject.SetActive(false);
            EVButtnObj.SetActive(false);
            ShieldObj.SetActive(true);
        }
        TrapIsActive = false;
    }

    void Update()
    {
        if (sloving == true)
        {
            speedX -= 0.2f * Time.deltaTime;
            if (speedX <=0)
            {
                speedX = 0;
                sloving = false;
            }
        }
       /* testTime -= Time.deltaTime;*/
        /*if (testTime <= 0)
        {
            testTime = 200;
            *//*LeftBttn();*//*
            Boosting = true;
            StartCoroutine(boostActive());                  удали
        }*/
        if (StopIsActive == true )
        {
            horisontalSpeed = 0;
            RBUp();
            LBUp();
        }
        
        if (Inversion == true)
        {
            GravityUp = true;
            Jumpforce = -15;
        }
        if (Inversion == false)
        {
            Jumpforce = 15;
            GravityUp = false;
        }

        
        if (GhostModeIsActive == true)
        {
            Grav = 0;
            rb.gravityScale = 0;
            Cc.enabled = false;
            SlowDebuff = false;
            /*RedSkin.SetActive(false);*/
            FrostySkin.SetActive(false);
            GhostModeSkin.SetActive(true);
        }
        hpBar.maxValue = maxHealth;
        hpBar.value = health;
        armorBar.value = armor;
        armor = health - maxHealth;
        armorBar.maxValue = 10;
        if (health <= 0)
        {
            Die();
        }

        if (rb.velocity.y > 15f)
        {
            rb.velocity = new Vector2(speedX, 15f);
        }

        if (GravityUp == true)
        {
            rb.gravityScale = -1;
        }
        if (GravityDown == true)
        {
            rb.gravityScale = 4;
        }
        if (GravityDown == false && GravityUp == false)
        { rb.gravityScale = Grav; }

        if (isGrounded == false && Inversion == false)
        {
            Grav -= -0.0007f;
            if (Grav <= 0.5f)
            {
                Grav = 0.5f;
            }
        }
        if (isGrounded == true && Inversion == false && GhostModeIsActive == false)
        {
            Grav = 1;
        }
        if (SlowDebuff == true && StopIsActive == false && Inversion == false)
        {
            StartCoroutine(Clean());
            /*RedSkin.SetActive(false);*/
            FrostySkin.SetActive(true);
            horisontalSpeed = 0.03f; 
        }
        if (SlowDebuff == false && StopIsActive == false && Inversion == false && GhostModeIsActive == false)
        {
            /*RedSkin.SetActive(true);*/
            FrostySkin.SetActive(false);
            horisontalSpeed = 0.08f;
        }
        if (Invincible == true)
        {
            ShieldSkin.SetActive(true);
        }
        if (Invincible == false)
        {
            ShieldSkin.SetActive(false);
        }

        if (health > maxHealth)
        {
            armorGob.SetActive(true);
        }
        else armorGob.SetActive(false);

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Boosting == true && StopIsActive == false)
        {
            if (MovingLeft == true)
            {
                speedX = -0.16f;
            }
            if (MovingRight == true)
            {
                speedX = 0.16f;
            }
            if (MovingLeft == false && MovingRight == false)
            {
                speedX = 0.16f;
            }
           /* transform.position = Vector2.MoveTowards(transform.position, FirePoint.position, speedX * Time.deltaTime);*/
            if (Shop.BoostScore >= 2)
            {
                Invincible = true;
            }
        }


       /* if (Input.GetKey(KeyCode.A) && Boosting == false)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            speedX = horisontalSpeed;
        }

        else if (Input.GetKey(KeyCode.A) && Boosting == true)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }*/

/*
        else if (Input.GetKey(KeyCode.D) && Boosting == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        else if (Input.GetKey(KeyCode.D) && Boosting == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            speedX = horisontalSpeed;
        }
*/
       /* else if (Input.GetKey(KeyCode.E) && Boosting == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            speedY = speedX / 2;
        }
        else if (Input.GetKey(KeyCode.E) && Boosting == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            speedX = horisontalSpeed;
        }

        else if (Input.GetKey(KeyCode.Q) && Boosting == false)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            speedX = horisontalSpeed;
        }

        else if (Input.GetKey(KeyCode.Q) && Boosting == true)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            speedY = speedX / 2;
        }*/

       

      /*  if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0 && isGrounded == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
            extraJumps--;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps >= 0 && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
        }*/
       /* if (Input.GetKey(KeyCode.W) && Boosting == false && Inversion == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
            speedX = 0;
        }
        if (Input.GetKey(KeyCode.W) && Boosting == true && Inversion == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.W) && Boosting == false && Inversion == true)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            speedX = 0;
        }
        if (Input.GetKey(KeyCode.W) && Boosting == true && Inversion == true)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
            speedX = 0;
        }*/
        if (Charget == true)
        {
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            Charget = false;
        }
        if (LeftImpule == true)
        {
            speedX = 0;                                                      //Вказати щоб відключався джойстик
            rb.AddForce(new Vector2(-2, 0), ForceMode2D.Impulse);
            LeftImpule = false;
        }
        if (RightImpule == true)
        {
            speedX = 0;                                                     //Вказати щоб відключався джойстик
            rb.AddForce(new Vector2(2, 0), ForceMode2D.Impulse);
            RightImpule = false;
        }

        transform.Translate(speedX, speedY, 0);
       
        CoinsScore.text = "Score" + " " + Coins;
        CurrentHealth.text = "Health" + " " + health;

        if (rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(playerObject, collideObject, true);
            Physics2D.IgnoreLayerCollision(playerObject, DecorObject, true);
        }
        else
        {
            Physics2D.IgnoreLayerCollision(playerObject, collideObject, false);
            Physics2D.IgnoreLayerCollision(playerObject, DecorObject, false);
        }
        if (transform.position.x >= trapX && BossIsDead == false)
        {
            Boss.SetActive(true);
            door.SetActive(true);
            TrapIsActive = true;
        }
        if (transform.position.x < trapX - 2)
        {
            door.SetActive(false);
        }
        if (transform.position.y < LineOfDying)
        {
            Die();
        }
        Physics2D.IgnoreLayerCollision(playerObject, ShardObject, true);
        if (NumberOfShooted > 2)
        {
            NumberOfShooted = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Decor")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Enemy")
        {
            isGrounded = true;
            if (Invincible == false)
            {
                TakeDamage(1);
            }
        }
        if (collision.gameObject.tag == "FireBall")
        {
            
            if (Invincible == false)
            {
                TakeDamage(4);
            }
        }

        if (collision.gameObject.tag == "VoidBall")
        {

            if (Invincible == false)
            {
                TakeDamage(4);
            }
        }

        if (collision.gameObject.tag == "FlyEnemy")
        {
            isGrounded = true;
            if (Invincible == false)
            {
                TakeDamage(1);
            }
        }
        if (collision.gameObject.tag == "Lava")
        {
            if (Invincible == false)
            {
                Die();
            }
        }
        if (collision.gameObject.tag == "Boss")
        {
            isGrounded = true;
            if (Invincible == false)
            {
                TakeDamage(2);
            }
           
        }
        if (collision.gameObject.tag == "Check")
        {
            CheckPointActive = true;
            CheckPointDoor.SetActive(true);
            PlayerPrefs.SetInt("CurrentScore", Coins);
        }
        if (collision.gameObject.tag == "Stop")
        {
          /*  isGrounded = true;*/
            if (Boosting == true)
            {
               Boosting = false;
               PositionForTp = new Vector2(player.position.x, player.position.y);
               transform.position = PositionForTp;
            }
            if (speedX >= 0.1)
            {
                Boosting = false;
                PositionForTp = new Vector2(player.position.x, player.position.y);
                transform.position = PositionForTp;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Decor")
        {
            isGrounded = true;
        }
        if (collision.gameObject.tag == "Lava")
        { if (Invincible == false)
            {
                Die();
            }
        }
    }
     
    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
        if (collision.gameObject.tag == "Decor")
            isGrounded = false;
        if (collision.gameObject.tag == "Enemy")
            isGrounded = false;
        if (collision.gameObject.tag == "FlyEnemy")
            isGrounded = false;
        if (collision.gameObject.tag == "Boss")
            isGrounded = false;
        if (collision.gameObject.tag == "Stop")
            isGrounded = false;
    }
    public void TakeDamage(int damage)
    {
        if (Invincible == false)
        {
            health -= damage;
            if (health <= 0)
            {
                Die();
            }
        }
    }
    public void TakeHeal(int heal)
    {
        float currentMillisecond = Time.time * 1000;
        if (currentMillisecond - LastHealMillisecond > StartTimeBtwHeal * 1000)
        {
            if (health < maxHealth)
            {
                health += heal;
                Instantiate(HealingSprite, transform.position, Quaternion.identity);
            }
            LastHealMillisecond = currentMillisecond;
        }
    }
    public void HealingItem(int healforplayer)
    {
        health += healforplayer;
        Instantiate(HealingSprite, transform.position, Quaternion.identity);
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        StopIsActive = true;
        horisontalSpeed = 0;
        verticalSpeed = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void UpgradeMaxHealth()
    {
        maxHealth++;
    }
    public void Boost ()
    {
        Boosting = true;
        StartCoroutine(boostActive());
    }
    IEnumerator boostActive()
    {
        BoostBtn.interactable = false;
        yield return new WaitForSeconds(1);
        Boosting = false;
        horisontalSpeed = 0.08f;
        sloving = true;
        Invincible = false;
        yield return new WaitForSeconds(5);
        BoostBtn.interactable = true;
    }
    IEnumerator Clean()
    {
        yield return new WaitForSeconds(4f);
        SlowDebuff = false;
    }

    public void Shield()
    {
        StartCoroutine(ShieldActive());
    }

    IEnumerator ShieldActive()
    {
        Invincible = true;
        ShieldBtn.interactable = false;
        yield return new WaitForSeconds(3 + MainMenu.Shield);
        Invincible = false;
        yield return new WaitForSeconds(16 - (2*MainMenu.Shield) );
        ShieldBtn.interactable = true;
    }
    IEnumerator InversionActive()
    {
        Inversion = true;
        yield return new WaitForSeconds(12);
        Inversion = false;
    }

    IEnumerator GhostModeActive()
    {
        GhostModeIsActive = true;
        GhModBtn.interactable = false;
        yield return new WaitForSeconds(3);
        Cc.enabled = true;
        GhostModeSkin.SetActive(false);
        Grav = 1;
        GhostModeIsActive = false;
        yield return new WaitForSeconds(15);
        GhModBtn.interactable = true;
    }

    public void GhModFunction()
    {
        StartCoroutine(GhostModeActive());
    }
    public void InversionIsActive()
    {
        StartCoroutine(InversionActive());
    }

    public void LeftBttn()
    {
        MovingLeft = true;
        if (Boosting == false && Inversion == false)
        {
            speedX = -horisontalSpeed;
        }
      

        if (Inversion == true)
        {
            speedX = horisontalSpeed;
        }
    }
    public void LBUp()
    {
        speedX = 0;
        MovingLeft = false;
    }
    public void RBUp()
    {
        speedX = 0;
        MovingRight = false;
    }
    public void RightBttn()
    {
        MovingRight = true;
        if (Boosting == false && Inversion == false)
        {
            {
                speedX = horisontalSpeed;
            }
          
        }
       /* if (Boosting == true && Inversion == false)
        {
            speedX = 2 * horisontalSpeed;
        }*/
        if (Inversion == true)
        {
            {
                speedX = -horisontalSpeed;
            }
            /*if (Boosting == true)
            {
                speedX = -2 * horisontalSpeed;
            }*/
        }
    }
    public void JumpBttn()
    {
        if (extraJumps > 0 && isGrounded == false)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
            extraJumps--;
        }
        else if (extraJumps >= 0 && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, Jumpforce), ForceMode2D.Impulse);
        }
    }
}

