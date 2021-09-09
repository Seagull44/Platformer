using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
   
    public GameObject WizzardStuff;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
        if (MainMenu.WizzardStuff>=1)
        {
            Destroy(WizzardStuff);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Unit")
        {
            MainMenu.WizzardStuff = 1;
            PlayerPrefs.SetInt("Wizzard", MainMenu.WizzardStuff);

            Destroy(gameObject);
        }
    }
}
