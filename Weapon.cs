using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Bullet;
    public float RotateZ;
    public Joystick Wjoystic;
    public Transform Pose;
    public bool Shooted;
    public float Timer;
    public static float reload = 0.8f;
  


    private void Start()
    {
        Load();
        Timer = reload;
        Shooted = false;
        if (Ammo.damage >=5 &&  Ammo.damage < 10)
        {
            reload = 0.7f;
        }
        if (Ammo.damage >= 10 && Ammo.damage <15)
        {
            reload = 0.6f;
        }
        if (Ammo.damage >= 15 && Ammo.damage < 20)
        {
            reload = 0.5f;
        }
        if (Ammo.damage >= 20)
        {
            reload = 0.4f;
        }
    }
    void Update()
    {
        WeaponRotate();
       
        
        if (Shooted == true)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                Shooted = false;
                Timer = reload;
            }
        }
       
        
    }
    void Shoot ()
    {
        Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
        Shooted = true;
    }
    private void WeaponRotate()
    {
        if (Wjoystic.Horizontal > 0)
        {
            RotateZ = Mathf.Atan2(Wjoystic.Vertical, Wjoystic.Horizontal) * Mathf.Rad2Deg;
            Pose.rotation = Quaternion.Euler(0, 0, RotateZ);
            if (Shooted == false)
            {
                Shoot();
            }
           
        }
       else if(Wjoystic.Horizontal < 0)
        {
            RotateZ =  Mathf.Atan2(Wjoystic.Vertical, -Wjoystic.Horizontal) * Mathf.Rad2Deg;
            Pose.rotation = Quaternion.Euler(0, 180, RotateZ);
            if (Shooted == false)
            {
                Shoot();
            }
        }
        if (Wjoystic.Horizontal == 0 && Wjoystic.Vertical == 0)
        {
            Pose.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    void Load ()
    {

    }
}

