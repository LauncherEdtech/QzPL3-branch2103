using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using System;
using Photon.Pun;


public class PlayfabManager : MonoBehaviour 
{
    public UILoginCadastro uiLoginCadastro; // Referência ao script de UI para login e cadastro

    [Header("UI")]

    private Dictionary<string, int> dailyProgressData = new Dictionary<string, int>();

    public static bool preencheu;
    public CharacterBox[] characterBoxes;
    public TextMeshProUGUI messageText;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField usernameInput;
    public TMP_InputField usernameInput2;

    public static string celular;
    public TMP_InputField celularinput;
    public TMP_InputField celularinput2;

    public static string email;
    public string senha;

    public GameObject rowPrefab;
    public Transform rowsParent;

    public GameObject nameWindow;
    public GameObject loginWindow;
    public GameObject panelWindow;

    public GameObject rowPrefabFirst;
    public GameObject rowPrefabSecond;
    public GameObject rowPrefabThird;


    public Text rankingText;  

    private const string LastAccessDateKey = "LastAccessDate";
    private const string ConsecutiveDaysKey = "ConsecutiveDays"; 
    public Text consecutiveDaysText;  // Referência ao componente de texto na UI
    public Text creationDateText;  // Referência ao componente Text que mostrará a data

    //public GameObject leadboard;

    string loggedInPlayfabId;

    int save;

    // Start is called before the first frame update
    void Start()
    {
       email = PlayerPrefs.GetString("email", email);
       senha = PlayerPrefs.GetString("senha", senha);

      if (email != "")
      {
            passwordInput.text = senha;
            emailInput.text = email;
            //Login();
      }


    }

    void Update()
    {
        if(messageText.text == "Name not available") 
        {
            uiLoginCadastro.Updatename();
        }

        if (controleui.apagouconta == true)
        {
            panelWindow.SetActive(true);
            messageText.text = "Conta excluida.";
        }


        if (questions.save == true)
        {
            SaveCharacters();
            questions.save = false;
        }

        if (tarefas.confirmar == 1)
        {
            SaveCharacters();
            tarefas.confirmar = 0;
        }

        if (medalhas.save == true)
        {
            SaveCharacters();
            medalhas.save = false;
        }
    }

    public Dictionary<string, int> GetDailyProgressData()
    {
        return dailyProgressData;
    }


    public void RegisterUser(string email, string password, string username)
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email,
            Password = password,
            Username = username
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    
    
    void Login()
        {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = false,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
        }
    void OnLoginSuccess(LoginResult result)
    {
        loggedInPlayfabId = result.PlayFabId;
        Debug.Log("Successsssful login!");
        string name = null;
        if (result.InfoResultPayload.PlayerProfile != null)
        name = result.InfoResultPayload.PlayerProfile.DisplayName;
        panelWindow.SetActive(false);

    }
    
