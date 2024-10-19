using System;
using UnityEngine;

public class Resources : MonoBehaviour , IDataPersistance
{

    public static Resources Instance;

    public static Action RefreshUI;


    //STATIC OLDUKLARI ÝÇÝN AÇ KAPA YAPTIÐINDA KAYNAKLAR ÝKÝYE KATLANIYOR.
    #region RESOURCES 
    private static int goldCoin;
    private static int wood;  
    private static int stone;
    private static int steel;
    #endregion

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        
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
        goldCoin = gameData.gold;
        wood = gameData.wood;
        stone = gameData.stone;
        steel = gameData.steel;
        //GainGoldCoin(gameData.gold);
        //GainWood(gameData.wood);
        //GainStone(gameData.stone);
        //GainSteel(gameData.steel);
    }

    public void SaveData(ref GameData gameData)
    {
        print(goldCoin);
        gameData.gold = goldCoin;
        gameData.wood = wood;
        gameData.stone = stone;
        gameData.steel = steel;
    }


}

