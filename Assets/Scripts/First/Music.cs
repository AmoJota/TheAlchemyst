using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip nextClip, newclip;

    private void Awake()
    {
        audioSource = Inventory.singleton.GetComponent<AudioSource>();

        int intro = PlayerPrefs.GetInt("Intro");

        if (intro == 1)
        {
            NextSong();
        }
        
        audioSource.loop = false;
    }
    private void Start()
    {
        audioSource.mute = false;
    }
    void NextSong()
    {              
        audioSource.Stop();
        audioSource.clip = nextClip;
        audioSource.Play();
    }
    public void NewSong()
    {
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = newclip;
        audioSource.Play();
    }
}
