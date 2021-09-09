using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;

public class PlateTrap : MonoBehaviour
{
    public Transform firepoint;
    public int Damage = 2;
    /* private int PlateObject, collideObject;*/
    public LineRenderer lineRenderer;
    

    void Update()
    {
        /*collideObject = LayerMask.NameToLayer("Collide");
        PlateObject = LayerMask.NameToLayer("Plate");*/
      if (Player.Coins <= 0 )
        {
            lineRenderer.enabled = false;
        }
     
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
        StartCoroutine(trap());    
    }
   
  IEnumerator trap ()
    {
        yield return new WaitForSeconds(1f);

                {
            RaycastHit2D hitinfo = Physics2D.Raycast(firepoint.position, firepoint.up);
            if (hitinfo)
            {
                Debug.Log(hitinfo.transform.name);
                Player player = hitinfo.transform.GetComponent<Player>();
                if (player != null)
                {
                    player.TakeDamage(Damage);
                }

                lineRenderer.SetPosition(0, firepoint.position);
                lineRenderer.SetPosition(1, hitinfo.point);
            }
            else
            {

                lineRenderer.SetPosition(0, firepoint.position);
                lineRenderer.SetPosition(1, firepoint.position + firepoint.up * 100);

            }


        }







            lineRenderer.enabled = true;

        yield return new WaitForSeconds(1f);

        lineRenderer.enabled = false; 
    }
    

}
