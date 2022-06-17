using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DeliverMision : MonoBehaviour
{
    [SerializeField] FourOrders fourOrder;
    int numberFourOrder;
    [SerializeField] TextMeshProUGUI text;
    int action = 0;
    private void OnEnable()
    {
        LoadChanges();        
    }
    public void DeliverMisionButton()
    {
        action = 1;
        GetComponent<Collider>().enabled = true;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<Item>().GetScriptableAmount() > 0  && action == 1)
        {
            AutoCoins coins = FindObjectOfType<AutoCoins>();
            coins.GoldReward();
            action = 0;
            text.text = "";
            fourOrder.isEmpty = 0;
            PlayerPrefs.SetInt("IsEmpty" + fourOrder.id, 0);
            Inventory.singleton.RemoveItem(collision.gameObject.GetComponent<Item>().GetItemScriptable());
            Destroy(collision.gameObject);

            GetComponent<Collider>().enabled = false;
        }
        else if(action == 2)
        {
            Destroy(collision.gameObject);
            action = 0;
            GetComponent<Collider>().enabled = false;
        }
    }
    public void CancelMision()
    {
        action = 2;
        GetComponent<Collider>().enabled = true;
        
        text.text = "";
        fourOrder.isEmpty = 0;
        PlayerPrefs.SetInt("IsEmpty" + fourOrder.id, 0);
    }
    public void SaveChanges()
    {
        PlayerPrefs.SetInt("Mision" + fourOrder.id, fourOrder.prefabNumber);
        PlayerPrefs.SetInt("Text" + fourOrder.id, fourOrder.prefabText);
        PlayerPrefs.SetInt("IsEmpty" + fourOrder.id, fourOrder.isEmpty);
    }
    public void LoadChanges()
    {
        
        fourOrder.prefabNumber = PlayerPrefs.GetInt("Mision" + fourOrder.id);
        fourOrder.prefabText = PlayerPrefs.GetInt("Text" + fourOrder.id);
        fourOrder.isEmpty = PlayerPrefs.GetInt("IsEmpty" + fourOrder.id);
    }

    private void OnDisable()
    {
        SaveChanges();
    }
}
