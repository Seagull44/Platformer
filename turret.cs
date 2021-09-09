using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    public GameObject Laser;
    public int health;
    public float startWaitTime;
    public bool startTimer;
    public float waitTime;

    void Start()
    {
        startTimer = false;
        waitTime = startWaitTime;
    }

    void Update()

    {
        waitTime -= Time.deltaTime;

        if (waitTime <= 0)
        {
            Shoot();
            waitTime = startWaitTime;
        }
    }
    void Shoot ()
    {
        Laser.SetActive(!Laser.activeSelf);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Player.Coins += 10;
        EnergyVampire.VampiricScore++;
    }
}
