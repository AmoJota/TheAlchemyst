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

            Debug.Log(idScales);
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

        switch (idScales)
        {
            case 1001:
                DragonScalesReward(1001, 1002, 1003, 1004);
                Debug.Log("Case 1");

                break;
            case 1002:
                Debug.Log("Case 2");
                DragonScalesReward(1002, 1001, 1003, 1004);
                break;
            case 1003:
                Debug.Log("Case 3");
                DragonScalesReward(1003, 1002, 1001, 1004);
                break;
            case 1004:
                Debug.Log("Case 4");
                DragonScalesReward(1004, 1002, 1003, 1001);
                break;
        }
    }

    void DragonScalesReward(int one, int two, int three, int four)
    {
        int random = Random.Range(0, 100);

        if (random < 80)
        {
            PlayerPrefs.SetInt("Scales", one);
            Debug.Log("Entro en 1");
        }
        else if (random >= 80 && random <= 87)
        {
            PlayerPrefs.SetInt("Scales", two);
            Debug.Log("Entro en 2");

        }
        else if (random >= 88 && random < 95)
        {
            PlayerPrefs.SetInt("Scales", three);
            Debug.Log("Entro en 3");

        }
        else if (random >= 95 && random <= 100)
        {
            PlayerPrefs.SetInt("Scales", four);
            Debug.Log("Entro en 4");
        }
    }
}
