using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int Healing;
    public int TreasureCoins;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.HealingItem(Healing);
            }
            Destroy(gameObject);
            Player.Coins +=TreasureCoins;
        }
    }
}