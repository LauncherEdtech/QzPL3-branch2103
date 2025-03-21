using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using System.Linq;

public class filosofia : MonoBehaviour
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

    public TextMeshProUGUI filosofiaPoliticacount;
    public TextMeshProUGUI teoriaDoConhecimentocount;
    public TextMeshProUGUI metafisicacount;
    public TextMeshProUGUI filosofiaDaCienciacount;
    public TextMeshProUGUI aristotelescount;
    public TextMeshProUGUI helenismocount;
    public TextMeshProUGUI plataocount;
    public TextMeshProUGUI preSocraticoscount;
    public TextMeshProUGUI socratescount;
    public TextMeshProUGUI sofistascount;
    public TextMeshProUGUI escolasticacount;
    public TextMeshProUGUI patristicacount;
    public TextMeshProUGUI filosofiaModernacount;
    public TextMeshProUGUI racionalismocount;
    public TextMeshProUGUI empirismocount;
    public TextMeshProUGUI reneDescartescount;
    public TextMeshProUGUI tomasHobbescount;
    public TextMeshProUGUI kantcount;
    public TextMeshProUGUI filosofoscount;
    public TextMeshProUGUI contemporaneacount;

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
        TextAsset jsonFile = Resources.Load<TextAsset>("FilosofiaData");
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
        { "Filosofia Política", filosofiaPoliticacount },
        { "Teoria do Conhecimento", teoriaDoConhecimentocount },
        { "Metafísica", metafisicacount },
        { "Filosofia da Ciência", filosofiaDaCienciacount },
        { "Aristóteles", aristotelescount },
        { "Helenismo", helenismocount },
        { "Platão", plataocount },
        { "Pré-Socráticos", preSocraticoscount },
        { "Sócrates", socratescount },
        { "Sofistas", sofistascount },
        { "Escolástica", escolasticacount },
        { "Patrística", patristicacount },
        { "Filosofia Moderna", filosofiaModernacount },
        { "Racionalismo", racionalismocount },
        { "Empirismo", empirismocount },
        { "René Descartes", reneDescartescount },
        { "Thomas Hobbes", tomasHobbescount },
        { "Kant", kantcount },
        { "Filósofos", filosofoscount },
        { "Contemporânea", contemporaneacount }
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