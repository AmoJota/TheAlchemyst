using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CauldronParticles : MonoBehaviour
{
    Touch touch;
    [SerializeField] GameObject particles = null, returnButton = null, craftedText = null;
    [SerializeField] Image itemToCraft = null, itemParticles = null, chargeBar = null;
    [SerializeField] Image[] allWhite = null;
    float retroTimer = 0.2f;
    [SerializeField] AudioSource audioSource = null;
    [SerializeField] AudioClip clip = null;
    bool isSound = false, control = false;
    private void Update()
    {
        retroTimer -= Time.deltaTime;

        TouchGiro();

        SoundOnOff();

        ClaimItem();
        
    }
    void SoundOnOff()
    {
        if (isSound && chargeBar.fillAmount > 0f)
        {
            audioSource.PlayOneShot(clip);
            isSound = false;
        }
        else
        {
            audioSource.Stop();
        }
    }

    void ClaimItem()
    {
        if (chargeBar.fillAmount <= 0f && !control)
        {
            control = true;
            chargeBar.fillAmount = 0f;
            returnButton.SetActive(true);
            craftedText.SetActive(true);

            for (int i = 0; i < Inventory.singleton.inventary.Count; i++)
            {
                if (Inventory.singleton.inventary[i].prefab.GetComponent<SpriteRenderer>().sprite == itemToCraft.sprite)
                {
                    ItemScriptable item = Inventory.singleton.inventary[i];
                    Inventory.singleton.AddItem(item);
                    break;
                }
            }
        }
    
    }
    void TimeToCraft()
    {             
        if (retroTimer <= 0)
        {
            chargeBar.fillAmount -= 0.03f;
            retroTimer = 0.2f;
        }
    
    }
    void TouchGiro()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                if (chargeBar.fillAmount > 0f)
                {
                    particles.SetActive(true);
                    particles.transform.position = touch.deltaPosition * Time.deltaTime;
                    TimeToCraft();
                }
                               
                isSound = true;
            }
            else
            {
                particles.SetActive(false);

                if (chargeBar.fillAmount > 0f)
                {
                    chargeBar.fillAmount = 1f;
                }

                isSound = false;
            }
        }
    }

    private void OnEnable()
    {
        itemParticles.sprite = itemToCraft.sprite;
    }
    private void OnDisable()
    {
        for (int i = 0; i < allWhite.Length; i++)
        {
            allWhite[i].color = Color.white;
        }

        control = false;
        chargeBar.fillAmount = 1f;
        returnButton.SetActive(false);
        craftedText.SetActive(false);
    }
}
