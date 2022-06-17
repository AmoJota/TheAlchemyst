using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    [SerializeField] ItemScriptable itemScriptable;
    int collectScene = 5;
    private void OnMouseDown()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.buildIndex == collectScene)
        {
           
            Inventory.singleton.AddItem(itemScriptable);
            Destroy(gameObject);

        }
    }
    public int GetScriptableAmount()
    {
        return itemScriptable.amount;
    }

    public ItemScriptable GetItemScriptable()
    {
        return itemScriptable;
    }

}
