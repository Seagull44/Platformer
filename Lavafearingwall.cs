using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lavafearingwall : MonoBehaviour
{
    public int Points;
    public int Death;

    private void Update()
    {
        if (Points >= Death)
            DestroyObj();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Lava")
            PointsPlus();

        if (collision.gameObject.tag == "FireBall")
        {
            PointsPlus();
            FireBall.i++;
        }
    }
    void DestroyObj ()
    {
        Destroy(gameObject);
    }
    public void PointsPlus ()
    {
        Points++;
    }
}
