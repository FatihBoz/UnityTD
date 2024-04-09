using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeSceneManager : MonoBehaviour , IDataPersistance
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


    [Header("Tower Level Texts")]
    [SerializeField] private TextMeshProUGUI arrowTowerText;    
    [SerializeField] private TextMeshProUGUI slingshotTowerText;
    [SerializeField] private TextMeshProUGUI shockTowerText;
    [SerializeField] private TextMeshProUGUI cursedTowerText;

    [Header("Skill Level Texts")]
    [SerializeField] private TextMeshProUGUI fireBomb;
    [SerializeField] private TextMeshProUGUI lightning;


    public void RefreshTowerLevelInfo()
    {
        arrowTowerText.text = "LV. "+towerLevels["ArrowTower"].ToString();
        slingshotTowerText.text = "LV. "+towerLevels["SlingshotTower"].ToString();
        shockTowerText.text = "LV. "+towerLevels["ShockTower"].ToString();
        cursedTowerText.text = "LV. "+towerLevels["CursedTower"].ToString();
    }

    
    public void RefreshSkillLevelInfo()
    {
        fireBomb.text = "LV. " + skillLevels["FireBomb"].ToString();
        lightning.text = "LV. " + skillLevels["Lightning"].ToString();
    }

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
