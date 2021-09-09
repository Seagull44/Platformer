using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeBranch : MonoBehaviour
{
    public GameObject AltPanel;
    public GameObject Lightning;
    public GameObject EndLvlPan;
    BoxCollider2D bc;

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        
        
            if (col.gameObject.name.Equals("Unit"))
            {
            Player.StopIsActive = true;
            AltPanel.SetActive(true);
            StartCoroutine(RayActive());
            }
    }
    IEnumerator RayActive()
    {
        yield return new WaitForSeconds(1);
        Lightning.SetActive(true);
        yield return new WaitForSeconds(1f);
        Lightning.SetActive(false);
        yield return new WaitForSeconds(1f);
        Lightning.SetActive(true);
        yield return new WaitForSeconds(1f);
        MainMenu.TotalScore += Player.Coins;
        MainMenu.GhostMode = 1;
        PlayerPrefs.SetInt("GhostMode", MainMenu.GhostMode);
        PlayerPrefs.SetInt("DropsCount", Shop.godDropCount);
        Save();
        EndLvlPan.SetActive(true);
        Player.BossIsDead = false;
        Player.CheckPointActive = false;
        EnergyVampire.VampiricScore = 0;
        Debug.Log(MainMenu.TotalScore);
    }
    public void Save()
    {
        PlayerPrefs.SetInt("Score", MainMenu.TotalScore);
    }
}
