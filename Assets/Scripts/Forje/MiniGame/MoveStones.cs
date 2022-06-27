using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStones : MonoBehaviour
{ 
    float distance = 0;
    Transform toDrag;
    GameObject item;
    RaycastHit2D ray2D;
    [SerializeField] Camera main;
    [SerializeField] int myLayer;
    Touch touch;
    Vector3 pos, v3, offset;
    [SerializeField] SelectNextStone nextStone;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.touches[0];
            pos = touch.position;

            if (touch.phase == TouchPhase.Began )
            {
                FirstTouch();
            }

            if (touch.phase == TouchPhase.Moved && item != null)
            {
                Moving();                                         
            }

            if ((touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) && item != null)
            {
                EndMove();
            }
        }
    }

    void FirstTouch()
    {
        Ray ray = main.ScreenPointToRay(pos);

        ray2D = Physics2D.GetRayIntersection(ray, 1000f);

        if (ray2D.collider != null)
        {
            if (ray2D.collider.gameObject.layer == myLayer)
            {
                item = ray2D.collider.gameObject;

                toDrag = item.transform;
                distance = item.transform.position.z - main.transform.position.z;
                v3 = new Vector3(pos.x, pos.y, distance);
                v3 = main.ScreenToWorldPoint(v3);
                offset = toDrag.position - v3;
            }
        }
    }
    void Moving()
    {
        v3 = new Vector3(pos.x, pos.y, distance);
        v3 = main.ScreenToWorldPoint(v3);
        toDrag.position = v3 + offset;
    }
    void EndMove()
    {
        GetParentDetachChildren();
        Invoke("NextStone", 5f);       
        item.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        item = null;
    }
    void NextStone()
    {
        nextStone.NextObject(true);
    }
    void GetParentDetachChildren()
    {
        Transform parent = item.transform.parent;
        parent.DetachChildren();
        parent = null;
    }
}
