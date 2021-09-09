using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DyingSpot : MonoBehaviour
{
    public int LineOfDying;
  
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < LineOfDying)
        {
            Destroy(gameObject);
        }
    }
}
