using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles = new Vector3(0, 0, 45);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles = new Vector3(0, 180, 45);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.W) && Player.Inversion == false)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.W) && Player.Inversion == true)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
            if (Input.GetKeyUp(KeyCode.Q))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}