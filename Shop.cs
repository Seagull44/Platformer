using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shop : MonoBehaviour
{
    public Button UpgradeHealth;
    public Button BuyEnergyVampire;
    public Button BuyPureEnergy;
    public Button UpgradeBoost;
    public Button UpgradeAttackBtn;
    public Button UpgShieldBtn;
    public static int upgradeHealth ;
    public int CostOfUpgradeHealth;
    public int CostOfDrops;
    public int EVCost;
    public int AttackUpgradeCost;
    public int BoostUpgradeCost;
    public int ShieldUpgradeCost;
    public Text CostText;
    public Text UpgradeShieldTXT;
    public Text UogradeAttackText;
    public Text EvText;
    public Text UpgradeBoostText;
    public static int BoostScore;
    public static bool EnergyVampireItem = false;
    public static int i;
    public static int godDropCount;
   


    void Start()
    
    {
        if (PlayerPrefs.HasKey("CostOfUpgradeHealth"))
        {
         CostOfUpgradeHealth  = PlayerPrefs.GetInt("CostOfUpgradeHealth");
        }
        if (CostOfUpgradeHealth >=4000)
        {
            CostOfUpgradeHealth = 4000;
        }
        
        if (AttackUpgradeCost >=4000)
        {
            AttackUpgradeCost = 4000;
        }
        else
        {
            AttackUpgradeCost = Ammo.damage * 100;
        }

        if (MainMenu.Shield >= 1 && MainMenu.Shield <=2)
        {
            UpgShieldBtn.interactable = true;
        }
        else
        {
            UpgShieldBtn.interactable = false;
        }

        if (i ==1)
        {
            BuyEnergyVampire.interactable = false;
        }
    }


    void Update()
    {
        if (upgradeHealth >= 20)
        {
            UpgradeHealth.interactable = false;
        }
        if (Ammo.damage >= 20)
        {
            UpgradeAttackBtn.interactable = false;
        }
        if (BoostScore >= 2 || BoostScore <= 0)
        {
            UpgradeBoost.interactable = false;
        }

        if (MainMenu.Shield == 1)
        {
            ShieldUpgradeCost = 5000;
        }
        else
        {
            ShieldUpgradeCost = 10000;
        }
        
        if (MainMenu.Shield >= 3 || MainMenu.Shield <= 0)
        {
            UpgShieldBtn.interactable = false;
        }
        else
        {
            UpgShieldBtn.interactable = true;
        }

        CostText.text = "Upgrade health" + " " + CostOfUpgradeHealth;
        UogradeAttackText.text = "Upgrade attack" + " " + AttackUpgradeCost;
       
        if (MainMenu.Shield <= 0)
        {
            UpgradeShieldTXT.text = "Need to find Sphere";
        }
        else
        {
            UpgradeShieldTXT.text = "Upgrade shield" + " " + ShieldUpgradeCost;
        }

        if (i == 1)
        {
            BuyEnergyVampire.interactable = false;
            EnergyVampireItem = true;
            EvText.text = "Already bought";
        }
        else
        {
            EvText.text = "Buy Energy Collector for 1000";
        }

        if (MainMenu.ItemForHuld == 1 && BoostScore <=1)
        {
            UpgradeBoost.interactable = true;
            UpgradeBoostText.text = "Upgrade boost for" + " " + BoostUpgradeCost;
        }
        if (MainMenu.ItemForHuld == 0)
        {
            UpgradeBoostText.text = "Need to find Booster";
        }

    }
   public void BuyMoreHealth()
    {   
        if (MainMenu.TotalScore >= CostOfUpgradeHealth)
        {
            upgradeHealth++;
            MainMenu.TotalScore -= CostOfUpgradeHealth;
            CostOfUpgradeHealth *= 2;
            PlayerPrefs.SetInt("CostOfUpgradeHealth", CostOfUpgradeHealth);
            Save();
        }
    }
    public void UpgradeAttack()
    {
        if (MainMenu.TotalScore >= AttackUpgradeCost)
        {
            Ammo.damage++;
            MainMenu.TotalScore -= AttackUpgradeCost;
            Save();
        }
    }

    public void BuyMoreDrops()
    {
      /*  if (MainMenu.pureEnergy >= CostOfDrops)
        {
            godDropCount++;
            MainMenu.pureEnergy -= CostOfDrops;
            
            Save();
        }*/
    }
    public void EV()
    {
        if (MainMenu.TotalScore >= EVCost)
        {
            MainMenu.TotalScore -= EVCost;
            i = 1;
            PlayerPrefs.SetInt("EV=1", i);
            if (i == 1)
            {
                BuyEnergyVampire.interactable = false;
            }
            Save();

        }
    }
    public void Boost()
    {
        if (MainMenu.TotalScore >= BoostUpgradeCost)
        {
            MainMenu.TotalScore -= BoostUpgradeCost;
            BoostScore++;
            PlayerPrefs.SetInt("BoostScore", BoostScore);
            /*PlayerPrefs.SetInt("BoostUpgradeCost", BoostUpgradeCost);*/
            Save();
        }
    }
    public void Shield()
    {
       if (MainMenu.TotalScore >= ShieldUpgradeCost)
       {
             MainMenu.TotalScore -= ShieldUpgradeCost;
             MainMenu.Shield++;
             PlayerPrefs.SetInt("ShieldScore", MainMenu.Shield);
       }
    }
    public void Save()
    {
        PlayerPrefs.SetInt("Score", MainMenu.TotalScore);
        PlayerPrefs.SetInt("UpgradeHP", upgradeHealth);
        PlayerPrefs.SetInt("DropsCount", godDropCount);
        PlayerPrefs.SetInt("PureEnergy", MainMenu.pureEnergy);
        PlayerPrefs.SetInt("AttackLvl", Ammo.damage);
    }

  
}
