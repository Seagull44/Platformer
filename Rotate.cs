using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject CenterOfRotate;
    public int speed;
    void Update()
    {
     CenterOfRotate.transform.Rotate(0, 0, speed * Time.deltaTime * 4);
    }
}
