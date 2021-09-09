using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingSprite : MonoBehaviour
{
    public GameObject Sprite;
    private Vector3 scaleChange;
    public float x, y, z, I;
    void Start()
    {
       /* scaleChange = new Vector3(-0.0005f, -0.0005f, -0.0005f);*/
        scaleChange = new Vector3(x, y, z);
    }

    void Update()
    {
       /* Sprite.transform.Rotate(0, 0, -20 * Time.deltaTime * 3);*/
        Sprite.transform.Rotate(0, 0, I * Time.deltaTime * 3);
        Sprite.transform.localScale += scaleChange;

        if (Sprite.transform.localScale.y < 0.7f || Sprite.transform.localScale.y > 1.0f)
        {
            scaleChange = -scaleChange;
        }
    }
}
