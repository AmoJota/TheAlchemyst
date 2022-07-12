using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    int intro = 0;
    [SerializeField] Music music;
    void Start()
    {
        intro = PlayerPrefs.GetInt("Intro", 0);

        if (intro == 0)
        {
            Invoke("LoadingComplete", 5f);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    void LoadingComplete()
    { 
        intro = 1;
        music.NextSong();
        PlayerPrefs.SetInt("Intro", 1);
        gameObject.SetActive(false);
    }
}
