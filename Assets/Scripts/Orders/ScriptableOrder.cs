using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu]
public class ScriptableOrder : ScriptableObject
{
    [SerializeField] GameObject scriptablePrefab;

    [TextArea(1, 4)]
    [SerializeField] string mision = null;
    public int id = 0;
    public string RescueMision()
    {
        return mision;
    }

    public GameObject RescueObject()
    {
        return scriptablePrefab;
    }
}
