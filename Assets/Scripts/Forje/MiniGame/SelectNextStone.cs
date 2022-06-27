using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNextStone : MonoBehaviour
{
    [SerializeField] GameObject[] newPieces = new GameObject[5], allPieces;


    private void Start()
    {
        NextObject(false);
    }
    public void NextObject(bool onlyOne)
    {
        for (int i = 0; i < newPieces.Length; i++)
        {
            if (newPieces[i].transform.childCount == 0)
            {
                int random = Random.Range(0, allPieces.Length);

               GameObject temp = Instantiate(allPieces[random], newPieces[i].transform.position, Quaternion.identity);
                temp.transform.SetParent(newPieces[i].transform);
                temp.GetComponent<Rigidbody2D>().isKinematic = true;

                if (onlyOne)
                {
                    return;
                }
            }
        }
    }

    void ObjectsCount()
    {
        
    }
}
