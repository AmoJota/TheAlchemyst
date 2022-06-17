using PlayFab;
using PlayFab.ClientModels;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayFabLogin : MonoBehaviour
{
    [Header("Windows")]
    public GameObject nameWindow;
    public TMP_InputField nameField;
    [SerializeField] GameObject rowPrefab;
    [SerializeField] Transform rowsParent;

    string loggedInPlayfabId;

    public void Start()  // No olvidar meter el TitleID en el editor, en el panel de PlayFab
    {
        Login();    
    }
    void Login()
    {
        LoginWithAndroidDeviceIDRequest androidRequest = new LoginWithAndroidDeviceIDRequest     
        {
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };

        PlayFabClientAPI.LoginWithAndroidDeviceID(androidRequest, OnLoginSuccess, OnError);
    }
    private void OnLoginSuccess(LoginResult result)
    {
        loggedInPlayfabId = result.PlayFabId;
        Debug.Log("Congratulations, you made your first successful API call!");
        
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
        }

        if (name == null)
        {
            nameWindow.SetActive(true);
        }

        GetLeaderboardAroundPlayer();


    }
    private void OnError(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "money", Value = score
                    
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    
    }
    private void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }

    //public void GetLeaderboard()
    //{
    //    var request = new GetLeaderboardRequest
    //    {
    //        StatisticName = "money", StartPosition = 0, MaxResultsCount = 5
    //    };

    //    PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);

        
    //}
    public void GetLeaderboardAroundPlayer()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "money",
            MaxResultsCount = 5
        };

        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboarAroundPlayerdGet, OnError);
    
    }
    private void OnLeaderboarAroundPlayerdGet(GetLeaderboardAroundPlayerResult result)
    {
        
        foreach (Transform item in rowsParent)
        {
            if (item != null)
            { 
                Destroy(item.gameObject);
            }
        }
        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            if (item.PlayFabId == loggedInPlayfabId)
            {
                texts[0].color = Color.cyan;
                texts[1].color = Color.cyan;
                texts[2].color = Color.cyan;
            }

            Debug.Log(string.Format("PLACE: {0} | ID: {1} | VALUE: {2}", item.Position, item.PlayFabId, item.StatValue));
        }
    }

    public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameField.text,
        };

        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OndisplayNameUpdate, OnError);
    }

    private void OndisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name!");
    }
}
