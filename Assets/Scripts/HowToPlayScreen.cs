using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using System;

public class HowToPlayScreen : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> texts;
    [SerializeField] List<Image> images;
    [SerializeField] GameObject touchText;

    private int textOrder = 0;
    private readonly float fadeTime = 1f;

    public void OnPanelClick()
    {

        if (textOrder < texts.Count)
        {
            texts[textOrder].DOFade(1, fadeTime);
            textOrder++;
        }
        else if(textOrder == texts.Count)
        {
            images[0].DOFade(1, fadeTime);
            textOrder++;
        }
        else if (textOrder == texts.Count + 1)
        {
            images[1].DOFade(1, fadeTime);
            touchText.SetActive(false);
        }


    }
}
