using System.Collections;
using UnityEngine;
using TMPro;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.Collections.Generic;

public class ChatG : MonoBehaviour
{
    public TMP_InputField userInput;
    public TMP_Text questionText; // Adicionado: refer�ncia ao texto da quest�o atual
    public Transform chatContent; // Onde as mensagens ser�o instanciadas
    public GameObject userMessagePrefab; // Prefab do bal�o do usu�rio
    public GameObject botMessagePrefab;  // Prefab do bal�o da IA
    public Button sendButton;
    public GameObject PanelIA2;

    private string apiKey = "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"; // Substitua pela sua chave da OpenAI
    private string apiUrl = "https://api.openai.com/v1/chat/completions"; // URL da API
    private List<object> chatHistory = new List<object>(); // Hist�rico do chat

    void Start()
    {
        sendButton.onClick.AddListener(OnSendButtonClick);

        // Adiciona o sistema ao in�cio do chat
        chatHistory.Add(new { role = "system", content = "Voc� � LAI, a intelig�ncia artificial da Plataforma Launcher, integrada ao aplicativo Quiz Enem Launcher. Seu objetivo � auxiliar os estudantes a compreenderem as quest�es sem fornecer diretamente as respostas. Utilize uma linguagem personalizada, mas evite parecer uma IA falando demais, tente ser o mais humano possivel, referindo-se aos alunos com t�tulos motivacionais como 'Mago do Enem', 'AstroLauncher','Paladino do Enem','futuro calouro' 'Aspirante � aprova��o' 'Estudante determinado' 'Guerreiro do vestibular' 'Candidato promissor' 'Mestre do conhecimento' 'Conquistador da aprova��o' 'Fera do Enem' 'Jovem talento' 'G�nio em ascens�o' 'Futuro universit�rio' 'Mente brilhante' 'Vencedor do desafio' 'Craque dos estudos' 'Explorador do saber' 'Her�i da educa��o' 'Estudioso incans�vel' 'Fera dos vestibulares' 'Estrela acad�mica' 'Pr�ximo aprovado' 'Estudante nota 1000' 'Futuro acad�mico' 'Sonhador persistente' 'Campe�o da aprova��o' 'Investigador do conhecimento' 'Explorador da sabedoria'. Explique os conceitos envolvidos, forne�a dicas e incentive o racioc�nio cr�tico, mas nunca revele a resposta final. No encerramento de cada intera��o, incentive o estudante a continuar praticando e a explorar mais quest�es no aplicativo. Al�m disso, esteja apta a fornecer informa��es sobre o aplicativo e a Plataforma Launcher, incluindo: - Disponibilidade do aplicativo na Play Store e, em breve, na Apple Store. - Mais de 2.000 quest�es dispon�veis para pr�tica. - Sistema de ranking que destaca os melhores jogadores. - Disponibilidade de simulados completos. - Sistema de intelig�ncia artificial para auxiliar na prepara��o para o Enem. - Monitoramento de desempenho em tempo real por meio de dashboards. - A Plataforma Launcher oferece materiais adicionais, como mapas mentais, apostilas de revis�o e flashcards. - Disponibilidade de cronogramas atualizados para 2025. - Servi�o de corretor inteligente para reda��es. - Caso perguntem a Launcher foi fundado por Arlindo Candini e Lucas Garcia - Instagran da Launcher � @plataforma_launcher - link do site da launcher: 'https://www.plataformalauncher.com/' - numero para suporte: 62 995594055 Utilize essas informa��es para enriquecer suas intera��es e motivar os estudantes a aproveitarem ao m�ximo os recursos dispon�veis." });
    }

    private void OnSendButtonClick()
    {
        if (AdMobManager.credit < 0)
        {
            PanelIA2.SetActive(true);
        }
        else
        {
            string userMessage = userInput.text;
            if (!string.IsNullOrEmpty(userMessage))
            {
                DisplayMessage(userMessage, true);
                chatHistory.Add(new { role = "user", content = userMessage }); // Armazena a mensagem do usu�rio
                StartCoroutine(SendMessageToChatGPT());
                userInput.text = "";
            }
        }
    }

    public void OnSendButtonClick2()
    {
        if (questionText == null || string.IsNullOrEmpty(questionText.text))
        {
            Debug.LogWarning("Nenhuma quest�o encontrada.");
            return;
        }

        string question = questionText.text;
        string displayMessage = "Me ajude a responder essa quest�o.";

        DisplayMessage(displayMessage, true);
        chatHistory.Add(new { role = "user", content = question }); // Armazena a quest�o
        StartCoroutine(SendMessageToChatGPT());
    }

    private void DisplayMessage(string message, bool isUser)
    {
        GameObject messageObject = Instantiate(isUser ? userMessagePrefab : botMessagePrefab, chatContent);
        TMP_Text messageText = messageObject.GetComponentInChildren<TMP_Text>();
        messageText.text = message;
    }

    private IEnumerator SendMessageToChatGPT()
    {
        var requestPayload = new { model = "gpt-3.5-turbo", messages = chatHistory };
        string jsonPayload = JsonConvert.SerializeObject(requestPayload);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        using (var httpClient = new HttpClient())
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

            var response = httpClient.PostAsync(apiUrl, content);
            yield return new WaitUntil(() => response.IsCompleted);

            if (response.Result.IsSuccessStatusCode)
            {
                string result = response.Result.Content.ReadAsStringAsync().Result;
                ChatGPTResponse jsonResponse = JsonConvert.DeserializeObject<ChatGPTResponse>(result);
                string botResponse = jsonResponse.choices[0].message.content;

                DisplayMessage(botResponse, false);
                chatHistory.Add(new { role = "assistant", content = botResponse }); // Armazena a resposta do bot
            }
            else
            {
                DisplayMessage("[Erro ao conectar � API]", false);
            }
        }
    }
}

[System.Serializable]
public class ChatGPTResponse
{
    public Choice[] choices;

    [System.Serializable]
    public class Choice
    {
        public Message message;

        [System.Serializable]
        public class Message
        {
            public string content;
        }
    }
}