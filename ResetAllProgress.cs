using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAllProgress : MonoBehaviour
{
    
  public void ResetAll ()
    {
        PlayerPrefs.DeleteAll();
    }
}
