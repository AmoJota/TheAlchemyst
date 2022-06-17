using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodList : MonoBehaviour
{
    [SerializeField] List<GameObject> foolList;
    [SerializeField] SpawnCollect spawnCollect = null;
    private void OnEnable()
    {
        int random = Random.Range(1, 7);

        for (int i = 0; i < random; i++)
        {
            GameObject temp = Instantiate(foolList[Random.Range(0, foolList.Count)], SpawnCollect.respawns[i].transform.position, Quaternion.identity);
            spawnCollect.ItemsToCount(temp);
        }
    }
}


