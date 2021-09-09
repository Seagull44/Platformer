using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSphere : MonoBehaviour
{
    public float startWaitTime;
    public float waitTime;
    public GameObject Lightning;
    public GameObject myself;
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            Lightning.SetActive(true);
        }
        if (waitTime <= -1.4)
        {
            waitTime = startWaitTime;
            Lightning.SetActive(false);
            myself.SetActive(false);

        }
    }
}
