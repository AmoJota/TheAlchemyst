using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{ 
    Food, Gem, Book, Rune, Material, Potion, Tool, Myst, Key, Metal
}

[CreateAssetMenu]
public class ItemScriptable : ScriptableObject
{
    
    public string nameObject;
    [TextArea(2, 6)]
    public string description;
    public ObjectType objectType;
    public int level = 0;
    public int amount = 0;
    public GameObject prefab;
    public int id = 0;
}


