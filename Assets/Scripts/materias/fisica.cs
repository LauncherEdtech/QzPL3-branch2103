using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using System.Linq;

public class fisica : MonoBehaviour
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

    public static int control;
    public int controle;
    public static int controlequestion;

      public TextMeshProUGUI Cinemáticacount;
      public TextMeshProUGUI DinâmicaIcount;
      public TextMeshProUGUI DinâmicaIIcount;
      public TextMeshProUGUI EnergiaeTrabalhocount;
      public TextMeshProUGUI Estáticacount;
      public TextMeshProUGUI Gravitaçãocount;
      public TextMeshProUGUI ImpulsoeQuantidadedeMovimentocount;
      public TextMeshProUGUI Hidrostáticacount;
      public TextMeshProUGUI Termologiacount;
      public TextMeshProUGUI Termodinâmicacount;
      public TextMeshProUGUI TemperaturaeCalorcount;
      public TextMeshProUGUI TemperaturaeCalorIIcount;
      public TextMeshProUGUI Gasescount;
      public TextMeshProUGUI EletricidadeIcount;
      public TextMeshProUGUI EletricidadeIIcount;
      public TextMeshProUGUI EletricidadeIIIcount;
      public TextMeshProUGUI Eletrodinâmicacount;
      public TextMeshProUGUI Eletrostáticacount;
      public TextMeshProUGUI Eletromagnetismocount;
      public TextMeshProUGUI Acústicacount;
      public TextMeshProUGUI OndulatóriaIcount;
      public TextMeshProUGUI OndulatóriaIIcount;
      public TextMeshProUGUI OndulatóriaIIIcount;
      public TextMeshProUGUI Ópticacount;
      public TextMeshProUGUI FísicaModernacount;

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
        TextAsset jsonFile = Resources.Load<TextAsset>("FisicaData");
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
        { "Cinemática", Cinemáticacount },
        { "Dinâmica I", DinâmicaIcount },
        { "Dinâmica II", DinâmicaIIcount },
        { "Energia e Trabalho", EnergiaeTrabalhocount },
        { "Estática", Estáticacount },
        { "Gravitação", Gravitaçãocount },
        { "Impulso e Quantidade de Movimento", ImpulsoeQuantidadedeMovimentocount },
        { "Hidrostática", Hidrostáticacount },
        { "Termologia", Termologiacount },
        { "Termodinâmica", Termodinâmicacount },
        { "Temperatura e Calor", TemperaturaeCalorcount },
        { "Temperatura e Calor II", TemperaturaeCalorIIcount },
        { "Gases", Gasescount },
        { "Eletricidade I", EletricidadeIcount },
        { "Eletricidade II", EletricidadeIIcount },
        { "Eletricidade III", EletricidadeIIIcount },
        { "Eletrodinâmica", Eletrodinâmicacount },
        { "Eletrostática", Eletrostáticacount },
        { "Eletromagnetismo", Eletromagnetismocount },
        { "Acústica", Acústicacount },
        { "Ondulatória I", OndulatóriaIcount },
        { "Ondulatória II", OndulatóriaIIcount },
        { "Ondulatória III", OndulatóriaIIIcount },
        { "Óptica", Ópticacount },
        { "Física Moderna", FísicaModernacount }
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

