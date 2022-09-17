using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{

    SpriteRenderer renderers = null;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clipForge, clipEndForge;

    [SerializeField] float timer = 10f;
    bool controlTime = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<SpriteRenderer>().color != Color.green && !other.gameObject.CompareTag("Hammer"))
        {
            controlTime = false;
            timer = 10;
            audioSource.Play();
            renderers = other.gameObject.GetComponent<SpriteRenderer>();
        }
    }
    private void Update()
    {
        if (controlTime == false)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && !controlTime)
        {
            audioSource.Stop();
            renderers.color = Color.green;
            audioSource.PlayOneShot(clipEndForge);
            controlTime = true;
        }
    }
  

    private void OnTriggerExit(Collider other)
    {
        if (timer > 0)
        {
            controlTime = true; 
            timer = 10;
        }  
            audioSource.Stop();
    }
}
