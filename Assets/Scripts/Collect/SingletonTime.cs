using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTime : MonoBehaviour
{
    public static SingletonTime singleton;

    public float timeNextLoot = 20f;

    public float timeNextMision = 360f;

    int seg, tempMin, tempSeg;

    public float rest;

    private void Awake()
    {

        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);

        rest = (timeNextLoot * 60) + seg;

    }
    

    private void Start()
    {
        rest = PlayerPrefs.GetFloat("Time");
        timeNextMision = PlayerPrefs.GetFloat("Order");

        int togglePrefs = PlayerPrefs.GetInt("Toggle");
        if (togglePrefs == 1)
        {
            Inventory.singleton.GetComponent<AudioSource>().mute = false;
        }
        else
        {
            Inventory.singleton.GetComponent<AudioSource>().mute = true;

        }
    }
    public void RestTime(int time)
    {
        rest -= time;
        ReturnTime();
    }

    public string ReturnTime()
    {
        return string.Format("{00:00}:{01:00}", tempMin, tempSeg);
    }
    void Update()
    {
        rest -= Time.deltaTime;
        timeNextMision -= Time.deltaTime;

        tempMin = Mathf.FloorToInt(rest/ 60);
        tempSeg = Mathf.FloorToInt(rest % 60);
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Time", rest);
        PlayerPrefs.SetFloat("Order", timeNextMision);

    }
}
