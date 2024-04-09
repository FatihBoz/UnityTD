using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CursedTowerUpgrade : UpgradePanels
{
    public static float additionalAttackDamagePerLevel = 0.15f;

    #region[SerializeField]
    [SerializeField] private TextMeshProUGUI magicGoldCoinText;
    [SerializeField] private TextMeshProUGUI magicStoneText;
    [SerializeField] private TextMeshProUGUI magicSteelText;

    [SerializeField] private TextMeshProUGUI towerLevelText;
    [SerializeField] private TextMeshProUGUI additionalAttackPowerText;
    #endregion

    private const string TOWER_NAME = "CursedTower";

    protected override void SetUpgradeCosts()
    {
        goldNeedsToUpgrade = level * extremelyHighAmount;
        woodNeedsToUpgrade = 0;
        stoneNeedsToUpgrade = level * averageAmount;
        steelNeedsToUpgrade = level * lowAmount;
    }

    protected override void RefreshInformation()
    {
        magicGoldCoinText.text = goldNeedsToUpgrade.ToString();
        magicStoneText.text = stoneNeedsToUpgrade.ToString();
        magicSteelText.text = steelNeedsToUpgrade.ToString();

        towerLevelText.text = "LV." + level.ToString();
        additionalAttackPowerText.text = $"(+{additionalAttackDamagePerLevel * (level - 1)})";
    }

    protected override string GetName()
    {
        return TOWER_NAME;
    }

}

