using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class MainMenu : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private RectTransform startButton;
    [SerializeField] private RectTransform upgradeButton;
    [SerializeField] private RectTransform howToPlayButton;

    [Header("Variables")]
    public float moveDuration;

    private void Start()
    {
        startButton.DOScale(new Vector3(2, 2, 2),moveDuration);
        upgradeButton.DOScale(new Vector3(2.9f, 2, 2),moveDuration+1f);
        howToPlayButton.DOScale(new Vector3(3.5f, 2, 2),moveDuration+2f);
    }
}
