using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondSkin : MonoBehaviour
{
    
    public float speed;
    private Transform boss;
    private Vector2 target;

    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss").transform;

    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        target = new Vector2(boss.position.x, boss.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}