using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{ 
    Food, Gem, Rune, Material, Potion, Metal
}

[CreateAssetMenu]
public class ItemScriptable : ScriptableObject
{
    
    public string nameObject;
    public ObjectType objectType;
    public int amount = 0;
    public GameObject prefab;
    public int id = 0;
}


