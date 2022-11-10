using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Battle : MonoBehaviour
{
    [SerializeField] GameObject damageToPlayer, youLoose;
    float timeAttack = 5f;
    [SerializeField] Image playerLife;
    float playersLife = 100f;

    [SerializeField ]bool battleControl = false;
    private void Update()
    {
        if (battleControl)
        {           
            timeAttack -= Time.deltaTime;
            playerLife.fillAmount = playersLife / 100;
            LooseGame();

            if (timeAttack <= 0)
            {
                timeAttack = 5;
                damageToPlayer.SetActive(true);
                playersLife -= 10;                            
            }
        }    
    }

    public void BattleON()
    {
        battleControl = true;
    }
    public void BattleOff()
    {
        battleControl = false;
    }

    void LooseGame()
    {
        if (playersLife <= 0)
        {
            playersLife = 0;
            youLoose.SetActive(true);
            Time.timeScale = 0;
            BattleOff();
        }
    
    }
}
