using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkPortal : MonoBehaviour
{
    BoxCollider2D bc;
    public GameObject exitSpot;
    public GameObject SecondPortal;
    private void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
           other.transform.position = exitSpot.transform.position;
            StartCoroutine(Stop());
            /*Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Stop();
            }*/
        }
    }
    IEnumerator Stop ()
    { 
        Player.StopIsActive = true;
        yield return new WaitForSeconds(0.5f);
        Player.StopIsActive = false;
    }
}
 