using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbWeapon : MonoBehaviour
{
    public int z = 0;
    public float timerToShoot;
    public GameObject Bullet;
    public Transform FirePoint;
    void Start()
    {
        timerToShoot = 2f;
        transform.eulerAngles = new Vector3(0, 0, z);
    }

    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, z);
        timerToShoot -= Time.deltaTime;
        if (timerToShoot <=0)
        {
            Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
            timerToShoot = 0.11f;
            z += 17;
        }
    }
}
