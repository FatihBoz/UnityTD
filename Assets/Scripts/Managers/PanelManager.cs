using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

    public float timeNeedsToBeVisible;

    public void OpenPanelImmediately()
    {
        this.gameObject.SetActive(true);
    }

    public void OpenPanel()
    {
        Invoke(nameof(MakeVisible), timeNeedsToBeVisible);
    }

    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }


    private void MakeVisible()
    {
        this.gameObject.SetActive(true);
    }
}
