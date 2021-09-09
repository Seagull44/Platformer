using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Crystal : MonoBehaviour
{
    public float startWaitTime;
    private float waitTime;
    public int HP;
    public bool isActive;
    public int SkillTime;
    public int point;
    public int SkillDown;
    public GameObject CircleOfActivity;
    public static int markerIsActive;
    
    void Start()
    {
        isActive = false;
        waitTime = startWaitTime;
        if (PlayerPrefs.HasKey("Marker"))
        {
            markerIsActive = PlayerPrefs.GetInt("Marker");
        }
        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            if (markerIsActive == point || markerIsActive >= 4)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
        {
            waitTime = startWaitTime;
        }
        if (waitTime <= SkillTime && waitTime >= SkillDown)
        {
            StartCoroutine(RayActive());
        }
        if (isActive == true)
        {
            CircleOfActivity.SetActive(true);
        }
        else
        {
            CircleOfActivity.SetActive(false);
        }
    }
    public void TakeDamage(int damage)
    {
        if (isActive == true)
        {
            HP -= damage;
        }
        if (isActive == false)
        {

        }
        if (HP <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        /*GameObject.Find("yellow_crystal (1)").SetActive(false);*/
        markerIsActive += point;
        point = 0;
        DarkBoss.CrystalIsActive = 0;
        Destroy(gameObject);
        DarkBoss.Stun = true;
        Player.Coins += 100;
        PlayerPrefs.SetInt("Marker", markerIsActive);
    }
    IEnumerator RayActive()
    {
       
        if (SceneManager.GetActiveScene().buildIndex == 18)
        {
            GoldenMiniBoss.CrystalIsActive = point;
            isActive = true;
            yield return new WaitForSeconds(8f);
            isActive = false;
            GoldenMiniBoss.CrystalIsActive = 0;
        }
        else
        {
            DarkBoss.CrystalIsActive = point;
            isActive = true;
            yield return new WaitForSeconds(8f);
            isActive = false;
            DarkBoss.CrystalIsActive = 0;
        }
    }
}
