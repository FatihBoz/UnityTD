using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Resources : MonoBehaviour , IDataPersistance
{

    #region RESOURCES
    private static int goldCoin;
    private static int wood;  
    private static int stone;
    private static int steel;
    #endregion

    [SerializeField] private ResourcesUI ui;

    public int GetGoldCoinCount()
    {
        return goldCoin; 
    }

    public int GetWoodCount()
    {
        return wood; 
    }
    public int GetStoneCount()
    {
        return stone;
    }
    public int GetSteelCount()
    {
        return steel;
    }


    public void GainGoldCoin(int coin)
    {
        goldCoin += coin;
    }

    public void SpendGoldCoin(int coin)
    {
        goldCoin -= coin;
    }

    public void GainWood(int WOOD)
    {
        wood += WOOD;
    }

    public void SpendWood(int WOOD)
    {
        wood -= WOOD;
    }

    public void GainStone(int STONE)
    {
        stone += STONE;
    }

    public void SpendStone(int STONE)
    {
        stone -= STONE;
    }

    public void GainSteel(int STEEL)
    {
        steel += STEEL;
    }

    public void SpendSteel(int STEEL)
    {
        steel -= STEEL;
    }

    public void LoadData(GameData gameData)
    {
        GainGoldCoin(gameData.gold);
        GainWood(gameData.wood);
        GainStone(gameData.stone);
        GainSteel(gameData.steel);

        
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.gold = goldCoin;
        gameData.wood = wood;
        gameData.stone = stone;
        gameData.steel = steel;
    }

    public void RefreshResources()
    {
        ui.RefreshResources();
    }
}
