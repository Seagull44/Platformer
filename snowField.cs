using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowField : MonoBehaviour
{
    public bool fade;
    public float x;
    
    SpriteRenderer sr;
    void Start()
    {
        fade = false;
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RayActive());
        if (fade == true)
        {
            Color color = sr.GetComponent<Renderer>().material.color;
            color.a -= x * Time.deltaTime;
            sr.GetComponent<Renderer>().material.color = color;
        }
    }
    IEnumerator RayActive()
    {
        yield return new WaitForSeconds(0.1f);
        fade = true;
        yield return new WaitForSeconds(3f);
        
        Destroy(gameObject);

    }
}
