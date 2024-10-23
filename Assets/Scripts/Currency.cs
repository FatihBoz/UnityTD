using System;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static Action<int> OnInGameCoinCollected;
    public static int coin;

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private int initialCoinAmount;


    private void Start()
    {
        coin = initialCoinAmount;
        coinText.text = coin.ToString();
    }

    public  void CoinToText(int value , bool increase)  //true means increase , false means decrease;
    {
        if (increase)
        {
            coin += value;
        }
        else
        {
            coin -= value;
        }

        
    }


    void CollectCoin(int value)
    {
        coin += value;

        coinText.text = coin.ToString();
    }

    private void Currency_OnCoinCollected(int coin)
    {
        CollectCoin(coin);
    }


    private void OnEnable()
    {
        OnInGameCoinCollected += Currency_OnCoinCollected;
    }


    private void OnDisable()
    {
        OnInGameCoinCollected -= Currency_OnCoinCollected;    
    }

}
