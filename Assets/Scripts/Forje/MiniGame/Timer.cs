using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] float retroTimer;

    [SerializeField] TextMeshProUGUI timeText;

    [SerializeField] GameObject loose;

    [SerializeField] WinnerObjetive winnerObjetive;
    void Update()
    {
        TimerText();
    }

    void TimerText()
    {
        retroTimer -= Time.deltaTime;
        timeText.text = retroTimer.ToString("N0");

        if (retroTimer <= 0 && !winnerObjetive.isWin)
        {
            loose.SetActive(true);
            retroTimer = 0;
        }
    }
}
