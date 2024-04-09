using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TowerMenu : MonoBehaviour
{

    public static bool isActive;

    [SerializeField] List<int> buildingCosts;
    [SerializeField] GameObject towerMenu;
    [SerializeField] GameObject menuPanel;

    private SFXManager sfxManager;
    
    private int arrayOrder;

    private void Awake()
    {

        sfxManager = GameObject.FindWithTag("SFX").GetComponent<SFXManager>();
    }

    private void Start()
    {
        SetTowerMenu();
    }


    private void OnMouseDown()
    {
        if (!isActive && !BuildingManager.isBuilding && !PauseMenu.instance.isPaused)
        {   
            sfxManager.MenuClickSF();

            towerMenu.SetActive(true);

            isActive = true;

            menuPanel.SetActive(true); 
        }
    }


    void SetTowerMenu()
    {
        towerMenu.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }


    public void BuildArrowTower()
    {
        arrayOrder = 0;
        if (CanBuild(buildingCosts[arrayOrder]))
        {
            Build();
        }
        
    }

    public void BuildSlingshotTower()
    {
        arrayOrder = 1;
        if (CanBuild(buildingCosts[arrayOrder]))
        {
            Build();
        }

    }

    public void BuildCursedTower()
    {
        arrayOrder = 3;
        if (CanBuild(buildingCosts[arrayOrder]))
        {

            Build();

        }
    }

    public void BuildShockTower()
    {
        arrayOrder = 2;
        if (CanBuild(buildingCosts[arrayOrder]))
        {
            Build();
        }

    }


    void Build()
    {
        BuildingManager.main.Build_Upgrade(this.gameObject,LevelManager.main.towers[arrayOrder], transform.position, buildingCosts[arrayOrder]);

        CloseTowerMenu();

        gameObject.SetActive(false);
    }


    public void CloseTowerMenu()
    {
        towerMenu.SetActive(false);

        menuPanel.SetActive(false);

        isActive = false;
    }

    public GameObject GetPlaceForTower()
    {
        return this.gameObject;
    }


    bool CanBuild(int coinToBuild)
    {
        return Currency.coin >= coinToBuild;
    }
}
