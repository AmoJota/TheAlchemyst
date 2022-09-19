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

    int empty, id;
    private void Awake()
    {
        //Tier2Activated();
        //Tier3Activated();
        
    }
    private void Start()
    {
        Emptys();

        ExistentMisions();

        if (fourOrders[0].isEmpty == 0 && fourOrders[1].isEmpty == 0 && fourOrders[2].isEmpty == 0 && fourOrders[3].isEmpty == 0 && SingletonTime.singleton.timeNextMision > 1)
        {
            NewMision();
        }        
    }

    void Emptys()
    {
        for (int i = 0; i < fourOrders.Length; i++)
        {
            empty = PlayerPrefs.GetInt("IsEmpty" + i);
            id = PlayerPrefs.GetInt("id" + i);

            fourOrders[i].isEmpty = empty;
            fourOrders[i].id = id;
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
                      
            if (fourOrders[exist].isEmpty == 1)
            {
                textOrders[exist].text = orders[id].RescueMision();

                GameObject temp = Instantiate(orders[id].RescueObject(), imageOrders[exist].transform.position, Quaternion.identity);
            }
        }
    }
    void NewMision()
    {
        for (int mision = 0; mision < fourOrders.Length; mision++)
        {           
            if (fourOrders[mision].isEmpty == 0)
            {

                int randomOrder = Random.Range(0, orders.Length);

                textOrders[mision].text = orders[randomOrder].RescueMision();

                PlayerPrefs.SetInt("IsEmpty" + mision, 1);
                PlayerPrefs.SetInt("id" + mision, orders[randomOrder].id);

                Debug.Log(empty);
                Debug.Log(id);


                GameObject temp = Instantiate(orders[randomOrder].RescueObject(), imageOrders[mision].transform.position, Quaternion.identity);

                break;
            }
        }
    }
}
