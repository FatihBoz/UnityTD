using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellTowers : MonoBehaviour
{
    [SerializeField] GameObject collapseAnim;

    private GameObject placeForTower;
    private TowerUpgrade towerUpgrade;
    private Currency currency;


    private void Awake()
    {
        towerUpgrade = GetComponent<TowerUpgrade>();
        
        currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();
    }



    public void Sell()
    {
        TowerMenu.isActive = false;

        InstantiateCollapseAnim();

        MakePlaceForTowerVisible();

        RefreshCoinCount();

        Destroy(gameObject);
    }


    void RefreshCoinCount()
    {
        currency.CoinToText(GoldsReturn(),true);
    }


    int GoldsReturn()
    {
        return towerUpgrade.towerLevel * 30;
    }


    void InstantiateCollapseAnim()
    {
        GameObject anim = Instantiate(collapseAnim, new Vector3(transform.position.x,transform.position.y,-2), Quaternion.identity);

        if (!SettingsMenu.sfxOn)
        {
            anim.GetComponent<AudioSource>().mute = true;
        }
    }

    void MakePlaceForTowerVisible()
    {
        placeForTower.SetActive(true);
    }

    public void SetPlaceForTower(GameObject PlaceForTower)
    {
        placeForTower = PlaceForTower;
    }

    public GameObject GetPlaceForTower()
    {
        return placeForTower;
    }

}
