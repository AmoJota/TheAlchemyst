using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    [SerializeField] Toggle soundToggle;
    private void OnEnable()
    {
        int togglePrefs = PlayerPrefs.GetInt("Sound");

        if (togglePrefs == 0)
        {
            soundToggle.isOn = true;
        }
        else
        {
            soundToggle.isOn = false;
        }
    }
    public void GeneralSoundOnOff()
    {
        if (soundToggle.isOn)
        {
            Inventory.singleton.GetComponent<AudioSource>().mute = false;
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            Inventory.singleton.GetComponent<AudioSource>().mute = true;
            PlayerPrefs.SetInt("Sound", 1);
        }
    }
}
