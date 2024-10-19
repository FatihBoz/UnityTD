using UnityEngine;
using UnityEngine.UI;

public class UpgradePanels : MonoBehaviour
{
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

    private bool GoldCoinIsEnoughToUpgrade(int cost) => Resources.Instance.GetGoldCoinCount() >= cost;

    private bool WoodIsEnoughToUpgrade(int cost) => Resources.Instance.GetWoodCount() >= cost;

    private bool StoneIsEnoughToUpgrade(int cost) => Resources.Instance.GetStoneCount() >= cost;


    private bool SteelIsEnoughToUpgrade(int cost) => Resources.Instance.GetSteelCount() >= cost;



    protected void SpendResource(int gold , int wood , int stone , int steel)
    {
        Resources.Instance.SpendGoldCoin(gold);
        Resources.Instance.SpendWood(wood);
        Resources.Instance.SpendStone(stone);
        Resources.Instance.SpendSteel(steel);

        Resources.RefreshUI?.Invoke();
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

        print("refreshed");
    }


}
