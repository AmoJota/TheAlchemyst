using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminatorCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        Destroy(collision.gameObject);
    }
}
