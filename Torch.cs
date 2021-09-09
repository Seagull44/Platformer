using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    public bool active;
    public GameObject firstPortal;
    private Vector3 scaleChange;
    public GameObject TorchGo;
    BoxCollider2D bc;
    void Start()
    {
        active = false;
        scaleChange = new Vector3(+0.01f, +0.01f, +0.01f);
        bc = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        if (active == true && firstPortal.transform.localScale.x<1)
        {
            firstPortal.transform.localScale += scaleChange;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Unit" && MainMenu.WizzardStuff ==1)
        {
            active = true;
            TorchGo.SetActive(true);
            
        }
    }
}
