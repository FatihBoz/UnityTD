using UnityEngine;


[System.Serializable]
public class GameData
{
    public int lastUnlockedLevel;

    [Header("Resources")]
    public int gold;
    public int wood;
    public int stone;
    public int steel;

    [Header("Tower Levels")]
    public int arrowTowerLevel;
    public int slingshotTowerLevel;
    public int shockTowerLevel;
    public int cursedTowerLevel;

    [Header("Skill Levels")]
    public int fireBombLevel;
    public int lightningLevel;

    

    public GameData()
    {
        gold = 0;
        wood = 0;
        stone = 0;
        steel = 0;

        arrowTowerLevel = 1;
        slingshotTowerLevel = 1;
        shockTowerLevel = 1;
        cursedTowerLevel = 1;

        fireBombLevel = 1;
        lightningLevel = 1;

        lastUnlockedLevel = 1;
    }

}