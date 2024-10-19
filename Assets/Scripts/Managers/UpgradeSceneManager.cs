using System.Collections.Generic;
using UnityEngine;

public class UpgradeSceneManager : MonoBehaviour, IDataPersistance
{
    private static readonly string arrowTowerName = "ArrowTower";

    private static readonly string slingshotTowerName = "SlingshotTower";

    private static readonly string shockTowerName = "ShockTower";

    private static readonly string cursedTowerName = "CursedTower";

    private static readonly string lightningSkillName = "Lightning";

    private static readonly string FireBombSkillName = "FireBomb";


    public static Dictionary<string, int> towerLevels = new()
    {
        {arrowTowerName, 1},
        {slingshotTowerName, 1},
        {shockTowerName, 1},
        {cursedTowerName, 1},
    };

    public static Dictionary<string, int> skillLevels = new()
    {
       {lightningSkillName, 1},
       {FireBombSkillName, 1}
    };

    public void LoadData(GameData gameData)
    {
        towerLevels[arrowTowerName] = gameData.arrowTowerLevel;
        towerLevels[slingshotTowerName] = gameData.slingshotTowerLevel;
        towerLevels[shockTowerName] = gameData.shockTowerLevel;
        towerLevels[cursedTowerName] = gameData.cursedTowerLevel;

        skillLevels[lightningSkillName] = gameData.lightningLevel;
        skillLevels[FireBombSkillName] = gameData.fireBombLevel;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.arrowTowerLevel = towerLevels[arrowTowerName];
        gameData.slingshotTowerLevel = towerLevels[slingshotTowerName];
        gameData.shockTowerLevel = towerLevels[shockTowerName];
        gameData.cursedTowerLevel = towerLevels[cursedTowerName];

        gameData.lightningLevel = skillLevels[lightningSkillName];
        gameData.fireBombLevel = skillLevels[FireBombSkillName];
    }
}