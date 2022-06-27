using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerObjetive : MonoBehaviour
{
    float retroTimer = 4f;
    bool isWin = false;
    [SerializeField] GameObject winnerIs;
    Touch touch;
    private void Update()
    {
        if (isWin)
        {
            retroTimer -= Time.deltaTime;
        }

        Winner();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
        {
            isWin = true;
            Debug.Log("WIIIINEEEERRR!!");
        }
    }

    void Winner()
    {
        if (retroTimer <= 0f)
        {
            winnerIs.SetActive(true);
        }
    }
}
