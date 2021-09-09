using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShpereDrop : MonoBehaviour
{

    void Start()
    {
        if (MainMenu.Shield >=1)
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Unit"))
        {
            MainMenu.Shield = 1;
            PlayerPrefs.SetInt("ShieldScore", MainMenu.Shield);
            Destroy(gameObject);
        }

    }
}
