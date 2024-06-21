using System.Collections.Generic;
using UnityEngine;

public class UpgradeSceneManager : MonoBehaviour, IDataPersistance
{
    public static Dictionary<string, int> towerLevels = new()
    {
        {"ArrowTower", 1},
        {"SlingshotTower", 1},
        {"ShockTower", 1},
        {"CursedTower", 1},
    };

    public static Dictionary<string, int> skillLevels = new()
    {
       {"Lightning", 1},
       {"FireBomb", 1}
    };

    public void LoadData(GameData gameData)
    {
        towerLevels["ArrowTower"] = gameData.arrowTowerLevel;
        towerLevels["SlingshotTower"] = gameData.slingshotTowerLevel;
        towerLevels["ShockTower"] = gameData.shockTowerLevel;
        towerLevels["CursedTower"] = gameData.cursedTowerLevel;

        skillLevels["Lightning"] = gameData.lightningLevel;
        skillLevels["FireBomb"] = gameData.fireBombLevel;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.arrowTowerLevel = towerLevels["ArrowTower"];
        gameData.slingshotTowerLevel = towerLevels["SlingshotTower"];
        gameData.shockTowerLevel = towerLevels["ShockTower"];
        gameData.cursedTowerLevel = towerLevels["CursedTower"];

        gameData.lightningLevel = skillLevels["Lightning"];
        gameData.fireBombLevel = skillLevels["FireBomb"];
    }
}