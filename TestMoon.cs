using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoon : MonoBehaviour
{
    public GameObject Center;
    public float MaxR;
    public float RandomDist;
    public float MinR;

    float a, y, x1, y1;

    public float curAngle;

    void Start()
    {
        a = Vector3.Distance(Center.transform.position, transform.position);
        y = Mathf.Sqrt(MaxR * MaxR - a * a);
        y = Random.Range(y, y + RandomDist);
        transform.Translate(0, y, 0);
    }

    void Update()
    {
        if (transform.position.y < -250)
        {
            Destroy(gameObject);
        }
        transform.LookAt(Center.transform);

        curAngle = transform.localEulerAngles.z;

        x1 = MaxR * Mathf.Cos(curAngle);
        y1 = MinR * Mathf.Sin(curAngle);
        transform.localPosition = new Vector3(x1, y1);
    }
}
