﻿
using UnityEngine;

public class Cam : MonoBehaviour
{

    public GameObject player;

  
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -15f); 
    }
}
