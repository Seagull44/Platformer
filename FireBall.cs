using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public static int i;
    private int enObject, fbObject, bossObject;
    void Start()
    {
        i = 0;
        enObject = LayerMask.NameToLayer("Enemy");
        fbObject = LayerMask.NameToLayer("EnBullet");
        bossObject = LayerMask.NameToLayer("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(enObject, fbObject, true);
        Physics2D.IgnoreLayerCollision(fbObject, bossObject, true);
        if (i == 1)
        {
            DestroyBullet();
        }
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

    }


        public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
