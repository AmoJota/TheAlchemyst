using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu]
public class FourOrders : ScriptableObject
{
    public GameObject prefab;
    [TextArea(1, 4)] public string text;


    public int  isEmpty, id, number;
}
