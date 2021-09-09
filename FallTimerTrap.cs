using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallTimerTrap : MonoBehaviour
{
    public float timeToFall;
   
    bool SelfDestroy = false;
    public GameObject mark1, mark2;



    void Update()
    {
        if (SelfDestroy == true)
        timeToFall -= 1 * Time.deltaTime;
        if (timeToFall <= 1)
            Destroy(mark1);
        if (timeToFall <= 0.5)
            Destroy(mark2);
        if (timeToFall <= 0)
            Destroy(gameObject);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Unit")
        {
            SelfDestroy = true;
        }
           
        
           
      


    }
    
}
