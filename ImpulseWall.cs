using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseWall : MonoBehaviour
{
    private bool PlayerLeft;
    private Transform player;
    public float x;
    private float PlayerX;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Unit").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerX = player.position.x;
        
        if(PlayerX > x)
          {
            PlayerLeft = false;
          }
        if(PlayerX < x)
          {
            PlayerLeft = true;
          }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Unit"))
        {
         if (PlayerLeft == false)
            {
                Player.RightImpule = true;
                Debug.Log(1);
            }
         if (PlayerLeft == true)
            {
                Player.LeftImpule = true;
                Debug.Log(2);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.name.Equals("Unit"))
        {
            if (PlayerLeft == false)
            {
                Player.RightImpule = true;
                Debug.Log(1);
            }
            if (PlayerLeft == true)
            {
                Player.LeftImpule = true;
                Debug.Log(2);
            }
        }
    }
}