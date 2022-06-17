using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class PlayerInfo : ScriptableObject
{
    [SerializeField] Sprite avatarScriptable;
    [SerializeField] int number = 0;
    public Sprite GetImage()
    {
        return avatarScriptable;
    }

    public int GetInt()
    {
        return number;
    }
}
