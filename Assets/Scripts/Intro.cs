using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    int intro = 0;
    [SerializeField] GameObject musicOn;
    AudioSource audioSource;
    void Start()
    {
        intro = PlayerPrefs.GetInt("Intro", 0);

        if (intro == 0)
        {
            Invoke("LoadingComplete", 5f);         
        }
        else
        {
            musicOn.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    void LoadingComplete()
    {
        audioSource = Inventory.singleton.GetComponent<AudioSource>();
        audioSource.mute = false;
        musicOn.SetActive(true);
        PlayerPrefs.SetInt("Intro", 1);
        gameObject.SetActive(false);
    }
}
