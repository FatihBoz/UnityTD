using System.Collections;
using System.Collections.Generic;
using System.Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanels : MonoBehaviour
{
    private static Resources resources;

    [SerializeField] protected Button upgradeButton;

    #region RESOURCES
    private protected int extremelyHighAmount = 500;
    private protected int highAmount = 250;
    private protected int averageAmount = 175;
    private protected int lowAmount = 75;
    #endregion

    #region RESOURCES NEED TO UPGRADE
    protected int goldNeedsToUpgrade;
    protected int woodNeedsToUpgrade;
    protected int stoneNeedsToUpgrade;
    protected int steelNeedsToUpgrade;
    #endregion

    protected string tower_skill_Name; 
    protected bool canBeUpgraded = false;
    protected int level;

    private void Awake()
    {
        resources = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<Resources>();
    }

    private bool GoldCoinIsEnoughToUpgrade(int cost)
    {
        return resources.GetGoldCoinCount() >= cost;
    }

    private bool WoodIsEnoughToUpgrade(int cost)
    {
        return resources.GetWoodCount() >= cost;
    }

    private bool StoneIsEnoughToUpgrade(int cost)
    {
        return resources.GetStoneCount() >= cost;
    }

    private bool SteelIsEnoughToUpgrade(int cost)
    {
        return resources.GetSteelCount() >= cost;
    }


    protected void SpendResource(int gold , int wood , int stone , int steel)
    {
        resources.SpendGoldCoin(gold);
        resources.SpendWood(wood);
        resources.SpendStone(stone);
        resources.SpendSteel(steel);

        resources.RefreshResources();
    }

    protected bool ConditionsAreSatisfied()
    {
        return GoldCoinIsEnoughToUpgrade(goldNeedsToUpgrade) &&
                WoodIsEnoughToUpgrade(woodNeedsToUpgrade) &&
                StoneIsEnoughToUpgrade(stoneNeedsToUpgrade) &&
                SteelIsEnoughToUpgrade(steelNeedsToUpgrade);
    }


    protected virtual string GetName()
    {
        //every subclass should override this method
        return null;
    }

    protected virtual void UpgradePanel() //will be called when tower upgrade button is clicked.
    {
        //Get the level of tower from the dictionary
        level = UpgradeSceneManager.towerLevels[GetName()];
        //Set All costs
        SetUpgradeCosts();
        //Refresh necessary informations
        RefreshInformation();

        if (ConditionsAreSatisfied()) //if player has enough resources , enable the button.
        {
            canBeUpgraded = true;
            upgradeButton.interactable = true;
        }
        else
        {
            canBeUpgraded = false;
            upgradeButton.interactable = false;
        }
    }

    public virtual void Upgrade()
    {
        if (canBeUpgraded)
        {
            //Increment the level
            level++;
            //Write level to the dictionary
            UpgradeSceneManager.towerLevels[GetName()] = level;
            //spend resource 
            SpendResource(goldNeedsToUpgrade, woodNeedsToUpgrade, stoneNeedsToUpgrade, steelNeedsToUpgrade);
            //Refresh all the information and upgrade button
            UpgradePanel();
        }
    }

    protected virtual void SetUpgradeCosts()
    {
        //every subclass should override this method
        goldNeedsToUpgrade = 0;
        woodNeedsToUpgrade = 0;
        stoneNeedsToUpgrade = 0;
        steelNeedsToUpgrade = 0;
    }
    protected virtual void RefreshInformation()
    {
        //every subclass should override this method
        print("refreshed");
    }


}
