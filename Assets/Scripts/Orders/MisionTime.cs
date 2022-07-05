using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MisionTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI misionTime;
    void Update()
    {
        misionTime.text = "Next mision in : " + SingletonTime.singleton.timeNextMision.ToString("N0") + " Seconds";
    }
}
