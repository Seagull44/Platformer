using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
        {
            DestroyBullet();
        }
        if (collision.gameObject.tag == "Decor")
        {
            DestroyBullet();
        }
        Destroy(gameObject);
    }


    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
