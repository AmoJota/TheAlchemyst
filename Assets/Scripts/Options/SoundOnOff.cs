using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOnOff : MonoBehaviour
{
    [SerializeField] Toggle soundToggle;
    int state = 1;

    private void OnEnable()
    {
        int togglePrefs = PlayerPrefs.GetInt("Toggle", 0);

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
            state = 0;
        }
        else
        {
            Inventory.singleton.GetComponent<AudioSource>().mute = true;
            state = 1;
        }
    }
    private void OnDisable()
    {
        PlayerPrefs.SetInt("Toggle", state);
    }
}
