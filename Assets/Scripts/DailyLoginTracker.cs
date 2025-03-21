using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DailyLoginTracker : MonoBehaviour
{
    public Text consecutiveDaysText;  // Referência ao texto na UI

    private void Start()
    {
        Login();
    }

    private void Login()
    {
        // Suponha que o usuário foi autenticado aqui
        CheckLastLogin();
    }

    private void CheckLastLogin()
    {
        var request = new GetUserDataRequest();
        PlayFabClientAPI.GetUserData(request, result =>
        {
            int consecutiveDays = 0;

            if (result.Data.ContainsKey("LastLoginDate"))
            {
                DateTime lastLoginDate = DateTime.Parse(result.Data["LastLoginDate"].Value);
                DateTime today = DateTime.UtcNow.Date;

                if (lastLoginDate == today.AddDays(-1))
                {
                    consecutiveDays = result.Data.ContainsKey("ConsecutiveDays") ? Convert.ToInt32(result.Data["ConsecutiveDays"].Value) + 1 : 1;
                    UpdateConsecutiveDays(consecutiveDays); // Incrementa os dias consecutivos
                }
                else if (lastLoginDate < today.AddDays(-1))
                {
                    consecutiveDays = 1;  // Reinicia a contagem se houve uma quebra na sequência
                    UpdateConsecutiveDays(consecutiveDays);
                    ResetVidas(); // Restaura as vidas
                }
            }
            else
            {
                consecutiveDays = 1;  // Primeiro login ou dados não existentes
                UpdateConsecutiveDays(consecutiveDays);
                ResetVidas(); // Restaura as vidas
            }

            // Atualiza a última data de login independente
            UpdateLastLoginDate();

            // Atualiza a UI
            UpdateConsecutiveDaysUI(consecutiveDays);

        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    private void UpdateConsecutiveDaysUI(int days)
    {
        consecutiveDaysText.text = $"Dias seguidos: {days}";
    }

    private void UpdateLastLoginDate()
    {
        var updateData = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "LastLoginDate", DateTime.UtcNow.ToString("o") }
            }
        };
        PlayFabClientAPI.UpdateUserData(updateData, response =>
        {
            Debug.Log("Last login date updated.");
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    private void UpdateConsecutiveDays(int days)
    {
        var updateData = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "ConsecutiveDays", days.ToString() }
            }
        };
        PlayFabClientAPI.UpdateUserData(updateData, response =>
        {
            Debug.Log("Consecutive days updated to: " + days);
        }, error => Debug.LogError(error.GenerateErrorReport()));
    }

    private void ResetVidas()
    {
        questions.vidas = 10; // Atualiza a variável estática
        Debug.Log("Vidas restauradas para 10.");
    }
}