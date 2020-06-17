using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    public int Damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Unit"))
        {
            Player player = collision.GetComponent<Player>();
           
            player.TakeDamage(Damage);
           

        }
    }

}