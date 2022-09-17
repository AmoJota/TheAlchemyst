using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Orders : MonoBehaviour
{
    [SerializeField] List<ItemScriptable> item, itemT2, itemT3 = null;
    [SerializeField] ScriptableOrder[] orders;
    [SerializeField] GameObject[] imageOrders = null;
    [SerializeField] TextMeshProUGUI[] textOrders = null;
    [SerializeField] FourOrders[] fourOrders;
    //bool tier2 = false;
    private void Awake()
    {
        //Tier2Activated();
        //Tier3Activated();
    }
    private void Start()
    {

        ExistentMisions();

        if (fourOrders[0].isEmpty == 0 && fourOrders[1].isEmpty == 0 && fourOrders[2].isEmpty == 0 && fourOrders[3].isEmpty == 0 && SingletonTime.singleton.timeNextMision > 1)
        {
            NewMision();
        }        
    }

    //void Tier2Activated() // Mete objetos de Tier 2 en la lista item
    //{
    //    for (int i = 0; i < itemT2.Count; i++)
    //    {
    //        item.Add(itemT2[i]);
    //    }
    //}

    //void Tier3Activated() // Mete objetos de Tier 3 en la lista item
    //{
    //    for (int i = 0; i < itemT3.Count; i++)
    //    {
    //        item.Add(itemT3[i]);
    //    }
    //}
    private void Update()
    {
        if (SingletonTime.singleton.timeNextMision <= 0)
        {
            NewMision();

            SingletonTime.singleton.timeNextMision = 360f;
        }
    }
    void ExistentMisions()
    {
        for (int exist = 0; exist < fourOrders.Length; exist++)
        {        
            int mision = fourOrders[exist].prefabNumber; ;
            int textMision = fourOrders[exist].prefabText;
            int empty = fourOrders[exist].isEmpty;

            if (empty == 1)
            {
                int i = 0;

                while (i < orders.Length)
                {
                    if (orders[i].id == textMision)
                    {
                        textOrders[exist].text = orders[textMision].RescueMision();
                    }
                    i++;
                }

                int i2 = 0;

                while (i2 < item.Count)
                {
                    if (item[i2].id == mision)
                    {
                        GameObject temp = Instantiate(item[mision].prefab, imageOrders[exist].transform.position, Quaternion.identity);
                    }
                    i2++;
                }
            }
            else if(empty == 1)
            {
                exist++;
            }
        }
    }
    void NewMision()
    {
        for (int mision = 0; mision < fourOrders.Length; mision++)
        {
            if (fourOrders[mision].isEmpty == 0)
            {
                int randomItem = Random.Range(0, item.Count);
                int randomText = Random.Range(0, textOrders.Length);
                textOrders[mision].text = orders[randomText].RescueMision();
              
                fourOrders[mision].prefabNumber = item[randomItem].id;
                fourOrders[mision].prefabText = orders[randomText].id;
                fourOrders[mision].isEmpty = 1;

                GameObject temp = Instantiate(item[randomItem].prefab, imageOrders[mision].transform.position, Quaternion.identity);

                break;
            }
        }
    }
}
