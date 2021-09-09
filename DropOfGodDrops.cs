using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DropOfGodDrops : MonoBehaviour
{

    private int bulletObject, enemyObject, bossObject, dropObject;
    Rigidbody2D rb;
    public float Speed;
    public int Destroyed6, Destroyed8, Destroyed10, Destroyed12, Destroyed14, Destroyed3;
    

    private void Start()
    {
        bulletObject = LayerMask.NameToLayer("Bullet");
        enemyObject = LayerMask.NameToLayer("Enemy");
        bossObject = LayerMask.NameToLayer("Boss");
        dropObject = LayerMask.NameToLayer("Drop");
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(2, 7), ForceMode2D.Impulse);
        Load();

        if (SceneManager.GetActiveScene().buildIndex == 3 && Destroyed3 == 3)
        { Destroy(gameObject); }
        if (SceneManager.GetActiveScene().buildIndex == 6 && Destroyed6 == 6)
        {Destroy(gameObject);}
        if (SceneManager.GetActiveScene().buildIndex == 8 && Destroyed8 == 8)
        {Destroy(gameObject);}
        if (SceneManager.GetActiveScene().buildIndex == 10 && Destroyed10 == 10)
        { Destroy(gameObject);}
        if (SceneManager.GetActiveScene().buildIndex == 12 && Destroyed12 == 12)
        { Destroy(gameObject);}
        if (SceneManager.GetActiveScene().buildIndex == 14 && Destroyed14 == 14)
        { Destroy(gameObject);}

    }
    private void Update()
    {
        Physics2D.IgnoreLayerCollision(dropObject, bulletObject, true);
        Physics2D.IgnoreLayerCollision(dropObject, enemyObject, true);
        Physics2D.IgnoreLayerCollision(dropObject, bossObject, true);
        Physics2D.IgnoreLayerCollision(dropObject, dropObject, true);
    }
    void Load()
    {
        if (PlayerPrefs.HasKey("Destroyed6"))
        {Destroyed6 = PlayerPrefs.GetInt("Destroyed6");}
        if (PlayerPrefs.HasKey("Destroyed3"))
        { Destroyed3 = PlayerPrefs.GetInt("Destroyed3");}
        if (PlayerPrefs.HasKey("Destroyed8"))
        {Destroyed8 = PlayerPrefs.GetInt("Destroyed8");}
        if (PlayerPrefs.HasKey("Destroyed10"))
        {Destroyed10 = PlayerPrefs.GetInt("Destroyed10");}
        if (PlayerPrefs.HasKey("Destroyed12"))
        {Destroyed12 = PlayerPrefs.GetInt("Destroyed12");}
        if (PlayerPrefs.HasKey("Destroyed14"))
        {Destroyed14 = PlayerPrefs.GetInt("Destroyed14");}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Unit")
        {
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
              Destroyed3 = 3;
              PlayerPrefs.SetInt("Destroyed3", 3);
            }
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
              Destroyed6 = 6;
              PlayerPrefs.SetInt("Destroyed6", 6);
            }
          if (SceneManager.GetActiveScene().buildIndex == 8)
            {
              Destroyed8 = 8;
              PlayerPrefs.SetInt("Destroyed8", 8);
            }
          if (SceneManager.GetActiveScene().buildIndex == 10)
            {
              Destroyed10 = 10;
              PlayerPrefs.SetInt("Destroyed10", 10);
            }
          if (SceneManager.GetActiveScene().buildIndex == 12)
            {
              Destroyed12 = 12;
              PlayerPrefs.SetInt("Destroyed12", 12);
            }
          if (SceneManager.GetActiveScene().buildIndex == 14)
            {
              Destroyed14 = 14;
              PlayerPrefs.SetInt("Destroyed14", 14);
            }
            Shop.godDropCount++;
            Destroy(gameObject);
        }
    }
}
