using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject door;
    public GameObject Boss;
    public int trapX;
    public GameObject player;

    private void CloseTheDoor()
    {
       
        if (player.transform.position.x >= trapX)
        {
            door.SetActive(true);
            Boss.SetActive(true);
        }
    }
}
