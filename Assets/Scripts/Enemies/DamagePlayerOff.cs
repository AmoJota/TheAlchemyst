using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayerOff : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    private void OnEnable()
    {
        Invoke("TurnOff",1f);
        audioSource.PlayOneShot(clip);
    }

    void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
