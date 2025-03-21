using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using System.Linq;

public class historia : MonoBehaviour
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
    public static int control;
    private Dictionary<string, int> subtopicControls;
    private Dictionary<string, int> vestibularControls;
    public int controle;
    public static int controlequestion;


    public TextMeshProUGUI CapitaniasHereditáriascount           ;
    public TextMeshProUGUI EconomiaColonialcount                 ;
    public TextMeshProUGUI SociedadenoBrasilColôniacount         ;
    public TextMeshProUGUI ReligiaoColoniacount                  ;
    public TextMeshProUGUI Escravidaocount                       ;
    public TextMeshProUGUI PrimeiroReinadocount                  ;
    public TextMeshProUGUI PeríodoRegencialcount                 ;
    public TextMeshProUGUI SegundoReinadocount                   ;
    public TextMeshProUGUI EraVargascount                        ;
    public TextMeshProUGUI RegimeMilitarcount                    ;
    public TextMeshProUGUI RepublicaVelhacount                   ;
    public TextMeshProUGUI NovaRepúblicacount                    ;
    public TextMeshProUGUI PréHistóriacount                      ;
    public TextMeshProUGUI AntiguidadeClassicacount              ;
    public TextMeshProUGUI AntiguidadeOrientalcount              ;
    public TextMeshProUGUI Antiguidadegeralcount                 ;
    public TextMeshProUGUI Absolutismocount                      ;
    public TextMeshProUGUI AntigoRegimecount                     ;
    public TextMeshProUGUI expansãomarítimaemercantilismocount   ;
    public TextMeshProUGUI formacaodoestadocount                 ;
    public TextMeshProUGUI iluminismocount                       ;
    public TextMeshProUGUI reformasreligiosascount               ;
    public TextMeshProUGUI renascimentocount                     ;
    public TextMeshProUGUI revolucaoinglesacount                 ;
    public TextMeshProUGUI revolucaofrancesacount                ;
    public TextMeshProUGUI revolucaoindustrialcount              ;
    public TextMeshProUGUI sistemasemodelosdeproducaocount       ;
    public TextMeshProUGUI comunadePariscount                    ;
    public TextMeshProUGUI colonialismoeimperialismocount        ;
    public TextMeshProUGUI primeiraguerramundialcount            ;
    public TextMeshProUGUI segundaguerramundialcount             ;
    public TextMeshProUGUI regimestotalitarioscount              ;
    public TextMeshProUGUI crisede1929count                      ;
    public TextMeshProUGUI apartheidnaAfricadoSulcount           ;
    public TextMeshProUGUI descolonizacaoafroasiaticacount       ;
    public TextMeshProUGUI guerrafriacount                       ;
    public TextMeshProUGUI sociedadeedireitoshumanoscount        ;
    public TextMeshProUGUI americalatinacount;

    public TextMeshProUGUI EnemCountText;
    public TextMeshProUGUI VestibularACountText;
    public TextMeshProUGUI VestibularBCountText;

    private List<QuestionData> filteredQuestions;
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
        TextAsset jsonFile = Resources.Load<TextAsset>("HistoriaData");
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
        { "Capitanias Hereditárias", CapitaniasHereditáriascount },
        { "Economia Colonial", EconomiaColonialcount },
        { "Sociedadeno Brasil Colônia", SociedadenoBrasilColôniacount },
        { "Religiao Colonial", ReligiaoColoniacount },
        { "Escravidao", Escravidaocount },
        { "Primeiro Reinado", PrimeiroReinadocount },
        { "Período Regencial", PeríodoRegencialcount },
        { "Segundo Reinado", SegundoReinadocount },
        { "Era Vargas", EraVargascount },
        { "Regime Militar", RegimeMilitarcount },
        { "Republica Velha", RepublicaVelhacount },
        { "Nova República", NovaRepúblicacount },
        { "Pré História", PréHistóriacount },
        { "Antiguidade Classica", AntiguidadeClassicacount },
        { "Antiguidade Oriental", AntiguidadeOrientalcount },
        { "Antiguidade Geral", Antiguidadegeralcount },
        { "Absolutismo", Absolutismocount },
        { "Antigo Regime", AntigoRegimecount },
        { "expansão marítima e mercantilismo", expansãomarítimaemercantilismocount },
        { "formacao do estado", formacaodoestadocount },
        { "iluminismo", iluminismocount },
        { "reformas religiosas", reformasreligiosascount },
        { "renascimento", renascimentocount },
        { "revolucao inglesa", revolucaoinglesacount },
        { "revolucao francesa", revolucaofrancesacount },
        { "revolucao industrial", revolucaoindustrialcount },
        { "sistemas e modelos de producao", sistemasemodelosdeproducaocount },
        { "comunade Paris", comunadePariscount },
        { "colonialismo e imperialismo", colonialismoeimperialismocount },
        { "primeira guerra mundial", primeiraguerramundialcount },
        { "segunda guerra mundial", segundaguerramundialcount },
        { "regimes totalitarios", regimestotalitarioscount },
        { "crise de 1929", crisede1929count },
        { "apartheid na África do Sul", apartheidnaAfricadoSulcount },
        { "descolonizacao afroasiatica", descolonizacaoafroasiaticacount },
        { "guerra fria", guerrafriacount },
        { "sociedade e direitos humanos", sociedadeedireitoshumanoscount },
        { "america latina", americalatinacount }
    };

        Dictionary<string, int> subtopicCounts = subtopicTexts.Keys.ToDictionary(subtopic => subtopic, subtopic => 0);

        foreach (var question in questionsData)
        {
            if (subtopicCounts.ContainsKey(question.subtopico))
            {
                subtopicCounts[question.subtopico]++;
            }
        }

        foreach (var subtopic in subtopicCounts.Keys)
        {
            subtopicTexts[subtopic].text = subtopicCounts[subtopic] + " Questões";
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
