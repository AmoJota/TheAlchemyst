using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] Transform[] transforms;
    [SerializeField] Transform lastTransform;
    [SerializeField] float retrotimer = 2f;
    [SerializeField] GameObject youWin;
    [SerializeField] TextMeshProUGUI lifeText;
    bool isWin = false;

    void Update()
    {
        if (!isWin)
        {
            retrotimer -= Time.deltaTime;

            if (retrotimer < 0)
            {
                NextBall();
            }
        }    
    }
    void NextBall()
    {
        int random = Random.Range(1,3);
        retrotimer = random;

        for (int i = 0; i < transforms.Length; i++)
        {
            if (lastTransform != transforms[i])
            {
                GameObject temp = Instantiate(ball, transforms[Random.Range(0, transforms.Length)].position, Quaternion.identity);
                lastTransform = temp.transform;
                break;
            }
        }       
    }

    public void Winner()
    {
        isWin = true;
        youWin.SetActive(true);
    }

    public void ChangeText(float lifeMonster)
    {
        lifeText.text = "Life: " +  lifeMonster.ToString();
    }
}
