using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapCollectTIme : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    [SerializeField] SingletonTime time;

    private void Awake()
    {
        time = FindObjectOfType<SingletonTime>();
    }
    public void TapButtonTime()
    {
        particles.Play();
        time.rest -= 20f;
    }
}
