using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDragging : MonoBehaviour
{
    float distance = 0;
    bool dragging = false;
    Vector3 offset;
    Transform toDrag;
    Vector3 itemFirstPosition;
    GameObject item;
    

    
    void Update()
    {
        Vector3 v3;

        if (Input.touchCount != 1)
        {
            dragging = false;
            return;
        }

        Touch touch = Input.touches[0];
        Vector3 pos = touch.position;

        if (touch.phase == TouchPhase.Began)
        {
            RaycastHit hit;
            Ray ray= Camera.main.ScreenPointToRay(pos);

            if (Physics.Raycast(ray,out hit) && (hit.collider.gameObject.layer == 8))
            {
                item = hit.collider.gameObject;
                itemFirstPosition = hit.collider.gameObject.transform.position;
                toDrag = hit.transform;
                distance = hit.transform.position.z - Camera.main.transform.position.z;
                v3 = new Vector3(pos.x, pos.y, distance);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                offset = toDrag.position - v3;

                dragging = true;
            }           
        }

        if (dragging && touch.phase == TouchPhase.Moved)
        {
            if (item != null)
            {
                v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                toDrag.position = v3 + offset;
            }
            
        }

        if (dragging && touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
        {
            if (item != null)
            {
                dragging = false;
                item.transform.position = itemFirstPosition;
            }           
        }
    }
}
