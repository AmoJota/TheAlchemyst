using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    [SerializeField] Toggle soundToggle;
    private void OnEnable()
    {
        int togglePrefs = PlayerPrefs.GetInt("Intro");

        if (togglePrefs == 0)
        {         
            soundToggle.isOn = false;
        }
        else
        {
            soundToggle.isOn = true;
        }
    }
    public void GeneralSoundOnOff()
    {
        if (soundToggle.isOn)
        {
            Inventory.singleton.GetComponent<AudioSource>().mute = false;
            PlayerPrefs.SetInt("Intro", 0);
        }
        else
        {
            Inventory.singleton.GetComponent<AudioSource>().mute = true;
            PlayerPrefs.SetInt("Intro", 1);
        }
    }
}
