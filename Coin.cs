using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private int bulletObject, coinObject, enemyObject, healerObject;
    private void Start()
    {
        bulletObject = LayerMask.NameToLayer("Bullet");
        coinObject = LayerMask.NameToLayer("Coin");
        enemyObject = LayerMask.NameToLayer("Enemy");
        healerObject = LayerMask.NameToLayer("Healer");
    }
    private void Update()
    {
        Physics2D.IgnoreLayerCollision(coinObject, bulletObject, true);
        Physics2D.IgnoreLayerCollision(coinObject, enemyObject, true);
        Physics2D.IgnoreLayerCollision(coinObject, healerObject, true);
        Physics2D.IgnoreLayerCollision(coinObject, coinObject, true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Player.Coins++;
        Destroy(gameObject);
    }
}
    
    
