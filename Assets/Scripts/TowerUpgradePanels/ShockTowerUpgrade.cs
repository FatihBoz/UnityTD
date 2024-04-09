using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShockTowerUpgrade : UpgradePanels
{
    public static float additionalAttackDamagePerLevel = 0.2f;

    #region [SerializeField]
    [SerializeField] private TextMeshProUGUI shockGoldCoinText;
    [SerializeField] private TextMeshProUGUI shockSteelText;

    [SerializeField] private TextMeshProUGUI towerLevelText;
    [SerializeField] private TextMeshProUGUI additionalAttackPowerText;
    #endregion

    private const string TOWER_NAME = "ShockTower";

    protected override void SetUpgradeCosts()
    {
        goldNeedsToUpgrade = level * extremelyHighAmount;
        woodNeedsToUpgrade = 0;
        stoneNeedsToUpgrade = 0;
        steelNeedsToUpgrade = level * extremelyHighAmount;
    }

    protected override void RefreshInformation()
    {
        shockGoldCoinText.text = goldNeedsToUpgrade.ToString();
        shockSteelText.text = steelNeedsToUpgrade.ToString();

        towerLevelText.text = "LV." + level.ToString();
        additionalAttackPowerText.text = $"(+{additionalAttackDamagePerLevel * (level - 1)})";
    }

    protected override string GetName()
    {
        return TOWER_NAME;
    }
}

