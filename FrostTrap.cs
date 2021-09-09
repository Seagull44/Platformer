using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostTrap : MonoBehaviour
{
    public GameObject Snow;
    public bool fade;
    public float x;
 
   public SpriteRenderer sr;
    void Start()
    {        
        fade = false;
        sr = GetComponent<SpriteRenderer>();
        x = 0.2f;
    }

    void Update()
    {

        if (fade == true)
        {
            Color color = Snow.GetComponent<Renderer>().material.color;
            color.a -= x * Time.deltaTime;
            Snow.GetComponent<Renderer>().material.color = color;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Unit"))
        {
            StartCoroutine(RayActive());
        }
    }
    IEnumerator RayActive()
    {
      
        Snow.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        fade = true;
        yield return new WaitForSeconds(4f);
        Snow.SetActive(false);
        Destroy(gameObject);
   
    }
}
