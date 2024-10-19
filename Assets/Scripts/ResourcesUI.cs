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


    void RefreshText(int amount, TextMeshProUGUI text)
    {
        text.text = amount.ToString();
    }


    public void ResourcesUI_RefreshResources()
    {
        RefreshText(Resources.Instance.GetGoldCoinCount(),goldText);
        RefreshText(Resources.Instance.GetWoodCount(),woodText);
        RefreshText(Resources.Instance.GetStoneCount(),stoneText);
        RefreshText(Resources.Instance.GetSteelCount(),steelText);
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
