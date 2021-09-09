using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyVampire : MonoBehaviour
{
    public static int VampiricScore;
    public Button firstBttn;
    public GameObject EV;
    public GameObject firstBtnObject;
    private void Start()
    {

       
    }
    private void Update()
    {
        if (VampiricScore >= 10)
            VampiricScore = 10;
           firstBttn.interactable = true;
        if (VampiricScore < 10)
         firstBttn.interactable = false;
        /*if (Shop.EnergyVampireItem == true)
        {
            firstBtnObject.SetActive(true);
            EV.SetActive(true);
        }*/
    }
    public void UseFirstBtn()
    {
        Player.health++;
        VampiricScore = 0;
        Debug.Log(VampiricScore);
    }
}
