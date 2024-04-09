using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillUpgrade : UpgradePanels
{
    public static float additionalAttackDamagePerLevel = 0.9f;

    #region [SerializeField]
    [SerializeField] private TextMeshProUGUI goldCoinText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI additionalAttackPowerText;
    #endregion


    public void SetSkillName(string skillName)
    {
        this.tower_skill_Name = skillName;
    }

    protected override void UpgradePanel()
    {
        level = UpgradeSceneManager.skillLevels[tower_skill_Name];

        SetUpgradeCosts();

        RefreshInformation();

        if (ConditionsAreSatisfied())
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
    public override void Upgrade()
    {
        Debug.Log(canBeUpgraded);
        if (canBeUpgraded)
        {
            level++;
            level = UpgradeSceneManager.skillLevels[tower_skill_Name] = level;

            SpendResource(goldNeedsToUpgrade, 0, 0, 0);

            UpgradePanel();
        }
        
    }

    protected override void SetUpgradeCosts()
    {
        goldNeedsToUpgrade = level * highAmount;
        woodNeedsToUpgrade = 0;
        stoneNeedsToUpgrade = 0;
        steelNeedsToUpgrade = 0;
    }
    protected override void RefreshInformation()
    {
        goldCoinText.text = goldNeedsToUpgrade.ToString();

        levelText.text = "LV." + level.ToString();
        additionalAttackPowerText.text = $"(+{additionalAttackDamagePerLevel * (level - 1)})";
    }




}
