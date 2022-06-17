using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionList : MonoBehaviour
{
    [SerializeField] List<GameObject> potionList;

    [SerializeField] SpawnCollect spawnCollect = null;
    private void OnEnable()
    {
        int random = Random.Range(1, 7);

        for (int i = 0; i < random; i++)
        {
            GameObject temp = Instantiate(potionList[Random.Range(0, potionList.Count)], SpawnCollect.respawns[i].transform.position, Quaternion.identity);
            spawnCollect.ItemsToCount(temp);
        }
    }
}
