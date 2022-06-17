using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchForje : MonoBehaviour
{
    Touch touchForje;
    Touch secondTouchForje;
   
    void Update()
    {
        touchForje = Input.GetTouch(0);
        secondTouchForje = Input.GetTouch(1);

        if (Input.touchCount > 1)
        {
            if (touchForje.phase == TouchPhase.Moved && secondTouchForje.phase == TouchPhase.Moved)
            {

            }
        }
    }
}
