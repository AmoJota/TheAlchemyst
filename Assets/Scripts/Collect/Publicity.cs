using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

// ESTA ES LA ID DEL ANUNCIO REAL PARA EL JUEGO  ////////////    ca-app-pub-5146837764969591/6659141061


// ESTA ES LA ID DE PRUEBA PARA LOS ANUNCIOS BONIFICADOS  ////////////	ca-app-pub-3940256099942544/5224354917
public class Publicity : MonoBehaviour
{

    RewardedAd rewardedAd;

    string rewardedUnityID = "ca-app-pub-3940256099942544/5224354917";

    public static Publicity instance;

    //string realRewardedID = "ca-app-pub-5146837764969591/6659141061";
    private void Awake()
    {
        if (instance = null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    private void OnEnable()
    {
        rewardedAd = new RewardedAd(rewardedUnityID);       
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        AdRequest adReq = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adReq);
    }
    private void Start()
    {
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
    }


    public void HandleRewardedAdLoaded(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
                             + args);
    }

    public void HandleRewardedAdOpening(object sender, System.EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
                             + args);
    }

    public void HandleRewardedAdClosed(object sender, System.EventArgs args)
    {
        Debug.Log("Se cierra el anuncio");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        SpawnCollect spawnCollect = FindObjectOfType<SpawnCollect>();
        SingletonTime.singleton.rest = 0;

        LoadNextReward();
    }

    public void ShowReward()
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }  
    }

    void LoadNextReward()
    {
        rewardedAd = new RewardedAd(rewardedUnityID);
        AdRequest adReq = new AdRequest.Builder().Build();
        rewardedAd.LoadAd(adReq);
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;
    }
}

