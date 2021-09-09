using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebufGun : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public float shootingDistance;
    public GameObject Snow;
    public bool fade;
    public float x;
    private int freezeObject, ItemObj, Boss, CoinOb;



    void Start()
    {
        fade = false;
        freezeObject = LayerMask.NameToLayer("freeze");
        CoinOb = LayerMask.NameToLayer("Coin");
        ItemObj = LayerMask.NameToLayer("Item");
        Boss = LayerMask.NameToLayer("Boss");
        x = 0.2f;
        player = GameObject.FindGameObjectWithTag("Unit").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyBullet();
        }
        Physics2D.IgnoreLayerCollision(Boss, ItemObj, true);
        Physics2D.IgnoreLayerCollision(freezeObject, ItemObj, true);
        Physics2D.IgnoreLayerCollision(freezeObject, freezeObject, true);
        Physics2D.IgnoreLayerCollision(ItemObj, ItemObj, true);
        Physics2D.IgnoreLayerCollision(freezeObject, CoinOb, true);
        Physics2D.IgnoreLayerCollision(ItemObj, CoinOb, true);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                Destroy(gameObject);
                DestroyBullet();
            }
            Destroy(gameObject);
        }

        if (other.CompareTag("Ball"))
        {
            DestroyBullet();
            Destroy(gameObject);
        }
        if (other.CompareTag("Decor"))
        {
            DestroyBullet();
            Destroy(gameObject);
        }
        if (other.CompareTag("Ground"))
        {
            DestroyBullet();
            Destroy(gameObject);
        }
    }
   
    void DestroyBullet()
    {
        Instantiate(Snow, transform.position, Quaternion.identity);
        speed = 0;
        Destroy(gameObject);
    }
}
