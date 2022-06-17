using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiperlinks : MonoBehaviour
{
    public void GoUrl(string urlText)
    {
        Application.OpenURL(urlText);
    }    
}
