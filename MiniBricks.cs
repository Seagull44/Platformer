using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBricks : MonoBehaviour
{
    Rigidbody2D rb;
    private int enemyObject, bossObject, Unit, Shard;
    public int x, y;
    public Transform CenterOfBrick;
    public Transform Point;
    public GameObject DropObj;
    public static bool Drop;
    void Start()
    {

        Drop = false;
        enemyObject = LayerMask.NameToLayer("Enemy");
        bossObject = LayerMask.NameToLayer("Boss");
        Unit = LayerMask.NameToLayer("Player");
        Shard = LayerMask.NameToLayer("Shard");
        rb = GetComponent<Rigidbody2D>();
        if  (Point.position.x > CenterOfBrick.position.x)
        {x = 4;}
        if (Point.position.x < CenterOfBrick.position.x)
        {x = -4;}
        if (Point.position.y < CenterOfBrick.position.y)
        {y = -2;}
        if (Point.position.y > CenterOfBrick.position.y)
        {y = 7;}
        if (Point.position.x == CenterOfBrick.position.x)
        {x = 0;}
        if (Point.position.y == CenterOfBrick.position.y)
        { y = 1; }
       

    }

     void Update()
    {

        if (Drop == true)
        {
            Instantiate(DropObj, transform.position, Quaternion.identity);
            rb.AddForce(new Vector2(x, y), ForceMode2D.Impulse);
            Drop = false;
        }
        Physics2D.IgnoreLayerCollision(Shard, enemyObject, true);
        Physics2D.IgnoreLayerCollision(Shard, bossObject, true);
        Physics2D.IgnoreLayerCollision(Shard, Shard, true);
        Physics2D.IgnoreLayerCollision(Shard, Unit, true);
    }
}
