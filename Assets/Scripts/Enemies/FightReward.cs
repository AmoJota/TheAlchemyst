using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightReward : MonoBehaviour
{
    [SerializeField] GameObject[] materials;
    [SerializeField] Transform[] trans;

    private void OnEnable()
    {
        MaterialReward();
    }
    public void MaterialReward()
    {
        int random = Random.Range(1,4);

        for (int i = 0; i < random; i++)
        {
            int randomObject = Random.Range(0, materials.Length);

            GameObject temp = Instantiate(materials[randomObject], trans[i].position, Quaternion.identity);
        }
    }
}
