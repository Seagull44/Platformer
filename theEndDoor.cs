using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theEndDoor : MonoBehaviour
{
    public static int HP = 0;
    public static int MiniHp = 0;
    public int hp;
    
   
    public GameObject Bar;

     void Start()
    {
        MiniHp = 0;
        HP = 0;
    }
    void Update()
    {
      if (hp == (HP + MiniHp))
        {
            Die();
        }
    }
    void Die()

    {
        Player.BossIsDead = true;
        Bar.SetActive(false);
        Destroy(gameObject);

    }

}