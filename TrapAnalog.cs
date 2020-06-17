using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAnalog : MonoBehaviour
{
    public GameObject ray;
    BoxCollider2D bc;

    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Unit"))
        {
            StartCoroutine (RayActive());
        }
    }
    IEnumerator RayActive()
    {
        bc.enabled = false;
        yield return new WaitForSeconds(1f);
        ray.SetActive(!ray.activeSelf);
        yield return new WaitForSeconds(1f);
        ray.SetActive(!ray.activeSelf);
        bc.enabled = true;


    }
}
