using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using System.Linq;

public class geografia : MonoBehaviour
{
    public static string aquestion;
    public static string aanswerA;
    public static string aanswerB;
    public static string aanswerC;
    public static string aanswerD;
    public static string aanswerE;
    public static string acorrectAnswer;
    public static string acorrectAnswermessage;
    public static string image;
    public static string materia;
    public static string topico;
    public static string subtopico;
    public static string vestibular;

    public static int acertos;
    public static int erros;

    [System.Serializable]
    public class QuestionData
    {
        public string question;
        public string answerA;
        public string answerB;
        public string answerC;
        public string answerD;
        public string answerE;
        public string correctAnswer;
        public string correctAnswermessage;
        public string image;
        public string materia;
        public string topico;
        public string subtopico;
        public string vestibular;
    }

    private List<QuestionData> questionsData;
    private List<QuestionData> filteredQuestions;
    private Dictionary<string, int> subtopicControls;
    private Dictionary<string, int> vestibularControls;

    public int controle;
    public static int control;
    public static int controlequestion;

    public TextMeshProUGUI agropecuariacount;
    public TextMeshProUGUI chinacount;
    public TextMeshProUGUI capitalismoEGlobalizacaocount;
    public TextMeshProUGUI agrotoxicoscount;
    public TextMeshProUGUI bricscount;
    public TextMeshProUGUI guerraFriacount;
    public TextMeshProUGUI desmatamentoDaAmazoniacount;
    public TextMeshProUGUI extrativismocount;
    public TextMeshProUGUI fontesDeEnergiacount;
    public TextMeshProUGUI modelosDeProducaocount;
    public TextMeshProUGUI novaOrdemMundialcount;
    public TextMeshProUGUI tigresAsiaticoscount;
    public TextMeshProUGUI blocosEconomicoscount;
    public TextMeshProUGUI mercosulcount;
    public TextMeshProUGUI naftacount;
    //public TextMeshProUGUI uniaoEuropeiacount;
    public TextMeshProUGUI criseDosRefugiadoscount;
    public TextMeshProUGUI criseNaVenezuelacount;
    public TextMeshProUGUI demografiacount;
    public TextMeshProUGUI deslizamentoEEnchentescount;
    public TextMeshProUGUI migracaocount;
    public TextMeshProUGUI populacaocount;
    public TextMeshProUGUI populacaoEtniaEModernidadecount;
    public TextMeshProUGUI urbanizacaocount;
    public TextMeshProUGUI centroOestecount;
    public TextMeshProUGUI nordestecount;
    public TextMeshProUGUI nortecount;
    public TextMeshProUGUI sudestecount;
    public TextMeshProUGUI sulcount;
    public TextMeshProUGUI climatologiaDoBrasilcount;
    public TextMeshProUGUI climatologiacount;
    public TextMeshProUGUI elNinocount;
    public TextMeshProUGUI hidrografiaBrasileiracount;
    public TextMeshProUGUI meioAmbientecount;
    public TextMeshProUGUI atmosferacount;
    public TextMeshProUGUI biosferacount;
    public TextMeshProUGUI chuvaAcidacount;
    public TextMeshProUGUI hidrosferacount;
    public TextMeshProUGUI litosferacount;
    public TextMeshProUGUI biogeografiacount;
    public TextMeshProUGUI cartografiacount;
    public TextMeshProUGUI geomorfologiacount;
    public TextMeshProUGUI geomorfologiaDoBrasilcount;
    public TextMeshProUGUI pedologiaSolocount;
    public TextMeshProUGUI erasGeologicascount;
    public TextMeshProUGUI escudosCristalinoscount;

    public TextMeshProUGUI EnemCountText;
    public TextMeshProUGUI VestibularACountText;
    public TextMeshProUGUI VestibularBCountText;

    private string currentSubtopic = "All";
    private string currentVestibular = "All";
    private bool stateChanged = false;

    private void Start()
    {
        LoadQuizFromJson();
        InitializeControls();
        CountQuestionsBySubtopic();
        CountQuestionsByVestibular();
        FilterQuestions();
        DisplayCurrentQuestion();
    }

    void Update()
    {
        if (stateChanged)
        {
            DisplayCurrentQuestion();
            stateChanged = false;
        }

        controle = control;
        controlequestion = filteredQuestions.Count;
    }

    private void LoadQuizFromJson()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("GeografiaData");
        if (jsonFile == null || string.IsNullOrEmpty(jsonFile.text))
        {
            Debug.LogError("Erro ao carregar o arquivo MatematicData.json.");
            return;
        }

