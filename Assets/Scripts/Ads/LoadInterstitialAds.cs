using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class LoadInterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{

    public string androidAdUnitId;
    public string iosAdUnitId;

    string adUnitId;


    private void Awake()
    {
#if UNITY_IOS
        adUnitId = iosUnitId;
#elif UNITY_ANDROID
        adUnitId = androidAdUnitId;
#endif
    }

    private void Start()
    {
        LoadAd();
    }

    public void LoadAd()
    {
        print("Ad is loading...");
        Advertisement.Load(adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        print("interstitials are loaded.");
        
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        print("loading intrestitital is failed.");
    }

    public void ShowAd()
    {
        Advertisement.Show(adUnitId, this);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        print("Interstitial clicked.");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {

        print("interstitials are showed.");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        print("showing intrestitital is failed.");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        print("starting to show interstitials.");
    }
}
