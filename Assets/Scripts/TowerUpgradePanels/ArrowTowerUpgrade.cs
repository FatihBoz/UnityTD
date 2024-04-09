using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArrowTowerUpgrade : UpgradePanels
{
    public static float additionalAttackDamagePerLevel = 0.3f;

    #region[SerializeField]
    [SerializeField] private TextMeshProUGUI arrowGoldCoinText;
    [SerializeField] private TextMeshProUGUI arrowWoodText;
    [SerializeField] private TextMeshProUGUI arrowStoneText;
    [SerializeField] private TextMeshProUGUI arrowSteelText;

    [SerializeField] private TextMeshProUGUI towerLevelText;
    [SerializeField] private TextMeshProUGUI additionalAttackPowerText;
    #endregion

    private const string TOWER_NAME = "ArrowTower";

    protected override void SetUpgradeCosts()
    {
        goldNeedsToUpgrade = level * extremelyHighAmount;
        woodNeedsToUpgrade = level * highAmount;
        stoneNeedsToUpgrade = level * averageAmount;
        steelNeedsToUpgrade = level * lowAmount;
    }

    protected override void RefreshInformation()
    {
        arrowGoldCoinText.text = goldNeedsToUpgrade.ToString();
        arrowWoodText.text = woodNeedsToUpgrade.ToString();
        arrowStoneText.text = stoneNeedsToUpgrade.ToString();
        arrowSteelText.text = steelNeedsToUpgrade.ToString();

        towerLevelText.text = "LV."+level.ToString();
        additionalAttackPowerText.text = $"(+{additionalAttackDamagePerLevel*(level-1)})";
    }

    protected override string GetName()
    {
        return TOWER_NAME;
    }
}
