using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyedDoor : MonoBehaviour
{
    public int health;
    public GameObject Stop;
    public GameObject Door;
    public GameObject Treasure;

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
        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            if (Crystal.markerIsActive == 5 && GoldenMiniBoss.Agr == false && Player.BossIsDead == false)
            {
                Treasure.SetActive(true);
                Destroy(Door);
            }
        }
        Destroy(gameObject);
        Destroy(Stop);
    }
}