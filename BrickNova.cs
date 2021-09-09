using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickNova : MonoBehaviour
{
    /*public GameObject sz,sv,yz,yv;*/
    private int Decor, Shard;
    BoxCollider2D bc;
   
    public Rigidbody2D sv;
    SpriteRenderer SR;
   
    public Rigidbody2D sz;
    void Start()
    {
        
        Decor = LayerMask.NameToLayer("Decor");
        bc = GetComponent<BoxCollider2D>();
        SR = GetComponent<SpriteRenderer>();
        sv = GetComponent<Rigidbody2D>();
        sz = GetComponent<Rigidbody2D>();


    }

    
    void Update()
    {
        Physics2D.IgnoreLayerCollision(Decor, Decor, true);
        Physics2D.IgnoreLayerCollision(Decor, Shard, true);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            MiniBricks.Drop = true;

         

            sz.AddForce(new Vector2(-4, 7), ForceMode2D.Impulse);
            sv.AddForce(new Vector2(4, 7), ForceMode2D.Impulse);

           /* bc.enabled = false;*/
            SR.enabled = false;


            /*sz.transform.AddForce(new Vector2(x, y), ForceMode2D.Impulse);*/
        }
    }
}