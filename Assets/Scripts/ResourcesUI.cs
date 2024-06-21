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

    private void Start()
    {
        ResourcesUI_RefreshResources();
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


    public void ResourcesUI_RefreshResources()
    {
        RefreshGoldText(Resources.resources.GetGoldCoinCount());
        RefreshWoodText(Resources.resources.GetWoodCount());
        RefreshStoneText(Resources.resources.GetStoneCount());
        RefreshSteelText(Resources.resources.GetSteelCount());
    }

    private void OnEnable()
    {
        Resources.RefreshUI += ResourcesUI_RefreshResources;
    }

    private void OnDisable()
    {
        Resources.RefreshUI -= ResourcesUI_RefreshResources;
    }

}
