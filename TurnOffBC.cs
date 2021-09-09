using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffBC : MonoBehaviour
{
    BoxCollider2D bc;
    public GameObject SpriteOfActivity;
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag == "VoidBall")
        {
            StartCoroutine(bcSwitcher());
        }
    }
        IEnumerator bcSwitcher()
    {
        SpriteOfActivity.SetActive(false);
        bc.enabled = false;
        yield return new WaitForSeconds(2f);
        bc.enabled = true;
        SpriteOfActivity.SetActive(true);
    }
}
