using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeAvatar : MonoBehaviour
{
    [SerializeField] Image avatar;
    [SerializeField] PlayerInfo[] playerInfo;
    [SerializeField] TMP_InputField writedName;
    TouchScreenKeyboard keyBoardAndoid;
    string message = "";

    int numberAvatar = 0;
    private void OnEnable()
    {
        writedName.text = PlayerPrefs.GetString("NameAvatar");

        int load = LoadAvatar();
        avatar.sprite = playerInfo[load].GetImage();

    }
    public void ChangeMyAvatar(int avatarInt)  //Funcion para cada boton de cada avatar
    {
        avatar.sprite = playerInfo[avatarInt].GetImage();
        numberAvatar = avatarInt;
        PlayerPrefs.SetInt("IntAvatar", numberAvatar);
    }
    public void ChangeName()
    {

        keyBoardAndoid = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
        
    }
    private void Update()
    {
        if (TouchScreenKeyboard.visible == false && keyBoardAndoid != null)
        {
            if (true)
            {
                message = writedName.text;
                writedName.text = message;
                PlayerPrefs.SetString("NameAvatar", writedName.text);
                keyBoardAndoid = null;
            }
        }
    }
    int LoadAvatar()
    {
        return PlayerPrefs.GetInt("IntAvatar");
    }
}
