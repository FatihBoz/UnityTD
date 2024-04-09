using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{

    public int towerLevel;

    #region [SerializeField]
    [SerializeField] List<GameObject> towerLevels;
    [SerializeField] AudioClip upgradeMenuClickSFX;
    [SerializeField] private GameObject upgradeMenu;
    [SerializeField] private GameObject upgradeMenuClosePanel;
    [SerializeField] private GameObject buildingAnim;
    [SerializeField] private int buildingCost;
    #endregion

    #region PRIVATE
    private SFXManager audioSource;
    private int upgradeCost;    
    #endregion





    private void Awake()
    { 
        audioSource = GameObject.FindWithTag("SFX").GetComponent<SFXManager>();
    }

    private void Start()
    {
        upgradeMenu.transform.position = Camera.main.WorldToScreenPoint(transform.position);

        upgradeCost = 2 * towerLevel * buildingCost;    
    }


    private void OnMouseDown()
    {
        if(!TowerMenu.isActive && !BuildingManager.isBuilding && towerLevel < 3 && !PauseMenu.instance.isPaused) {

            audioSource.MenuClickSF();

            upgradeMenuClosePanel.SetActive(true);

            TowerMenu.isActive = true;
                
            upgradeMenu.SetActive(true);

        }
    }



    public void UpgradeTower()
    {
        if (CanUpgrade())
        {
            GameObject placeForTower = GetComponent<SellTowers>().GetPlaceForTower();

            BuildingManager.main.Build_Upgrade(placeForTower ,towerLevels[towerLevel], transform.position, upgradeCost);

            CloseMenu();

            Destroy(gameObject);
        }
        
    }




    void CloseMenu()
    {
        upgradeMenuClosePanel.SetActive(false);

        TowerMenu.isActive = false;

        upgradeMenu.SetActive(false);
    }


    bool CanUpgrade()
    {
        return Currency.coin >= upgradeCost;
    }

}
