using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InterstitialView : MonoBehaviour
{
//    private InterstitialAd interstitial;


//    private void OnEnable()
//    {
//        EventManager.AdMobLoaded += HandleOnAdLoaded;
//    }

//    private void OnDisable()
//    {
//        EventManager.AdMobLoaded -= HandleOnAdLoaded;
//    }

//    private void RequestInterstitial()
//    {
//#if UNITY_ANDROID
//        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
//#elif UNITY_IPHONE
//        string adUnitId = "ca-app-pub-3940256099942544/4411468910";
//#else
//        string adUnitId = "unexpected_platform";
//#endif

//        // Initialize an InterstitialAd.
//        this.interstitial = new InterstitialAd(adUnitId);
//        // Create an empty ad request.
//        AdRequest request = new AdRequest.Builder().Build();
//        // Load the interstitial with the request.
//        this.interstitial.LoadAd(request);
//    }

//    public void HandleOnAdLoaded()
//    {
//        MobileAds.Initialize(initstatus => { });

//        RequestInterstitial();

//        if (this.interstitial.IsLoaded())
//        {
//            this.interstitial.Show();
//        }

//        print("HandleAdLoaded event received");
//    }
}
