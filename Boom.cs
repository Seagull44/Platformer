using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject Explode;
    private Vector3 scaleChange;
    public float timerToDeath;
    
    void Start()
    {
        timerToDeath = 0.4f;
        scaleChange = new Vector3(+0.001f, +0.001f, +0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        Explode.transform.localScale += scaleChange;
        timerToDeath -= Time.deltaTime;
        if (timerToDeath <= 0)
        {
            Destroy(gameObject);
        }
    }
   
}
