using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemBookList : MonoBehaviour
{
    [SerializeField] List<GameObject> gemBooksList;
    [SerializeField] SpawnCollect spawnCollect = null;
    private void OnEnable()
    {
        int random = Random.Range(1, 7);

        for (int i = 0; i < random; i++)
        {
            GameObject temp = Instantiate(gemBooksList[Random.Range(0, gemBooksList.Count)], SpawnCollect.respawns[i].transform.position, Quaternion.identity);
            spawnCollect.ItemsToCount(temp);
        }
    }
}
