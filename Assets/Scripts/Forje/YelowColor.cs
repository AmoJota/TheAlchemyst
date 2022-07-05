using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YelowColor : MonoBehaviour
{
    SpriteRenderer renderers;

    private void Awake()
    {
        renderers = GetComponent<SpriteRenderer>();
    }
    void ChangeColor()
    { 
        renderers.color = Color.yellow;
    }
}
