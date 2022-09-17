using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Anvil : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip clip;
    [SerializeField] ParticleSystem particles, particlesYelow;
    int enter = 0, idScales;

    [SerializeField] Image progressCraft;

    float actualProgress, totalProgress = 100;


    [SerializeField] GameObject scalesReward = null, objectToDestroy = null;

    private void Update()
    {
        progressCraft.fillAmount = actualProgress / totalProgress;       
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<SpriteRenderer>().color == Color.green)
        {
            idScales = other.gameObject.GetComponent<Item>().GetItemScriptable().id;

            enter = 1;

            objectToDestroy = other.gameObject;
        }

        if (other.CompareTag("Hammer") && enter == 1)
        {
            audioSource.PlayOneShot(clip);
            particles.Play();
            particlesYelow.Play();
            actualProgress += 10;

            if (actualProgress >= totalProgress)
            {
                SwitchScales();
                Destroy(objectToDestroy);           
                actualProgress = 0;
                scalesReward.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<SpriteRenderer>().color == Color.green)
        {
            enter = 0;
        }
    }

    void SwitchScales()
    {
        if (idScales == 1001)
        {
            DragonScalesReward(1001, 1002, 1003);
        }
        if (idScales == 1002)
        {
            DragonScalesReward(1002, 1001, 1003);

        }
        if (idScales == 1003)
        {
            DragonScalesReward(1003, 1002, 1001);

        }      
    }

    void DragonScalesReward(int one, int two, int three)
    {
        int random = Random.Range(0, 100);

        if (random < 85)
        {
            PlayerPrefs.SetInt("Scales", one);
        }
        else if (random >= 85 && random <= 92)
        {
            PlayerPrefs.SetInt("Scales", two);
        }
        else if (random >= 93 && random <= 100)
        {
            PlayerPrefs.SetInt("Scales", three);
        }
    }
}
