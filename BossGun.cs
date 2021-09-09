using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGun : MonoBehaviour
{
    private float TimeBtwShots;
    public float startTimeBtwShots;
    public float shootingDistance;
    public GameObject projectile;
    public Transform player;
    void Start()
    {
        
    }

    void Update()
    {
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
}
