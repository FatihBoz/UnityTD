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
    [SerializeField] Image skullIMG;
    [SerializeField] GameObject touchText;

    private int textOrder = 0;

    public void OnPanelClick()
    {

        if (textOrder < texts.Count)
        {
            texts[textOrder].DOFade(1, 1f);
            textOrder++;
        }
        else if(textOrder == texts.Count)
        {
            skullIMG.DOFade(1, 1f);
            touchText.SetActive(false);
        }

    }
}
