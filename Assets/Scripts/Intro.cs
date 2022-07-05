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
        PlayerPrefs.SetInt("Intro", 1);
        intro = 1;
        music.NextSong();
        gameObject.SetActive(false);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Intro", 0);
    }
}
