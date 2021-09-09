using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDown : MonoBehaviour
{
    public GameObject One;
    public GameObject Two;
    public float startWaitTime;
    public float waitTime;
    public int i;
    void Start()
    {
        i = 0;
        waitTime = startWaitTime;
        One.SetActive(false);
        Two.SetActive(false);
    }
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            i++;
            waitTime = startWaitTime;
        }
        if (i == 1)
        {
            One.SetActive(true);
            Two.SetActive(false);
        }
        if (i == 2)
        {
            One.SetActive(false);
            Two.SetActive(true);
        }
        if (i == 3)
        {
            i = 1;  
        }
    }
}
