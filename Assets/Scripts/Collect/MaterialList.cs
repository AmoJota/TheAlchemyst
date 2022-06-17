using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialList : MonoBehaviour
{
    [SerializeField] List<GameObject> materialList;
    [SerializeField] SpawnCollect spawnCollect = null;
    private void OnEnable()
    {
        int random = Random.Range(1, 7);

        for (int i = 0; i < random; i++)
        {
            GameObject temp = Instantiate(materialList[Random.Range(0, materialList.Count)], SpawnCollect.respawns[i].transform.position, Quaternion.identity);
            spawnCollect.ItemsToCount(temp);
        }
    }
}
