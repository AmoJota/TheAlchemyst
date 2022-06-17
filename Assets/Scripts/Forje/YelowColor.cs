using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YelowColor : MonoBehaviour
{
    SpriteRenderer renderer = null;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
    }
    void ChangeColor()
    { 
        renderer.color = Color.yellow;
    }
}
