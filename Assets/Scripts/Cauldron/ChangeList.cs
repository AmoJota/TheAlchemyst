using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeList : MonoBehaviour
{
    [SerializeField] List<GameObject> objectsInView;

    [SerializeField] ObjectType type;

    int index = 0;

    public bool spritesMatch = false;

    private void OnEnable()
    {
        ClearView();

    }
    private void Update()
    {
        if (spritesMatch)
        {
            ClearView();
        }
    }

    public void ClearView()
    {

        index = 0;

        for (int i = 0; i < objectsInView.Count; i++)
        {
            if (objectsInView[i].transform.childCount > 1)
            {
                objectsInView[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "";
                Destroy(objectsInView[i].transform.GetChild(1).gameObject);
            }
        }

        ChangeNextList();
    }
    public void ChangeNextList()
    {

        for (int i = 0; i < Inventory.singleton.inventary.Count; i++)
        {
            int GoTemp = PlayerPrefs.GetInt(Inventory.singleton.inventary[i].name, Inventory.singleton.inventary[i].amount);
            Inventory.singleton.inventary[i].amount = GoTemp; 

            if (Inventory.singleton.inventary[i].objectType == type && Inventory.singleton.inventary[i].amount > 0)
            {
                GameObject temp = Instantiate(Inventory.singleton.inventary[i].prefab);
                temp.transform.SetParent(objectsInView[index].transform);
                temp.transform.position = temp.transform.parent.position;
                int itemAmount = temp.GetComponent<Item>().GetScriptableAmount(); 
                objectsInView[index].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemAmount.ToString();
                spritesMatch = false;

                index++;
            }
        }
    }
    
}
