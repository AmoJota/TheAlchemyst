using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectSelected : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI textSelected;
    [SerializeField] Image image = null;
    [SerializeField] Image[] imagesSelected = null;
    [SerializeField] Image[] tempImagesSelected = null;
    ChangeList changeList = null;
    int countImages = 0, countGreen = 0;
    [SerializeField] GameObject cauldronTouchParticles = null;
    bool control = false;
    private void Awake()
    {
        changeList = FindObjectOfType<ChangeList>();
    }
    public void SelectText(TextMeshProUGUI tempText)
    {
        textSelected.text = tempText.text;
    }

    public void SelectImage(Image tempImage)
    {
        image.sprite = tempImage.sprite;
    }

    public void Image1(Image tempImage1)
    {
        tempImagesSelected[0] = tempImage1;
    }
    public void Image2(Image tempImage2)
    {
        tempImagesSelected[1] = tempImage2;
    }
    public void Image3(Image tempImage3)
    {
        tempImagesSelected[2] = tempImage3;
    }
    public void Image4(Image tempImage4)
    {
        tempImagesSelected[3] = tempImage4;
    }
    public void Image5(Image tempImage5)
    {
        tempImagesSelected[4] = tempImage5;
    }

    private void Update()
    {
        if (control)
        {
            SelectPositions();
            control = false;
        }   
    }
    public void GoImages()
    {
        control = true;
    }
    public void SelectPositions()
    {
        
        for (int i = 0; i < tempImagesSelected.Length; i++)
        {
            if (tempImagesSelected[i] != null)
            {
                imagesSelected[i].sprite = tempImagesSelected[i].sprite;
                imagesSelected[i].enabled = true;

                countImages++;
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {       

        for (int i = 0; i < imagesSelected.Length; i++)
        {
            Sprite sp1 = imagesSelected[i].GetComponent<Image>().sprite;
            Sprite sp2 = collision.GetComponent<SpriteRenderer>().sprite;

            if (sp1 == sp2 && imagesSelected[i].color == Color.white)
            {
                Inventory.singleton.RemoveItem(collision.gameObject.GetComponent<Item>().GetItemScriptable());
                imagesSelected[i].color = Color.green;
                changeList.spritesMatch = true;
                countGreen++;

                if (countGreen == countImages)
                {
                    cauldronTouchParticles.SetActive(true);
                    break;
                }              
            }
        }          
    }

    public void AllWhite()
    {
        for (int i = 0; i < imagesSelected.Length; i++)
        {
            imagesSelected[i].color = Color.white;
            countGreen = 0;
            countImages = 0;
        }
    }
}
