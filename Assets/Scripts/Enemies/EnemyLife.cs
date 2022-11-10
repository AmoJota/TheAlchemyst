using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] Image image;
    float life = 100f;

    private void Update()
    {
        image.fillAmount = life / 100;
    }
    public void SetLife(float newLife)
    {
        life = newLife;
    }
}
