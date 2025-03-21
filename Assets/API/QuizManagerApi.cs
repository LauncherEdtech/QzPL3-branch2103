using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using Photon.Pun.Demo.Asteroids;
using PlayFab.EconomyModels;
using Photon.Realtime;
using System.Linq;

public class QuizManagerApi : MonoBehaviourPunCallbacks, IPunObservable // Corrigido
{
    private const string BaseUrl = "https://api.enem.dev/v1";

    public QuizUI quizUI;
    public GameObject content;
    public GameObject ContentbotaoA;
    public GameObject ContentbotaoB;
    public GameObject ContentbotaoC;
    public GameObject ContentbotaoD;
    public GameObject ContentbotaoE;
    public GameObject ContentQuiz;
    private List<Question> currentQuestions;
    private int currentQuestionIndex = 0;

    private static string ROOM_SEED_KEY = "QuizSeed";
    private static string ROOM_YEAR_KEY = "QuizYear";
    [SerializeField] private int[] availableYears = { 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023 };

    private int currentSeed = 0;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Sorteia ano e seed apenas uma vez ao criar a sala
            if (!PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(ROOM_YEAR_KEY))
            {
                SetRandomYearAndSeed();
            }
        }
        StartCoroutine(InitializeQuiz());
    }

    private IEnumerator InitializeQuiz()
    {
        // Espera as propriedades estarem disponíveis
        yield return new WaitUntil(() =>
            PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(ROOM_YEAR_KEY) &&
            PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(ROOM_SEED_KEY));

        StartCoroutine(GetQuestions());
    }

    private void SetRandomYearAndSeed()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        // Sorteia um ano aleatório
        int randomYearIndex = Random.Range(0, availableYears.Length);
        int selectedYear = availableYears[randomYearIndex];

        // Gera nova seed
        int newSeed = Random.Range(0, int.MaxValue);

        // Atualiza propriedades
        Hashtable props = new Hashtable();
        props[ROOM_YEAR_KEY] = selectedYear;
        props[ROOM_SEED_KEY] = newSeed;
        PhotonNetwork.CurrentRoom.SetCustomProperties(props);
    }

    public void RestartQuiz()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        SetRandomYearAndSeed();
    }

    public override void OnRoomPropertiesUpdate(Hashtable propertiesThatChanged)
    {
        if (propertiesThatChanged.ContainsKey(ROOM_YEAR_KEY))
        {
            Debug.Log($"Novo ano sorteado: {(int)propertiesThatChanged[ROOM_YEAR_KEY]}");
            StopAllCoroutines();
            StartCoroutine(GetQuestions());
        }
    }

    public int GetCurrentYear()
    {
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(ROOM_YEAR_KEY))
        {
            return (int)PhotonNetwork.CurrentRoom.CustomProperties[ROOM_YEAR_KEY];
        }
        return -1;
    }

    public IEnumerator GetQuestions() // Remova o parâmetro year
    {
        // Obtenha o ano das propriedades da sala
        int currentYear = (int)PhotonNetwork.CurrentRoom.CustomProperties[ROOM_YEAR_KEY];
        string url = $"{BaseUrl}/exams/{currentYear}/questions";

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string json = request.downloadHandler.text;
                var response = JsonConvert.DeserializeObject<QuestionsResponse>(json);

                // Use a seed da sala para embaralhar
                int seed = (int)PhotonNetwork.CurrentRoom.CustomProperties[ROOM_SEED_KEY];
                currentQuestions = ShuffleQuestions(response.questions, seed);

                DisplayCurrentQuestion();
                StartCoroutine(ReorganizarContent());
            }
            else
            {
                Debug.LogError($"Erro ao buscar questões: {request.error}");

                // Tenta novo ano se for Master Client
                if (PhotonNetwork.IsMasterClient)
                {
                    SetRandomYearAndSeed();
                }
            }
        }
    }

    private List<Question> ShuffleQuestions(List<Question> questions, int seed)
    {
        // Embaralha usando o Fisher-Yates com seed
        System.Random rng = new System.Random(seed);
        List<Question> shuffled = questions.ToList();

        int n = shuffled.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Question value = shuffled[k];
            shuffled[k] = shuffled[n];
            shuffled[n] = value;
        }

        return shuffled;
    }

    // Adicione este callback para novos jogadores
    public override void OnJoinedRoom()
    {
        // Verifica ambas as propriedades
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(ROOM_SEED_KEY) &&
            PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(ROOM_YEAR_KEY))
        {
            currentSeed = (int)PhotonNetwork.CurrentRoom.CustomProperties[ROOM_SEED_KEY];
            StartCoroutine(InitializeQuiz()); // Usar o inicializador correto
        }
    }

    private void DisplayCurrentQuestion()
    {
        if (currentQuestions == null || currentQuestions.Count == 0)
        {
            Debug.LogWarning("Nenhuma questão disponível.");
            return;
        }

        var question = currentQuestions[currentQuestionIndex];
        string[] alternatives = new string[question.alternatives.Count];
        for (int i = 0; i < question.alternatives.Count; i++)
        {
            alternatives[i] = question.alternatives[i].text;
        }

        // Desativa o Content antes da atualização
        content.SetActive(false);

        if (question.files != null && question.files.Count > 0)
        {
            StartCoroutine(LoadImage(question.files[0], (texture) =>
            {
                quizUI.UpdateQuestionUI(question.title, question.context, alternatives, texture);
                StartCoroutine(ReorganizarContent());
            }));
        }
        else
        {
            quizUI.UpdateQuestionUI(question.title, question.context, alternatives);
            StartCoroutine(ReorganizarContent());
        }
    }

    private IEnumerator ReorganizarContent()
    {
        content.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        content.SetActive(true);

        yield return new WaitForSeconds(0.01f);
        content.SetActive(false);
        yield return new WaitForSeconds(0.01f);
        content.SetActive(true);
        ContentbotaoA.SetActive(true);
        ContentbotaoB.SetActive(true);
        ContentbotaoC.SetActive(true);
        ContentbotaoD.SetActive(true);
        ContentbotaoE.SetActive(true);
    }

    private IEnumerator LoadImage(string url, System.Action<Texture2D> callback)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                callback?.Invoke(texture);
            }
            else
            {
                Debug.LogError($"Erro ao carregar imagem: {request.error}");
                callback?.Invoke(null);
            }
        }
    }

    public void OnAnswerSelected(int index)
    {
        var question = currentQuestions[currentQuestionIndex];
        bool isCorrect = question.alternatives[index].isCorrect;

        if (isCorrect)
        {
            // +1 ponto para o jogador
            PhotonNetwork.LocalPlayer.AddScore(1);
        }
        else
        {
            // Remove 1 vida do jogador
            int currentLives = (int)PhotonNetwork.LocalPlayer.CustomProperties[AsteroidsGame.PLAYER_LIVES];
            PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable {
            {AsteroidsGame.PLAYER_LIVES, Mathf.Max(currentLives +  1, 0)}
        });
        }
        /*
        currentQuestionIndex++;
        if (currentQuestionIndex < currentQuestions.Count)
        {
            DisplayCurrentQuestion();
            StartCoroutine(ReorganizarContent());
        }
        else
        {
            Debug.Log("Quiz concluído!");
        }
        */
        ContentbotaoA.SetActive(false);
        ContentbotaoB.SetActive(false);
        ContentbotaoC.SetActive(false);
        ContentbotaoD.SetActive(false);
        ContentbotaoE.SetActive(false);
    }


    // Novo método para verificar os totais
    private void CheckAllPlayersTotal()
    {
        if (!PhotonNetwork.IsMasterClient) return;

        int? referenceTotal = null;
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            int score = player.GetScore();
            int lives = (player.CustomProperties.ContainsKey(AsteroidsGame.PLAYER_LIVES))
                ? (int)player.CustomProperties[AsteroidsGame.PLAYER_LIVES]
                : AsteroidsGame.PLAYER_MAX_LIVES;

            int playerTotal = score + lives;

            if (referenceTotal == null)
            {
                referenceTotal = playerTotal;
            }
            else if (playerTotal != referenceTotal)
            {
                return; // Totais diferentes, não avança
            }
        }

        // Todos os jogadores têm o mesmo total
        base.photonView.RPC("AdvanceQuestionRPC", RpcTarget.All);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // Deixe vazio se não precisa sincronizar dados manualmente
    }

    [PunRPC]
    private void AdvanceQuestionRPC()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < currentQuestions.Count)
        {
            DisplayCurrentQuestion();
            StartCoroutine(ReorganizarContent());
        }
        else
        {
            Debug.Log("Quiz concluído!");
            content.SetActive(false);
            ContentQuiz.SetActive(false);

        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        CheckAllPlayersTotal();
    }

    public void NextQuestion()
    {
        if (currentQuestionIndex < currentQuestions.Count - 1)
        {
            currentQuestionIndex++;
            DisplayCurrentQuestion();
            StartCoroutine(ReorganizarContent());
        }
        else
        {
            Debug.Log("Você já está na última questão.");
        }
    }

    public void PreviousQuestion()
    {
        if (currentQuestionIndex > 0)
        {
            currentQuestionIndex--;
            DisplayCurrentQuestion();
            StartCoroutine(ReorganizarContent());
        }
        else
        {
            Debug.Log("Você já está na primeira questão.");
        }
    }


    [System.Serializable]
    public class QuestionsResponse
    {
        public List<Question> questions;
    }
}
