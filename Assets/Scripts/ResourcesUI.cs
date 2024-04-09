using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesUI : MonoBehaviour
{
    #region TEXT
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI steelText;
    #endregion

    [SerializeField] private Resources resources;

    private void Start()
    {
        RefreshResources();
    }

    void RefreshGoldText(int goldCoin)
    {
        goldText.text = goldCoin.ToString();
    }

    void RefreshWoodText(int wood)
    {
        woodText.text = wood.ToString();
        
    }

    void RefreshStoneText(int stone)
    {
        stoneText.text = stone.ToString();
    }

    void RefreshSteelText(int steel)
    {
        steelText.text = steel.ToString();
    }


    public void RefreshResources()
    {
        RefreshGoldText(resources.GetGoldCoinCount());
        RefreshWoodText(resources.GetWoodCount());
        RefreshStoneText(resources.GetStoneCount());
        RefreshSteelText(resources.GetSteelCount());
    }

}
