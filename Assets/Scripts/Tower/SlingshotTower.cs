
public class SlingshotTower : Tower
{
    protected override void SetAdditionalAttackPower()
    {
        additionalAttackPower = UpgradeSceneManager.towerLevels["SlingshotTower"] * CursedTowerUpgrade.additionalAttackDamagePerLevel;
    }

}
