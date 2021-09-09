using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndLvlPan : MonoBehaviour
{
    public Button GoToMainMenu;
    public Button NextLvl;

    public void GotoMainMenu()
    {
       Time.timeScale = 1;
       SceneManager.LoadScene(0);
    }
    public void GoToNextLvl()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
