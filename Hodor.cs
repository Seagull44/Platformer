using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hodor : MonoBehaviour
{
    public GameObject DoorToClose, Active;
    void Start()
    {
        DoorToClose.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Unit")
        {
            DoorToClose.SetActive(true);
            Active.SetActive(true);
            Destroy(gameObject);
        }
    }
}
