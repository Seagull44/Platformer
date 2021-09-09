using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunTheSniper : MonoBehaviour
{
    public GameObject Scope;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    IEnumerator GhostModeActive()
    {
        Scope.SetActive(true);
        yield return new WaitForSeconds(3);
        Scope.SetActive(false);
    }
}
