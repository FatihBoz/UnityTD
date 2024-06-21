using System;
using UnityEngine;

public class Resources : MonoBehaviour , IDataPersistance
{

    public static Resources resources;
    public static Action RefreshUI;

    #region RESOURCES
    private int goldCoin;
    private int wood;  
    private int stone;
    private int steel;
    #endregion

    private void Awake()
    {
        if (resources != null)
        {
            Destroy(this.gameObject);
            return;
        }

        resources = this;
    }

    public int GetGoldCoinCount()
    {
        Debug.Log("gold coin:" + goldCoin);
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
        Debug.Log("load:" + goldCoin + "+" + wood);
    }

    public void SaveData(ref GameData gameData)
    {
        Debug.Log("saved:"+goldCoin + "+" + wood);
        gameData.gold = goldCoin;
        gameData.wood = wood;
        gameData.stone = stone;
        gameData.steel = steel;
    }
}
