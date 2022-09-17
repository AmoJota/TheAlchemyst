using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnCollect : MonoBehaviour
{
    public static Transform[] respawns;

    [SerializeField] Transform[] respawns2;

    public float rewardedTime = 10; // Nuevo loot cada 20 minutos

    [SerializeField] MonoBehaviour[] nextLoot = null;

    int random;

    [SerializeField] List<GameObject> itemstoLoot;

    private void Start()
    {
        respawns = respawns2;
           
    }
    private void Update()
    {
      
       NextLoot();
               
    }
    void FirstLoot()
    {
        random = Random.Range(0, 9);

        nextLoot[random].enabled = true;
    }
    void NextLoot()
    {
        if (SingletonTime.singleton.rest <= 0)
        {
            SingletonTime.singleton.rest = 1200f;

            nextLoot[random].enabled = false;

            random = Random.Range(0, nextLoot.Length);

            nextLoot[random].enabled = true;

        }      
    }
    public void ItemsToCount(GameObject newItem)
    {
        itemstoLoot.Add(newItem);   
    }   
}
