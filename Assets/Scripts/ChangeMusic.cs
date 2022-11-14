using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeMusic : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip newclip;
    private void Awake()
    {
        audioSource = Inventory.singleton.GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        NewSong();
    }
    void NewSong()
    {     
        audioSource.Stop();
        audioSource.loop = true;
        audioSource.clip = newclip;
        audioSource.Play();

        PlayerPrefs.SetInt("Intro", 1);
    }
}
