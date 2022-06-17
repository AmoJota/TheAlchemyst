using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoneList : MonoBehaviour
{
    [SerializeField] List<GameObject> boneList;

    [SerializeField] SpawnCollect spawnCollect = null;
    private void OnEnable()
    {
        int random = Random.Range(1, 7);

        for (int i = 0; i < random; i++)
        {
            GameObject temp = Instantiate(boneList[Random.Range(0, boneList.Count)], SpawnCollect.respawns[i].transform.position, Quaternion.identity);
            spawnCollect.ItemsToCount(temp);
        }
    }
}
