using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System;

/*
public class DailyLoginTracker : MonoBehaviour
{
    public Text consecutiveDaysText;

    private const string LastLoginKey = "lastLogin";
    private const string ConsecutiveDaysKey = "consecutiveDays";

    void Start()
    {
        VerificarLogin();
    }

    private void VerificarLogin()
    {
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, result =>
        {
            DateTime lastLoginDate;
            DateTime today = DateTime.UtcNow.Date;
            int consecutiveDays = 0;

            if (result.Data != null && result.Data.ContainsKey(LastLoginKey))
            {
                lastLoginDate = DateTime.Parse(result.Data[LastLoginKey].Value, null, System.Globalization.DateTimeStyles.RoundtripKind);

                if (lastLoginDate == today.AddDays(-1))
                {
                    consecutiveDays = result.Data.ContainsKey(ConsecutiveDaysKey) ? int.Parse(result.Data[ConsecutiveDaysKey].Value) + 1 : 1;
                }
                else if (lastLoginDate < today.AddDays(-1))
                {
                    consecutiveDays = 1;
                }
            }
            else
            {
                consecutiveDays = 1; // First login or no data
            }

            UpdateUserData(today, consecutiveDays);

        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    private void UpdateUserData(DateTime lastLoginDate, int consecutiveDays)
    {
        var updateData = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { LastLoginKey, lastLoginDate.ToString("o") },
                { ConsecutiveDaysKey, consecutiveDays.ToString() }
            }
        };

        PlayFabClientAPI.UpdateUserData(updateData, response =>
        {
            consecutiveDaysText.text = $"Dias seguidos: {consecutiveDays}";
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }
}*/
