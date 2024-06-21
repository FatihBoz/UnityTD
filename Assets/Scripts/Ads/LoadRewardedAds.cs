using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class LoadRewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;

    public Rewards reward;

    private void Awake()
    {
#if UNITY_IOS
        adUnitId = iosAdUnitId;
#elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
#elif UNITY_EDITOR
        adUnitId = androidAdUnitId;

#endif
    }

    private void Start()
    {
        LoadAd();
    }

    public void LoadAd()
    {
        Advertisement.Load(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId) { }


    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message){}

    public void ShowAd()
    {
        Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsShowClick(string placementId){}

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        if (placementId.Equals(adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            switch (reward)
            {
                case Rewards.Extra_Heart:
                    GameObject.FindGameObjectWithTag("Heart").GetComponent<Heart>().IncreaseHeartCountByAd();
                    break;
                case Rewards.Double_Resource:
                    WinPanel winPanel = GameObject.FindGameObjectWithTag("WinPanel").GetComponent<WinPanel>();
                    winPanel.GainResources();
                    winPanel.OnWatchAdButtonClick();
                    break;
                case Rewards.Gold:
                    Resources.resources.GainGoldCoin(500);
                    Resources.RefreshUI?.Invoke();
                    break;
            }

        }
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message){}

    public void OnUnityAdsShowStart(string placementId){}

    public enum Rewards {
        Extra_Heart,
        Double_Resource,
        Gold
    }
}

