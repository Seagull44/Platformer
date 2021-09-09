using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MainMenu : MonoBehaviour
{
    public bool Wisp;
    public Button [] MainButtons;
    public GameObject [] MainPanels;
    public Button[] Units;
    public Button[] LvlChoose;
    public int Level = 1;
    public Text LvlNow;
    public static int TotalScore;
    public Text TextOfTotalScore;
    public Text PureEnergyScoreText;
    public static int pureEnergy;
    public Text MaxHealthText;
    public Text attackText;
    public Text BoostCountText;
    public Text CurrentDropsText;
    public static int ItemForHuld;
    public static int WizzardStuff;
    public static int Shield;
    public Button Right;
    public Button Left;
    public GameObject RightBtn;
    public GameObject LeftBtn;
    public GameObject[] firstPageOfButtons;
    public GameObject[] secondPageOfButtons;
    public GameObject[] thirdPageOfButtons;
    public int Page = 1;
    public int pages = 8;
    public static int OpenLevel;
   
    public static bool SkillEV = false;
    public static bool SkillBoost = false;
    public static bool SkillShield = false;
    public static int GhostMode = 0;
    public GameObject SkillEVGO;
    public GameObject SkillBoostGO;
    public GameObject SkillShieldGo;
    


    void Start()
    {
        OpenLevel = 1;
        Page = 1;
        LoadGame();
        this.Level = 0;
        doInitMenu(5);
        doLevelsMenu();
        Player.CheckPointActive = false;

        if (Shop.i < 1)
        {
            SkillEVGO.SetActive(false);
        }
        if (ItemForHuld < 1)
        {
            SkillBoostGO.SetActive(false);
        }
        if (Shield < 1)
        {
            SkillShieldGo.SetActive(false);
        }
    }
    void Update()
    {
        attackText.text = " " + Ammo.damage;
        MaxHealthText.text = " " + (8 + Shop.upgradeHealth); 
        CurrentDropsText.text = " " + Shop.godDropCount;
        LvlNow.text = "Lvl№" + " " + this.Level;
        TextOfTotalScore.text = "Total score" + " " + TotalScore;
        PureEnergyScoreText.text = "Energy score" + " " + pureEnergy;
        BoostCountText.text = " " + Shop.BoostScore;
       
        if (Page == 2)
        {
            for (int index = 0; index < pages; index++)
            {
                secondPageOfButtons[index].SetActive(true);
                firstPageOfButtons[index].SetActive(false);
                thirdPageOfButtons[index].SetActive(false);
            }
            RightBtn.SetActive(true);
            LeftBtn.SetActive(true);
        }
        if (Page >= 3)
        {
            Page = 3;
        }
        if (Page <= 1)
        {
            Page = 1;
        }
        if (Page == 1)
        {
            RightBtn.SetActive(true);
            LeftBtn.SetActive(false);
            for (int index = 0; index < pages; index++)
            {
                firstPageOfButtons[index].SetActive(true);
                secondPageOfButtons[index].SetActive(false);
                thirdPageOfButtons[index].SetActive(false);
            }
        }
        if (Page == 3)
        {
            LeftBtn.SetActive(true);
            RightBtn.SetActive(false);
            for (int index = 0; index < pages; index++)
            {
                thirdPageOfButtons[index].SetActive(true);
                secondPageOfButtons[index].SetActive(false);
                firstPageOfButtons[index].SetActive(false);
            }
        }
        for (int i = 0; i < LvlChoose.Length; i++)
        {
            if (i<= OpenLevel)
            {
                LvlChoose[i].interactable = true;
            }
            else
            {
                LvlChoose[i].interactable = false;
            }
        }
    }
    public void ChangeCurrentLvl(int LvlToChange)
    {
        this.Level = LvlToChange;
    }
    public void Startlvl(int Level)
    {
        SceneManager.LoadScene(Level);
    }
    public void doLevelsMenu() 
    {
      for (int i = 0; i < LvlChoose.Length; i++)
        {
            Button looped = LvlChoose[i];
            int k = i;
            if (i == 0)
            {
                looped.onClick.AddListener(delegate { Startlvl(this.Level); });
                continue;
            }
            looped.onClick.AddListener(() => { this.ChangeCurrentLvl(k); });
        }
    }
    public void showNeededPanel(int panelId, int amountOfPanels) 
    {
        for (int index = 0; index < amountOfPanels; index++) 
        {
            if (panelId == index)
            {
                MainPanels[index].SetActive(!MainPanels[index].activeSelf);
            }
            else 
            {
                MainPanels[index].SetActive(false);
            }
        }
    }
    public void doInitMenu(int amountOfPanels) 
    {
        int[] panels = new int[30];
        for (int index = -1; index < amountOfPanels; index++)
        {
            panels[index + 1] = index;
        }

        foreach (int currentPanelIndex in panels)
        {
            if (currentPanelIndex == -1) 
            {
                continue;
            }
           /* Debug.Log("current index: " + currentPanelIndex + "; " + "amount of panels: " + amountOfPanels + ";");*/
            MainButtons[currentPanelIndex].onClick.AddListener(delegate { showNeededPanel(currentPanelIndex, amountOfPanels); });
        }
    }
    public void GoRight(int firstPageButtons)
    {
        Page++;
        
    }
    public void GoLeft (int secondPageButtons)
    {
        Page--;
    }
    public void ChooseEV ()
    {
        SkillEV = true;
        SkillBoost = false;
        SkillShield = false;
    }

    public void ChooseBoost ()
    {
        SkillEV = false;
        SkillBoost = true;
        SkillShield = false;
    }
    public void ChooseShield ()
    {
        SkillEV = false;
        SkillBoost = false;
        SkillShield = true;
    }
    void LoadGame()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            TotalScore = PlayerPrefs.GetInt("Score");
        }
        if (PlayerPrefs.HasKey("ItemForHuld"))
        {
            ItemForHuld = PlayerPrefs.GetInt("ItemForHuld");
        }
        if (PlayerPrefs.HasKey("Wizzard"))
        {
            WizzardStuff = PlayerPrefs.GetInt("ItemForHuld");
        }
        if (PlayerPrefs.HasKey("UpgradeHP"))
        {
            Shop.upgradeHealth = PlayerPrefs.GetInt("UpgradeHP");
        }
        if (PlayerPrefs.HasKey("EV=1"))
        {
            Shop.i = PlayerPrefs.GetInt("EV=1");
        }
        if (PlayerPrefs.HasKey("DropsCount"))
        {
            Shop.godDropCount = PlayerPrefs.GetInt("DropsCount");
        }
        if (PlayerPrefs.HasKey("PureEnergy"))
        {
            pureEnergy = PlayerPrefs.GetInt("PureEnergy");
        }
        if (PlayerPrefs.HasKey("AttackLvl"))
        {
            Ammo.damage = PlayerPrefs.GetInt("AttackLvl");
        }
        if (PlayerPrefs.HasKey("BoostScore"))
        {
            Shop.BoostScore = PlayerPrefs.GetInt("BoostScore");
        }
      
        /* if (PlayerPrefs.HasKey("BoostUpgradeCost"))
         {
             Shop.BoostUpgradeCost = PlayerPrefs.GetInt("BoostUpgradeCost");
         }*/
        if (PlayerPrefs.HasKey("ShieldScore"))
        {
            Shield = PlayerPrefs.GetInt("ShieldScore");
        }
        PlayerPrefs.SetInt("Marker", 0);
        if (PlayerPrefs.HasKey("GhostMode"))
        {
            GhostMode = PlayerPrefs.GetInt("GhostMode");
        }
        if (PlayerPrefs.HasKey("L"))
        {
            OpenLevel = PlayerPrefs.GetInt("L");
        }
    }
}