        questionsData = JsonConvert.DeserializeObject<List<QuestionData>>(jsonFile.text);
        if (questionsData == null || questionsData.Count == 0)
        {
            Debug.LogError("Nenhuma pergunta foi carregada do JSON.");
        }
    }


    private void InitializeControls()
    {
        subtopicControls = new Dictionary<string, int>();
        vestibularControls = new Dictionary<string, int>();

        foreach (var question in questionsData)
        {
            if (!subtopicControls.ContainsKey(question.subtopico))
            {
                subtopicControls[question.subtopico] = 0;
            }

            if (!vestibularControls.ContainsKey(question.vestibular))
            {
                vestibularControls[question.vestibular] = 0;
            }
        }
    }

    private void DisplayCurrentQuestion()
    {
        if (control < filteredQuestions.Count)
        {
            QuestionData currentQuestion = filteredQuestions[control];

            aquestion = currentQuestion.question;
            aanswerA = currentQuestion.answerA;
            aanswerB = currentQuestion.answerB;
            aanswerC = currentQuestion.answerC;
            aanswerD = currentQuestion.answerD;
            aanswerE = currentQuestion.answerE;
            acorrectAnswer = currentQuestion.correctAnswer;
            acorrectAnswermessage = currentQuestion.correctAnswermessage;
            image = currentQuestion.image;
            materia = currentQuestion.materia;
            topico = currentQuestion.topico;
            subtopico = currentQuestion.subtopico;
            vestibular = currentQuestion.vestibular;
        }
    }


    private void DisplayLastQuestion()
    {
        if (filteredQuestions.Count > 0)
        {
            control = filteredQuestions.Count - 1;
            DisplayCurrentQuestion();
        }
    }

    private void CountQuestionsBySubtopic()
    {
        Dictionary<string, TextMeshProUGUI> subtopicTexts = new Dictionary<string, TextMeshProUGUI>
    {
        { "Agropecuária", agropecuariacount },
        { "China", chinacount },
        { "Capitalismo e Globalização", capitalismoEGlobalizacaocount },
        { "Agrotóxicos", agrotoxicoscount },
        { "BRICS", bricscount },
        { "Guerra Fria", guerraFriacount },
        { "Desmatamento da Amazônia", desmatamentoDaAmazoniacount },
        { "Extrativismo", extrativismocount },
        { "Fontes de Energia", fontesDeEnergiacount },
        { "Modelos de Produção", modelosDeProducaocount },
        { "Nova Ordem Mundial", novaOrdemMundialcount },
        { "Tigres Asiáticos", tigresAsiaticoscount },
        { "Blocos Econômicos", blocosEconomicoscount },
        { "Mercosul", mercosulcount },
        { "Nafta", naftacount },
        //{ "União Europeia", uniaoEuropeiacount },
        { "Crise dos Refugiados", criseDosRefugiadoscount },
        { "Crise na Venezuela", criseNaVenezuelacount },
        { "Demografia", demografiacount },
        { "Deslizamento e Enchentes", deslizamentoEEnchentescount },
        { "Migração", migracaocount },
        { "População", populacaocount },
        { "População: Etnia e Modernidade", populacaoEtniaEModernidadecount },
        { "Urbanização", urbanizacaocount },
        { "Centro-Oeste", centroOestecount },
        { "Nordeste", nordestecount },
        { "Norte", nortecount },
        { "Sudeste", sudestecount },
        { "Sul", sulcount },
        { "Climatologia do Brasil", climatologiaDoBrasilcount },
        { "Climatologia", climatologiacount },
        { "El Niño", elNinocount },
        { "Hidrografia Brasileira", hidrografiaBrasileiracount },
        { "Meio Ambiente", meioAmbientecount },
        { "Atmosfera", atmosferacount },
        { "Biosfera", biosferacount },
        { "Chuva Ácida", chuvaAcidacount },
        { "Hidrosfera", hidrosferacount },
        { "Litosfera", litosferacount },
        { "Biogeografia", biogeografiacount },
        { "Cartografia", cartografiacount },
        { "Geomorfologia", geomorfologiacount },
        { "Geomorfologia do Brasil", geomorfologiaDoBrasilcount },
        { "Pedologia-Solo", pedologiaSolocount },
        { "Eras Geológicas", erasGeologicascount },
        { "Escudos Cristalinos", escudosCristalinoscount }
    };

        foreach (var subtopic in subtopicTexts.Keys)
        {
            int count = questionsData.Count(q => q.subtopico == subtopic);
            subtopicTexts[subtopic].text = count + " Questões";
        }
    }

    private void CountQuestionsByVestibular()
    {
        EnemCountText.text = questionsData.Count(q => q.vestibular == "Enem") + " Questões";
        VestibularACountText.text = questionsData.Count(q => q.vestibular == "Vestibular A") + " Questões";
        VestibularBCountText.text = questionsData.Count(q => q.vestibular == "Vestibular B") + " Questões";
    }

    private void FilterQuestions()
    {
        filteredQuestions = questionsData.FindAll(q =>
            (currentSubtopic == "All" || q.subtopico == currentSubtopic) &&
            (currentVestibular == "All" || q.vestibular == currentVestibular)
        );
        stateChanged = true;
    }

    public void SetSubtopic(string subtopic)
    {
        currentVestibular = "All";
        currentSubtopic = subtopic;
        control = 0;
        FilterQuestions();
    }

    public void SetVestibular(string vestibular)
    {
        currentSubtopic = "All";
        currentVestibular = vestibular;
        control = 0;
        FilterQuestions();
    }

    public void NextQuestion()
    {
        if (control < filteredQuestions.Count - 1)
        {
            control++;
            stateChanged = true;
        }
        else
        {
            Debug.Log("No more questions in this subtopic!");
            questions.acabou = true;
        }
    }

    public void PreviousQuestion()
    {
        if (control > 0)
        {
            control--;
            stateChanged = true;
        }
        else
        {
            Debug.Log("Você está na primeira pergunta!");
        }
    }

    public void ResetProgress()
    {
        control = 0;
        FilterQuestions();
    }
}
