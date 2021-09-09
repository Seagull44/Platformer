using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBall : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public int bulletObject, bossObj;
    void Start()
    {
        rb.velocity = transform.right * speed;
        bulletObject = LayerMask.NameToLayer("SunEnBullet");
        bossObj = LayerMask.NameToLayer("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(bulletObject, bulletObject, true);
        Physics2D.IgnoreLayerCollision(bulletObject, bossObj, true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                
                player.TakeDamage(2);

            }
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
