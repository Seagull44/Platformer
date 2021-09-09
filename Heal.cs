using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int heal;

   


    private void OnTriggerStay2D (Collider2D other)
    {
        if (other.gameObject.name.Equals("Unit"))
        {
            Player player = other.GetComponent<Player>();

            player.TakeHeal(heal);



        }
    }
}
