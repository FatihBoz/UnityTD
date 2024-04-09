using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlingshotTowerUpgrade : UpgradePanels
{
    public static float additionalAttackDamagePerLevel = 0.25f;

    #region[SerializeField]
    [SerializeField] private TextMeshProUGUI slingshotGoldCoinText;
    [SerializeField] private TextMeshProUGUI slingshotWoodText;
    [SerializeField] private TextMeshProUGUI slingshotStoneText;

    [SerializeField] private TextMeshProUGUI towerLevelText;
    [SerializeField] private TextMeshProUGUI additionalAttackPowerText;
    #endregion

    private const string TOWER_NAME = "SlingshotTower";

    protected override void SetUpgradeCosts() //High amount = 250 , Average = 175 , low = 75 , extremelyHigh = 500
    {
        goldNeedsToUpgrade = level * extremelyHighAmount;
        woodNeedsToUpgrade = level * highAmount;
        stoneNeedsToUpgrade = level * highAmount;
        steelNeedsToUpgrade = 0;
    }

    protected override void RefreshInformation()
    {
        
        slingshotGoldCoinText.text = goldNeedsToUpgrade.ToString();
        slingshotWoodText.text = woodNeedsToUpgrade.ToString();
        slingshotStoneText.text = stoneNeedsToUpgrade.ToString();

        towerLevelText.text = "LV." + level.ToString();
        additionalAttackPowerText.text = $"(+{additionalAttackDamagePerLevel * (level - 1)})";
    }

    protected override string GetName()
    {
        return TOWER_NAME;
    }

}
