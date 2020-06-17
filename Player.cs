using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int Coins;
    public int health;
    public Text CoinsScore;
    public Text CurrentHealth;
    public float horisontalSpeed;
    float speedX;
    public float verticalImpulse;
    Rigidbody2D rb;
    bool isGrounded;
    public int extraJumpsValue;
    private int extraJumps;
    private int playerObject, collideObject;
    public int Heal;
    private float TimeBtwHeal;
    public float StartTimeBtwHeal;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Coins = 0;
        playerObject = LayerMask.NameToLayer("Player");
        collideObject = LayerMask.NameToLayer("Collide");
        TimeBtwHeal = StartTimeBtwHeal;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            speedX = horisontalSpeed;

        }


        else if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            speedX = horisontalSpeed;
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, verticalImpulse), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, 90);

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }

        transform.Translate(speedX, 0, 0);
        speedX = 0;
        CoinsScore.text = "Score" + " " + Coins;
        CurrentHealth.text = "Health" + " " + health;


        if (rb.velocity.y > 0)
        {
            Physics2D.IgnoreLayerCollision(playerObject, collideObject, true);
        }
        else
            Physics2D.IgnoreLayerCollision(playerObject, collideObject, false);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")

            isGrounded = true;

        if (collision.gameObject.tag == "Enemy")

            health -= 1;

        


        if (collision.gameObject.tag == "FlyEnemy")
            health -= 1;

        if (health <= 0)
        {
            Die();
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



    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }

    }
    public void TakeHeal(int heal)
    {
        if (health <= 50 && TimeBtwHeal <= 0)
        {
            health += heal;
            TimeBtwHeal = StartTimeBtwHeal;
        }
        else
        {
            TimeBtwHeal -= Time.deltaTime;
           heal = 0;
        }
    }
}