    void UpdateLastLoginDate()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string> { { "LastLoginDate", DateTime.UtcNow.ToString("o") } }
        };
        PlayFabClientAPI.UpdateUserData(request, result =>
        {
            Debug.Log("Last login date updated successfully.");
        }, error =>
        {
            Debug.LogError("Failed to update last login date: " + error.GenerateErrorReport());
        });
    }


    void CheckAndUpdateConsecutiveLogins()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), result =>
        {
            if (result.Data.ContainsKey("LastLoginDate"))
            {
                if (DateTime.TryParse(result.Data["LastLoginDate"].Value, out DateTime lastLoginDate))
                {
                    DateTime today = DateTime.UtcNow.Date;
                    Debug.Log($"Last Login Date: {lastLoginDate:s}, Today: {today:s}");

                    if (lastLoginDate == today.AddDays(-1))
                    {
                        int newConsecutiveDays = PlayerPrefs.GetInt(ConsecutiveDaysKey, 0) + 1;
                        Debug.Log($"Incrementing consecutive days to: {newConsecutiveDays}");
                        UpdateConsecutiveLogins(newConsecutiveDays);
                    }
                    else if (lastLoginDate < today.AddDays(-1))
                    {
                        Debug.Log("Resetting consecutive days to 1");
                        UpdateConsecutiveLogins(1);
                    }
                }
                else
                {
                    Debug.LogError("Failed to parse LastLoginDate from PlayFab data.");
                }
            }
            else
            {
                Debug.Log("No last login date found. Assuming first login and setting consecutive days to 1.");
                UpdateConsecutiveLogins(1);
            }
        }, error =>
        {
            Debug.LogError("Failed to get user data: " + error.GenerateErrorReport());
        });
    }

    void UpdateConsecutiveLogins(int days)
    {
        PlayerPrefs.SetInt(ConsecutiveDaysKey, days);
        PlayerPrefs.Save();
        Debug.Log($"Consecutive days updated to: {days}");
        consecutiveDaysText.text = days.ToString(); // Corrigido para usar ToString()
    }

  
    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6) 
        {
            messageText.text = "Senha muito pequena";
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false,
           
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
       

        //nameWindow.SetActive(true);
        //loginWindow.SetActive(false);
        email = emailInput.text;
        senha = passwordInput.text;
        PlayerPrefs.SetString("email", email);
        PlayerPrefs.SetString("senha", senha);

        Debug.Log("Registro bem-sucedido!");
        //uiLoginCadastro.OnRegisterSuccess(); // Chama o método de sucesso no script de UI
        //messageText.text = "Registrado!";
        SubmitNameButton();
    }

    public void UpdateDisplayName()
    {
                var request = new UpdateUserTitleDisplayNameRequest
                {
                    DisplayName = usernameInput.text,

                };
                PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayaNameUpdate, OnError);
                 

        StartCoroutine("gettname");
    }


    public void SubmitNameButton()
    {
        if (usernameInput.text != "")
        {
            if (celularinput.text != "")
            {
                celular = celularinput.text;
                var request = new UpdateUserTitleDisplayNameRequest
                {                   
                    DisplayName = usernameInput.text,

                };
                PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayaNameUpdate, OnError);
            }
            else
            {
                if (preencheu == false)
                {
                    messageText.text = "Preencha todos os dados.";
                }
            }
        }
        else 
        {
            if (preencheu == false)
            {
                messageText.text = "Preencha todos os dados.";
            }
        }

        if (preencheu == true) 
        {
            usernameInput.text = "";
            var request = new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = usernameInput2.text,

            };
            PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayaNameUpdate, OnError);
        }

        StartCoroutine("gettname");
    }


    void OnDisplayaNameUpdate(UpdateUserTitleDisplayNameResult result) {
        Debug.Log("Updated display name!");
        //uiLoginCadastro.OnRegisterSuccess(); // Chama o método de sucesso no script de UI
        panelWindow.SetActive(false);
        preencheu = true;
        celular = celularinput2.text;
        medalhas.save = true;
        RegisterButton();
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
    }

    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "11641"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        messageText.text = "Password reset mail sent!";
    }

    public void SaveCharacters(){
        List<Character> characters = new List<Character>();
        foreach (var item in characterBoxes)
        {
            characters.Add(item.ReturnClass());
        }
        var request = new UpdateUserDataRequest {
            Data = new Dictionary<string, string> {
                {"Characters", JsonConvert.SerializeObject(characters) }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    public void GetCharacters() {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnCharactersDataRecieved, OnError);
    }

    void OnCharactersDataRecieved(GetUserDataResult result){
     
        Debug.Log("Recieved characters data!");
        if (result.Data != null && result.Data.ContainsKey("Characters")) {
            List<Character> characters = JsonConvert.DeserializeObject<List<Character>>(result.Data["Characters"].Value);
            for ( int i = 0; i < characterBoxes.Length;i++) {
                characterBoxes[i].SetUi(characters[i]);
            }
        }
        if (preencheu == false)
        {
            panelWindow.SetActive(true);
            nameWindow.SetActive(false);
            loginWindow.SetActive(false);
        }

    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Succeful user data send!");
    }

    void OnSuccess(LoginResult result)
    {
        loggedInPlayfabId = result.PlayFabId;
        Debug.Log("Sucessful login!");
        panelWindow.SetActive(false);
        email = emailInput.text;
        senha = passwordInput.text;
        PlayerPrefs.SetString("email", email);
        PlayerPrefs.SetString("senha", senha);
        GetCharacters();
        GetPlayerProfile();
        GetPlayerRank();  // Chamando metodo para Recuperar a Posicao do Jogador
        GetAccountCreationDate();
        UpdateLastLoginDate();  // Atualiza a data do último login no PlayFab
        CheckAndUpdateConsecutiveLogins();  // Checa e atualiza os logins consecutivos

        PhotonNetwork.NickName = result.PlayFabId; // Ou use outro valor como nome de usuário se disponível

        // Conectar ao Photon após login bem-sucedido no PlayFab
        FindObjectOfType<PhotonManager>().ConnectToPhoton();

        InicializarProgresso(() =>
        {
            Debug.Log("Progresso diário carregado após o login.");
        });
    }

    void OnError(PlayFabError error)
    {
        messageText.text = error.ErrorMessage;
        Debug.Log(error.GenerateErrorReport());
        //uiLoginCadastro.Updatename();

    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate> {
                new StatisticUpdate {
                    StatisticName = "PlatformScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
        {
            Debug.Log("Successfull leaderboard sent");
            GetLeaderboard();
        }
    public void GetLeaderboard2()
    {
        StartCoroutine("click");
    }
    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
{
    // Limpar os elementos existentes no leaderboard
    foreach (Transform item in rowsParent)
    {
        Destroy(item.gameObject);
    }

    // Iterar sobre os resultados do leaderboard
    foreach (var item in result.Leaderboard)
    {
        GameObject newGo;

        // Verificar a posição e usar diferentes prefabs ou personalizações
        if (item.Position == 0) // Primeiro colocado
        {
            newGo = Instantiate(rowPrefabFirst, rowsParent);
        }
        else if (item.Position == 1) // Segundo colocado
        {
            newGo = Instantiate(rowPrefabSecond, rowsParent);
        }
        else if (item.Position == 2) // Terceiro colocado
        {
            newGo = Instantiate(rowPrefabThird, rowsParent);
        }
        else // Outros colocados
        {
            newGo = Instantiate(rowPrefab, rowsParent);
        }

        // Atualizar os textos no prefab
        TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();
        texts[0].text = (item.Position + 1).ToString(); // Posição
        texts[1].text = item.DisplayName;              // Nome
        texts[2].text = item.StatValue.ToString();     // Pontuação

        // Log para depuração
        Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
    }
}

    public void GetLeadboardAroundPlayer() 
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "PlatformScore",
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }

    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
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

            Debug.Log(item.Position + " " + item.DisplayName + " " + item.StatValue);
        }
    }

    void GetAccountCreationDate()
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest
        {
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowCreated = true // Certifique-se de que esta propriedade está habilitada para exibir a data de criação.
            }
        },
        result =>
        {
            if (result.PlayerProfile.Created.HasValue) // Verifica se o valor existe
            {
                DateTime creationDate = result.PlayerProfile.Created.Value; // Obtém o valor
                string formattedDate = creationDate.ToString("dd/MM/yyyy"); // Formata a data para o formato desejado
                Debug.Log("Decolando nos estudos desde " + formattedDate);

                // Atualize o texto da UI, se necessário
                if (creationDateText != null)
                {
                    creationDateText.text = "Decolando nos estudos desde " + formattedDate;
                }
            }
            else
            {
                Debug.LogWarning("Creation date is null.");
            }
        },
        error =>
        {
            Debug.LogError("Error retrieving account creation date: " + error.GenerateErrorReport());
        });
    }

    public void GetPlayerRank()
    {
        // Adiciona um log para verificar se o sistema acredita que o usuário está logado
        Debug.Log("Is the user logged in? " + PlayFabClientAPI.IsClientLoggedIn());

        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            var request = new GetLeaderboardAroundPlayerRequest
            {
                StatisticName = "PlatformScore", // A estatística que você está usando para o ranking
                MaxResultsCount = 1 // Obtendo apenas a posição do usuário logado
            };

            PlayFabClientAPI.GetLeaderboardAroundPlayer(request, UpdateMyRankingDisplay, OnError);
        }
        else
        {
            Debug.LogError("User is not logged in. Cannot retrieve the player rank.");
        }
    }

    void UpdateMyRankingDisplay(GetLeaderboardAroundPlayerResult result)
    {
        if (result.Leaderboard != null && result.Leaderboard.Count > 0)
        {
            var rank = result.Leaderboard[0].Position + 1; // PlayFab leaderboard positions are zero-based.
            rankingText.text = rank.ToString();
            Debug.Log("Your rank is: " + rank);
        }
        else
        {
            Debug.Log("No data received.");
        }
    }

    // No seu primeiro script, onde recebe o nome do PlayFab
    void GetPlayerProfile()
    {
        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {
            ProfileConstraints = new PlayerProfileViewConstraints()
            {
                ShowDisplayName = true
            }
        },
        result => {
            questions.nome = result.PlayerProfile.DisplayName;
            // Salva o nome usando PlayerPrefs
            PlayerPrefs.SetString("PlayerDisplayName", result.PlayerProfile.DisplayName);
            PlayerPrefs.Save();
        },
        error => Debug.LogError(error.GenerateErrorReport()));
    }

    public void logout()
    {
        PlayFabClientAPI.ForgetAllCredentials();
    }

    public void getname()
    {
        GetPlayerProfile();
    }

    // Chamar essa função ao iniciar o jogo ou login
    public void InicializarProgresso(Action onProgressLoaded)
    {
        Debug.Log("Carregando progresso do PlayFab...");
        GetDailyProgress(loadedData =>
        {
            dailyProgressData = loadedData; // Atualiza os dados locais
            Debug.Log("Progresso carregado com sucesso: " + JsonConvert.SerializeObject(dailyProgressData));
            onProgressLoaded?.Invoke();
        });
    }


    // Salvar progresso diário (com sincronização garantida)
    public void SaveDailyProgress(int questionsAnswered)
    {
        string today = DateTime.UtcNow.ToString("yyyy-MM-dd");

        // Certifique-se de carregar os dados antes de atualizá-los
        GetDailyProgress(loadedData =>
        {
            // Atualiza os dados existentes com as respostas de hoje
            dailyProgressData = loadedData;

            if (dailyProgressData.ContainsKey(today))
            {
                dailyProgressData[today] += questionsAnswered;
            }
            else
            {
                dailyProgressData[today] = questionsAnswered;
            }

            // Serializa e envia os dados atualizados para o PlayFab
            var request = new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string>
            {
                { "DailyProgress", JsonConvert.SerializeObject(dailyProgressData) }
            }
            };

            PlayFabClientAPI.UpdateUserData(request, result =>
            {
                Debug.Log("Progresso diário salvo com sucesso.");
            }, error =>
            {
                Debug.LogError("Erro ao salvar progresso diário: " + error.GenerateErrorReport());
            });
        });
    }


    // Obter progresso diário do PlayFab
    public void GetDailyProgress(Action<Dictionary<string, int>> callback)
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), result =>
        {
            Dictionary<string, int> progresso = new Dictionary<string, int>();

            if (result.Data != null && result.Data.TryGetValue("DailyProgress", out var dailyProgressJson))
            {
                Debug.Log($"Dados encontrados no PlayFab: {dailyProgressJson.Value}");
                try
                {
                    progresso = JsonConvert.DeserializeObject<Dictionary<string, int>>(dailyProgressJson.Value);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Erro ao desserializar DailyProgress: {ex.Message}");
                }
            }
            else
            {
                Debug.LogWarning("Nenhum dado de progresso encontrado no PlayFab.");
            }

            callback(progresso); // Retorna o progresso, mesmo que vazio
        }, error =>
        {
            Debug.LogError("Erro ao obter dados do PlayFab: " + error.GenerateErrorReport());
            callback(new Dictionary<string, int>()); // Retorna vazio em caso de erro
        });
    }


    IEnumerator click()
    {
        yield return new WaitForSeconds(0.3f);
        StartCoroutine("click1");
        GetLeaderboard();
    }
    IEnumerator click1()
    {
        yield return new WaitForSeconds(0.3f);
        StartCoroutine("click2");
        GetLeaderboard();
    }

    IEnumerator click2()
    {
        yield return new WaitForSeconds(0.3f);
        GetLeaderboard();
    }

    IEnumerator gettname()
    {
        yield return new WaitForSeconds(1.0f);
        getname();
    }
}


