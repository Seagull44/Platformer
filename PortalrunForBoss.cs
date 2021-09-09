using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalrunForBoss : MonoBehaviour
{
   
    public float speed;
    private Transform Spot;
    private Vector2 target;

    void Start()
    {
        Spot = GameObject.FindGameObjectWithTag("Spot").transform;

    }
    void Update()
    {
        target = new Vector2(Spot.position.x, Spot.position.y);
        transform.position = target;
        
       
    }
}
