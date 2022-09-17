using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] int life = 100;
    Game game;
    private void Awake()
    {
        game = FindObjectOfType<Game>();
    }

    private void OnEnable()
    {
        game.ChangeText(life);
    }
    public void AddLife(int recover)
    {
        life += recover;
        Win();
    }

    public void Win()
    {
        game.ChangeText(life);

        if (life <= 0)
        {
            life = 0;
            game.ChangeText(life);
            game.Winner();
            Destroy(gameObject);
        }
    }
}
