using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrap : MonoBehaviour
{
    public GameObject Surprise;
    public GameObject Trap;
    public int HP;
    public int i;
    public bool random;
    void Start()
    {
       if (random == true)
        {
            i = Random.Range(1,3);
            Debug.Log(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {Die();}
    }
    void Die()
    {
        if (i == 1)
        {
            Surprise.SetActive(true);
            Destroy(gameObject);
            Player.Coins += 50;
        }
        if (i == 2)
        {
            Trap.SetActive(true);
            Destroy(gameObject);
            Player.Coins += 50;
        }
    }
}
