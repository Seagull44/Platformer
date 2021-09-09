using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RapidFire : MonoBehaviour
{
    public float speed;
    private Transform player;
    private Vector2 target;
    public float PlusMinusZero;
    public int Damage;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 5)
        {Damage = 2;}
        if (SceneManager.GetActiveScene().buildIndex >= 6 && SceneManager.GetActiveScene().buildIndex <= 10)
        {Damage = 3;}
        if (SceneManager.GetActiveScene().buildIndex >=11)
        {Damage = 4;}
        if (Player.NumberOfShooted == 0)
        {PlusMinusZero = 0;}
        if (Player.NumberOfShooted == 1)
        {PlusMinusZero = 1f;}
        if (Player.NumberOfShooted == 2)
        {PlusMinusZero = -1f;}
        player = GameObject.FindGameObjectWithTag("Unit").transform;
        target = new Vector2(player.position.x, player.position.y + PlusMinusZero);
        Player.NumberOfShooted++;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {DestroyBullet();}
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {player.TakeDamage(Damage);}
            DestroyBullet();
        }
        if (other.CompareTag("Ball"))
        {DestroyBullet();}
        if (other.CompareTag("Decor"))
        {DestroyBullet();}
        if (other.CompareTag("Ground"))
        {DestroyBullet();}
    }
    void DestroyBullet()
    {Destroy(gameObject);}
}
