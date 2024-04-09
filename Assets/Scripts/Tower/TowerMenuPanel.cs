using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerMenuPanel : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] GameObject towerMenu;

    public void OnPointerDown(PointerEventData eventData)
    {
        TowerMenu.isActive = false;

        towerMenu.SetActive(false);  

        gameObject.SetActive(false);

    }


}
