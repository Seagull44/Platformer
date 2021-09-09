using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    public int HP;
    public int Speed;
    private int randomSpot;
    public Transform[] MoveSpots;
    public float TimeToSwitch;
    public float startTime;
    private Transform player;
    private Vector2 target;
    public float shootingDistance;
    public bool Stalking;
    public bool TakingCoords;
    public GameObject Gun;
    BoxCollider2D bc;
    public GameObject SpriteOfActivity;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        TakingCoords = false;
        Stalking = false;
        randomSpot = Random.Range(0, MoveSpots.Length);
        player = GameObject.FindGameObjectWithTag("Unit").transform;
       
    }


    // Update is called once per frame
    void Update()
    {
        TimeToSwitch -= Time.deltaTime;
        if (Vector2.Distance(transform.position, player.position) < shootingDistance)
        {
            Stalking = true;
        }
        if (TakingCoords == true)
        {
            target = new Vector2(MoveSpots[randomSpot].position.x, MoveSpots[randomSpot].position.y);
            TakingCoords = false;
           
        }
        if (Stalking == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
            if (TimeToSwitch <= 0)
            {
               
                TakingCoords = true;
                randomSpot = Random.Range(0, MoveSpots.Length);
                TimeToSwitch = startTime;
                
            }
        }
        if (Vector2.Distance(transform.position, target) <= 2 )
        {
            SpriteOfActivity.SetActive(true);
            Gun.SetActive(true);
            bc.enabled = true;
        }
        else
        {
            SpriteOfActivity.SetActive(false);
            bc.enabled = false;
            Gun.SetActive(false);
        }
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Player.Coins += 200;
            Destroy(gameObject);
            EnergyVampire.VampiricScore++;
        }
    }
}
