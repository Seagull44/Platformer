using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roots : MonoBehaviour
{



    public GameObject Myself;
    private Vector3 scaleChange;

    public float timerToDeath;
    public bool Groving;
    public bool Die;
    public Button Left, right, up;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 180);
        Groving = true;
        timerToDeath = 0.9f;
        scaleChange = new Vector3(+0.001f, +0.002f, +0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        timerToDeath -= Time.deltaTime;
        if (Groving == true)
        {
            Myself.transform.localScale += scaleChange;
            
            if (timerToDeath <= 0.4f)
            {
                Groving = false;
            }
        }
        if (timerToDeath <=0f && Die == true)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Unit"))
        {
            if (Groving == false)
            {
                Die = false;
                StartCoroutine(Stop());
            }
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            if (Groving == false)
            {
                Die = false;
                StartCoroutine(Stop());
            }
        }
    }
    IEnumerator Stop()
    {
        
        Player.StopIsActive = true;
        yield return new WaitForSeconds(2f);
        Player.StopIsActive = false;
        
        Destroy(gameObject);
    }
}
