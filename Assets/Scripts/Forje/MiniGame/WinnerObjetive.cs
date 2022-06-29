using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerObjetive : MonoBehaviour
{
    float retroTimer = 3f;
    bool isWin = false;
    [SerializeField] GameObject winnerIs;
    Touch touch;
    private void Update()
    {
        if (isWin)
        {
            retroTimer -= Time.deltaTime;
            Winner();

        }
    }
    public void Winner()
    {
        isWin = true;
        if (retroTimer <= 0f)
        {
            winnerIs.SetActive(true);
        }
    }
}
