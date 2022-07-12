using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    public static Inventory singleton;

    public List<ItemScriptable> inventary = new List<ItemScriptable>();

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
        
    }
    public  void AddItem(ItemScriptable itemScriptable)
    {
        if (!PlayerPrefs.HasKey(itemScriptable.name))
        {
            itemScriptable.amount++;

            PlayerPrefs.SetInt(itemScriptable.name, itemScriptable.amount);
        }
        else if (PlayerPrefs.HasKey(itemScriptable.name))
        {
            itemScriptable.amount++;

            PlayerPrefs.SetInt(itemScriptable.name, itemScriptable.amount);
        }
    }
    public void RemoveItem(ItemScriptable itemScriptable)
    {
        if (itemScriptable.amount > 0)
        {
            itemScriptable.amount--;

            PlayerPrefs.SetInt(itemScriptable.name, itemScriptable.amount);

        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Intro", 0);
    }
}


