using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotTower : Tower
{
    protected override void SetAdditionalAttackPower()
    {
        additionalAttackPower = UpgradeSceneManager.towerLevels["SlingshotTower"] * CursedTowerUpgrade.additionalAttackDamagePerLevel;
        print("Additional AD:" + additionalAttackPower);
    }

}
