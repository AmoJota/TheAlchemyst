using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    EnemyLife enemyLife;
    Image image;
    Game game;
    float lifeM = 100f;
    Battle battle;
    private void Awake()
    {
        game = FindObjectOfType<Game>();
        enemyLife = FindObjectOfType<EnemyLife>();
        battle = FindObjectOfType<Battle>();
       
    }
    private void OnEnable()
    {
        game.ChangeText(lifeM);       
    }
    public void ModifyLife(float damage)
    {
        
        lifeM += damage;
        MaxLife();
        enemyLife.SetLife(lifeM);
        game.ChangeText(lifeM);
        Win();
    }
    
    public void Win()
    {
        if (lifeM <= 0)
        {
            battle.BattleOff();
            lifeM = 0;
            game.ChangeText(lifeM);
            game.Winner();
            Destroy(gameObject);
        }

       
    }
    void MaxLife()
    {
        if (lifeM > 100)
        {
            lifeM = 100;
        }
    }
}
