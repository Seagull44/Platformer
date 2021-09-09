using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreGround : MonoBehaviour
{
    private int bulletObject, enemyObject, bossObject, SparkObject, DefaultOb, decorObject, destroyObject, LavaOb, ColOb;
    void Start()
    {
        bulletObject = LayerMask.NameToLayer("Bullet");
        enemyObject = LayerMask.NameToLayer("Enemy");
        bossObject = LayerMask.NameToLayer("Boss");
        SparkObject = LayerMask.NameToLayer("Stop");
        DefaultOb = LayerMask.NameToLayer("Default");
        decorObject = LayerMask.NameToLayer("Decor");
        destroyObject = LayerMask.NameToLayer("Destroyed");
        LavaOb = LayerMask.NameToLayer("Lava");
        ColOb = LayerMask.NameToLayer("Collide");
        
    }

   
    void Update()
    {
        Physics2D.IgnoreLayerCollision(SparkObject, bulletObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, enemyObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, bossObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, SparkObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, DefaultOb, true);
        Physics2D.IgnoreLayerCollision(SparkObject, decorObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, destroyObject, true);
        Physics2D.IgnoreLayerCollision(SparkObject, LavaOb, true);
    }
}
