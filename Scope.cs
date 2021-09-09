using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    private Transform player;
    public Transform Firepoint;
    private Vector2 target;
    public float PlusMinusZeroY;
    public float PlusMinusZeroX;
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Unit").transform;
        target = new Vector2(player.position.x + PlusMinusZeroX, player.position.y + PlusMinusZeroY);
        if (PlusMinusZeroX > 0)
        {
            PlusMinusZeroX -= Time.deltaTime;
        }
    }
    public void Shoot()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(Firepoint.position, target);
    }
}
