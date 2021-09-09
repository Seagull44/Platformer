using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{
    public GameObject CenterOfRotate;
    public GameObject moon;
    public float speed;
    private Transform player;
    private Vector2 target;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Unit").transform;
       
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        target = new Vector2(player.position.x, player.position.y);
        CenterOfRotate.transform.Rotate(0, 0, -20 * Time.deltaTime * 4);
        moon.transform.Rotate(0, 0, 30 * Time.deltaTime * 4);            
    }
}
