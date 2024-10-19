using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Currency : MonoBehaviour
{
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

        coinText.text = coin.ToString();
    }

}
