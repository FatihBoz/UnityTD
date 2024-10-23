using UnityEngine;

public class SellTowers : MonoBehaviour
{
    [SerializeField] GameObject collapseAnim;

    private GameObject placeForTower;
    private TowerUpgrade towerUpgrade;


    private void Awake()
    {
        towerUpgrade = GetComponent<TowerUpgrade>();
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
        Currency.OnInGameCoinCollected?.Invoke(GoldsReturn());
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
