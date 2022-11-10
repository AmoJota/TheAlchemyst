using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ball : MonoBehaviour
{
    float time = 2f;
    int damage;
    TextMeshPro text;
    Game game;
    Enemy enemy;
    SpriteRenderer rend;
    [SerializeField] Color blue, red;
    private void Awake()
    {
        game = FindObjectOfType<Game>();
        enemy = FindObjectOfType<Enemy>();
        text = GetComponentInChildren<TextMeshPro>();
        rend = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        Stats();
        ColorBall();
    }
    void Update()
    {
        TimeLife();
    }

    void Stats()
    {
        time = Random.Range(1, 2f);
        damage = Random.Range(-25, 20);

        text.text = damage.ToString();
    }
   
    void TimeLife()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
    void ColorBall()
    {      
        int randomColor = Random.Range(0, 2);

        if (randomColor == 0)
        {
            rend.color = blue;

        }
        if (randomColor == 1)
        {
            rend.color = red;
        }
    }

    private void OnMouseDown()
    {
       enemy.ModifyLife(damage);
       Destroy(transform.parent.gameObject);
    }
}
