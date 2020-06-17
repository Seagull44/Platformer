using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    public int heal;

    // Update is called once per frame


    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            Player player = other.GetComponent<Player>();

            player.TakeHeal(heal);



        }
    }
}
