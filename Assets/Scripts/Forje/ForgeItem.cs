using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ForgeItem : MonoBehaviour
{
    [SerializeField] Transform itemPosition;
    [SerializeField] ItemScriptable minerals, plates;
    [SerializeField] TextMeshProUGUI textMineral, textPlate;
    [SerializeField] int needMineral, needPlate;
    void Start()
    {
        textMineral.text = "x " + minerals.amount.ToString() + "/" + needMineral;
        textPlate.text = "x " + plates.amount.ToString() + "/" + needPlate;
    }

    public void CreateNewItem(ItemScriptable item) 
    {
        int mineral = minerals.amount;
        int plate = plates.amount;

        if (mineral >= needMineral && plate >= needPlate )
        {
            for (int i = 0; i < needMineral; i++)
            {
                Inventory.singleton.RemoveItem(minerals);
                textMineral.text = "x " + minerals.amount.ToString() + "/" + needMineral;
            }
            for (int i2 = 0; i2 < needPlate; i2++)
            {
                Inventory.singleton.RemoveItem(plates);
                textPlate.text = "x " + plates.amount.ToString() + "/" + needPlate;
            }

            GameObject temp = Instantiate(item.prefab, itemPosition.position, Quaternion.identity);
        }
    }
}
