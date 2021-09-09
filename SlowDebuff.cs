using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDebuff : MonoBehaviour
{
    
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Unit") && Player.SlowDebuff == false)
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                StartCoroutine(Slow());
            }
            
        }
       
    }
    IEnumerator Slow()
    {
        Player.SlowDebuff = true;
        yield return new WaitForSeconds(4f);
        Player.SlowDebuff = false;
    }

}