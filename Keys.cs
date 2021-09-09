using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour
{
    public int HP;
    public GameObject Red2, Light2;
    public GameObject Puck, Field;
    

   
    void Start()
    {
       
    }

   
    void Update()
    {
        
    }
    void Die()
    {
        if (HP <=0)
        {
            Red2.SetActive(false);
            Light2.SetActive(true);
            Puck.SetActive(true);
            Field.SetActive(false);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Die();
        }
    }
}
