using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PayScames : MonoBehaviour
{
    [SerializeField] ItemScriptable[] scames;
    [SerializeField] TextMeshProUGUI[] scamesText;  
    private void OnEnable()
    {
        GetValues();
    }
    public void GetScamesAmount(Item scame)
    {
        if ( scame.GetScriptableAmount() >= 2)
        {
            Inventory.singleton.RemoveItem(scame.GetItemScriptable());
            Inventory.singleton.RemoveItem(scame.GetItemScriptable());
        }
    }
    public void Value(int value)
    {
        PlayerPrefs.SetInt("Scame", value);  
    }

    void GetValues()
    {
        for (int i = 0; i < scamesText.Length; i++)
        {
            scamesText[i].text = "Cost : " + scames[i].amount.ToString() + " / 2";
        }
    }
}
