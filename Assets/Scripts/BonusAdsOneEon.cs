using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api; 
using System.ComponentModel;
using System; 

public class BonusAdsOneEon : MonoBehaviour
{
    public static BonusAdsOneEon instance; 


    private RewardedAd rewardedAd;
    private string RewardAD2 = "ca-app-pub-3940256099942544/5224354917";
    private string realReward = "ca-app-pub-5146837764969591/6659141061";

    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        rewardedAd = new RewardedAd(realReward);

        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        RequestRewardedAd();
    }

    public void RequestRewardedAd() ///TO LOAD THE AD
    {
        AdRequest request = new AdRequest.Builder().Build();

        rewardedAd.LoadAd(request);
    }

    public void ShowRewardedAd() ///TO SHOW THE AD, IT MUST HAVE BEEN PREVIOUSLY LOADED FIRST
    {
        if (rewardedAd.IsLoaded())
        {
            rewardedAd.Show();
        }
        else
        {
            {
                Debug.Log("Ad not Loaded");
            }
        }
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        
        SingletonTime.singleton.rest = 0;

    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        
        RequestRewardedAd();

    }
}

