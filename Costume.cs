using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costume : MonoBehaviour
{
    public GameObject[] obj;
    public int number;
    private void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            for (int index = 0; index < number; index++)
            { Kamikadze other = obj[index].GetComponent<Kamikadze>();
                other.enabled = true;
              Enemy othertwo = obj[index].GetComponent<Enemy>();
                othertwo.enabled = false;
            }
            
            
            
            /* Release();*/
        }

    }
/*        public void Release()
        {
            StartCoroutine(Active());
        }
        IEnumerator Active()
        {
            Kamikadze.plus += 20;
            yield return new WaitForSeconds(12);
            Kamikadze.plus -= 20;
    }*/
}
