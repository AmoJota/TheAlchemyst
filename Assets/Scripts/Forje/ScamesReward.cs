using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScamesReward : MonoBehaviour
{
    [SerializeField] Image scalesImage;
    int scales = 0;
    [SerializeField] ItemScriptable item1, item2, item3, item4;

    private void OnEnable()
    {
        scales = PlayerPrefs.GetInt("Scales");
        SetImageScales();

    }
    void SetImageScales()
    {

        if (scales == 1001)
        {
            scalesImage.sprite = item1.prefab.GetComponent<SpriteRenderer>().sprite;
            Inventory.singleton.AddItem(item1);
        }
        if (scales == 1002)
        {
            scalesImage.sprite = item2.prefab.GetComponent<SpriteRenderer>().sprite;

            Inventory.singleton.AddItem(item2);

        }
        if (scales == 1003)
        {
            scalesImage.sprite = item3.prefab.GetComponent<SpriteRenderer>().sprite;

            Inventory.singleton.AddItem(item3);

        }
        if (scales == 1004)
        {
            scalesImage.sprite = item4.prefab.GetComponent<SpriteRenderer>().sprite;

            Inventory.singleton.AddItem(item4);

        }
    }
}