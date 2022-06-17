using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalList : MonoBehaviour
{
    [SerializeField] List<GameObject> metalList;
    [SerializeField] SpawnCollect spawnCollect = null;
    private void OnEnable()
    {
        int random = Random.Range(1, 7);

        for (int i = 0; i < random; i++)
        {
            GameObject temp = Instantiate(metalList[Random.Range(0, metalList.Count)], SpawnCollect.respawns[i].transform.position, Quaternion.identity);
            spawnCollect.ItemsToCount(temp);
        }
    }
}
