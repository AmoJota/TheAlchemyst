using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MystList : MonoBehaviour
{
    [SerializeField] List<GameObject> mystList;

    [SerializeField] SpawnCollect spawnCollect = null;
    private void OnEnable()
    {        
        int random = Random.Range(1, 7);

        for (int i = 0; i < random; i++)
        {
            GameObject temp = Instantiate(mystList[Random.Range(0, mystList.Count)], SpawnCollect.respawns[i].transform.position, Quaternion.identity);

            spawnCollect.ItemsToCount(temp);

        }
    }


}
