using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerObjetive : MonoBehaviour
{
    float retroTimer = 3f;
    public bool isWin = false;
    [SerializeField] GameObject winnerIs;
    private void Update()
    {
        if (isWin)
        {
            retroTimer -= Time.deltaTime;
            Winner();
        }
    }
    void Winner()
    {
        if (retroTimer <= 0f)
        {
            int temp = PlayerPrefs.GetInt("Scame");
            int total = temp + AutoCoins.totalGold;
            PlayerPrefs.SetInt("Reward", total);
            winnerIs.SetActive(true);
        }
    }
}
