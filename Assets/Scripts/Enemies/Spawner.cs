using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;
    void OnEnable()
    {
        NextEnemy();
    }  
    public void NextEnemy()
    {
        int random = Random.Range(0, enemies.Length);
        
        GameObject temp = Instantiate(enemies[random], transform.position, Quaternion.identity);
    }
}
