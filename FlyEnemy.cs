using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : MonoBehaviour
{
    public int health = 2;
    public float speed = 2f;
    public Transform player;
    public int RMoveDistance;
    public int LMoveDistance;
    private float TimeBtwShots;
    public float startTimeBtwShots;
    public float shootingDistance;

    public GameObject projectile;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Unit").transform;
        TimeBtwShots = startTimeBtwShots;
    }
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x >= RMoveDistance)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

        }
        else if (transform.position.x <= LMoveDistance)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        if (TimeBtwShots <= 0 && (Vector2.Distance(transform.position, player.position) < shootingDistance))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            TimeBtwShots = startTimeBtwShots;
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }
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
        Player.Coins += 15;
    }
}