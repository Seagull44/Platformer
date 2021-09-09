using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFear : MonoBehaviour
{
    public bool Groundfear;
    public bool Decorfear;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Ground")
            if (Groundfear == true)
            { Destroy(gameObject); }
        if (collision.gameObject.tag == "Decor")
            if (Decorfear == true)
            { Destroy(gameObject); }
    }
}