using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TimeToCollect : MonoBehaviour
{

    public TextMeshProUGUI textTimer = null;
    [SerializeField] GameObject eliminator = null;
    
    
    void Update()
    {    
        textTimer.text = "Next loot in : " + SingletonTime.singleton.ReturnTime();


        GoEliminator();
    }

    void GoEliminator()
    {
        if (SingletonTime.singleton.timeNextLoot > 1.2f && SingletonTime.singleton.timeNextLoot <= 2f)
        {
            eliminator.SetActive(true);

        }
        if (SingletonTime.singleton.timeNextLoot <= 1f)
        {
            eliminator.SetActive(false);
        }        
    }   
}
