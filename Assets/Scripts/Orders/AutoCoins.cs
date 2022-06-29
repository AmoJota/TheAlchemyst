using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AutoCoins : MonoBehaviour
{
    public static int totalGold;
    public int goldCoin, silverCoin, cupperCoin; 
    [SerializeField] TextMeshProUGUI textCupper, textSilver, textGold;

    PlayFabLogin login;
    private void Start()
    {
        AutoCoinSystem();       

    }

    void AutoCoinSystem()
    {
        totalGold = PlayerPrefs.GetInt("Reward");

        goldCoin = Math.DivRem(totalGold, 10000, out int restGold);
        silverCoin = Math.DivRem(restGold, 100, out int restsilver);
        cupperCoin = restsilver;

        textCupper.text = cupperCoin.ToString();
        textSilver.text = silverCoin.ToString();
        textGold.text = goldCoin.ToString();  

    }

    public void GoldReward()
    {
        int rewardGold = UnityEngine.Random.Range(6,46);
        totalGold += rewardGold;

        login.SendLeaderboard(totalGold);


        login = FindObjectOfType<PlayFabLogin>();

        PlayerPrefs.SetInt("Reward", totalGold);

        AutoCoinSystem();
    }
}
