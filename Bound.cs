using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bound : MonoBehaviour
{
    public int i;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Boss") && i==0)
        {
            GoldenMiniBoss.Stoping = true;
        }
        if (other.gameObject.tag == "Unit" && i ==1)
        {
            GoldenMiniBoss.Stoping = false;
            GoldenMiniBoss.Boosting = true;
            Debug.Log(1);
        }
    }
}
