using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBricks2 : MonoBehaviour
{
    Rigidbody2D rb;
    private int enemyObject, bossObject, Unit, Shard;
    public int x, y;
    void Start()
    {
        enemyObject = LayerMask.NameToLayer("Enemy");
        bossObject = LayerMask.NameToLayer("Boss");
        Unit = LayerMask.NameToLayer("Player");
        Shard = LayerMask.NameToLayer("Shard");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(x, y), ForceMode2D.Impulse);

        Physics2D.IgnoreLayerCollision(Shard, enemyObject, true);
        Physics2D.IgnoreLayerCollision(Shard, bossObject, true);
        Physics2D.IgnoreLayerCollision(Shard, Shard, true);
        Physics2D.IgnoreLayerCollision(Shard, Unit, true);
    }
}
