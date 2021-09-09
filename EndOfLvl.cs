using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndOfLvl : MonoBehaviour
{
    public GameObject portal;
    private Vector3 scaleChange;
    public GameObject bar;

    void Start()
    {
        scaleChange = new Vector3(-0.0015f, -0.0015f, -0.0015f);
    }
    void Update()
    {
        portal.transform.localScale += scaleChange;

        if (portal.transform.localScale.y < 0.7f || portal.transform.localScale.y > 1.0f)
        {
            scaleChange = -scaleChange;
        }
    }
    public GameObject EndLvlPan;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Unit"))
        {
            
            MainMenu.TotalScore += Player.Coins;
            PlayerPrefs.SetInt("DropsCount", Shop.godDropCount);
            Save();
            EndLvlPan.SetActive(true);
            Destroy(bar);
       
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.PauseGame();
            }
            Player.CheckPointActive = false;
            EnergyVampire.VampiricScore = 0;
            Debug.Log(MainMenu.TotalScore);   
        }
    }
    public void Save()
    {
        PlayerPrefs.SetInt("Score", MainMenu.TotalScore);
        PlayerPrefs.SetInt("L", SceneManager.GetActiveScene().buildIndex +1);
    }
}
