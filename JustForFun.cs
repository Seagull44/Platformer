using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JustForFun : MonoBehaviour
{
    public float TimeToTrueVision = 1;

    bool NowUSeeMe = false;
    SpriteRenderer Sprite;
    
    
    void Start()
    {
       Sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (NowUSeeMe == true)
            TimeToTrueVision -= 1 * Time.deltaTime;
           


        if (TimeToTrueVision <= 0)
            Sprite.enabled = true;
            

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Unit")
        {
            NowUSeeMe = true;
           
        }






    }
}
