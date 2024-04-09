using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static bool isBuilding;
    public static BuildingManager main;


    [SerializeField] private GameObject buildingAnim;

    #region PRIVATE
    private float buildingTime = 2.7f;
    private GameObject placeForTower;
    private GameObject gameObjToInstantiate;
    private Vector3 point;
    private Currency currency;
    private SFXManager sfxManager;
    #endregion

    private void Awake()
    {
        main = this;

        sfxManager = GameObject.FindWithTag("SFX").GetComponent<SFXManager>();

        currency = GameObject.FindGameObjectWithTag("Currency").GetComponent<Currency>();

    }

    public void Build_Upgrade(GameObject placeForTower ,GameObject gameObjToInstantiate, Vector3 point, int cost)
    {
        currency.CoinToText(cost, false);  //spend gold coin to upgrade

        this.gameObjToInstantiate = gameObjToInstantiate;   //which tower will be instantiated

        this.point = point; //where it will be placed

        this.placeForTower = placeForTower;   //Which tower place it will be builded

        StartCoroutine(BuildOrUpgrade());
    }

    IEnumerator BuildOrUpgrade()
    {
        sfxManager.StartBuildingSF();

        isBuilding = true;

        BuildingAnimation();

        yield return new WaitForSeconds(buildingTime);

        Instantiate();

    }

    void BuildingAnimation()
    {
        Instantiate(buildingAnim, new Vector3(point.x, point.y + 0.1f, point.z - 1 ), Quaternion.identity);
    }


    public void Instantiate()
    {
        sfxManager.TowerConstructedSF();

        GameObject sellTower = Instantiate(gameObjToInstantiate, point, Quaternion.identity);

        sellTower.GetComponent<SellTowers>().SetPlaceForTower(placeForTower);

        isBuilding = false;
    }

}
