using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaPoint : MonoBehaviour
{   
    public Transform FirePoint;
    public GameObject LavaBullet;
   
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
    
        if (waitTime <=0)
        {
            Shoot();
            waitTime = startWaitTime;
        }
       
      

}
    void Shoot()
    {
        Instantiate(LavaBullet, transform.position, Quaternion.identity);
    }
}
