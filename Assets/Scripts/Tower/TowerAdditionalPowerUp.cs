using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAdditionalPowerUp : MonoBehaviour
{
    public float SetAdditionalPowerUps(string tag)
    {
        float additionalAttackDamage = 0;
        int level = UpgradeSceneManager.towerLevels[tag];

        switch (tag)
        {
            case "ArrowTower":
                additionalAttackDamage += level * ArrowTowerUpgrade.additionalAttackDamagePerLevel;
                break;
            case "SlingshotTower":
                additionalAttackDamage += level * SlingshotTowerUpgrade.additionalAttackDamagePerLevel;
                break;
            case "ShockTower":
                additionalAttackDamage += level * ShockTowerUpgrade.additionalAttackDamagePerLevel;
                break;
            case "CursedTower":
                additionalAttackDamage += level * CursedTowerUpgrade.additionalAttackDamagePerLevel;
                break;
        }

        return additionalAttackDamage;
    }
}
