using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHuld : MonoBehaviour
{
    Rigidbody2D rb;
    public GameObject CenterOfRotate;
    public GameObject itemHuld;
    private int Item, bulletObject, defaultObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletObject = LayerMask.NameToLayer("Bullet");
        Item = LayerMask.NameToLayer("Item");
        defaultObject = LayerMask.NameToLayer("Default");
    }
    void Update()
    {
        CenterOfRotate.transform.Rotate(0, 0, -40 * Time.deltaTime * 4);
        itemHuld.transform.Rotate(0, 0, 40 * Time.deltaTime * 4);
       
        Physics2D.IgnoreLayerCollision(Item, bulletObject, true);
        Physics2D.IgnoreLayerCollision(Item, defaultObject, true);
        if (MainMenu.ItemForHuld == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
            MainMenu.ItemForHuld = 1;
            PlayerPrefs.SetInt("ItemForHuld", MainMenu.ItemForHuld);
            Destroy(gameObject);
            Debug.Log(MainMenu.ItemForHuld);
    }
}