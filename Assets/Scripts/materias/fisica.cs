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

      public TextMeshProUGUI Cinem�ticacount;
      public TextMeshProUGUI Din�micaIcount;
      public TextMeshProUGUI Din�micaIIcount;
      public TextMeshProUGUI EnergiaeTrabalhocount;
      public TextMeshProUGUI Est�ticacount;
      public TextMeshProUGUI Gravita��ocount;
      public TextMeshProUGUI ImpulsoeQuantidadedeMovimentocount;
      public TextMeshProUGUI Hidrost�ticacount;
      public TextMeshProUGUI Termologiacount;
      public TextMeshProUGUI Termodin�micacount;
      public TextMeshProUGUI TemperaturaeCalorcount;
      public TextMeshProUGUI TemperaturaeCalorIIcount;
      public TextMeshProUGUI Gasescount;
      public TextMeshProUGUI EletricidadeIcount;
      public TextMeshProUGUI EletricidadeIIcount;
      public TextMeshProUGUI EletricidadeIIIcount;
      public TextMeshProUGUI Eletrodin�micacount;
      public TextMeshProUGUI Eletrost�ticacount;
      public TextMeshProUGUI Eletromagnetismocount;
      public TextMeshProUGUI Ac�sticacount;
      public TextMeshProUGUI Ondulat�riaIcount;
      public TextMeshProUGUI Ondulat�riaIIcount;
      public TextMeshProUGUI Ondulat�riaIIIcount;
      public TextMeshProUGUI �pticacount;
      public TextMeshProUGUI F�sicaModernacount;

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
        { "Cinem�tica", Cinem�ticacount },
        { "Din�mica I", Din�micaIcount },
        { "Din�mica II", Din�micaIIcount },
        { "Energia e Trabalho", EnergiaeTrabalhocount },
        { "Est�tica", Est�ticacount },
        { "Gravita��o", Gravita��ocount },
        { "Impulso e Quantidade de Movimento", ImpulsoeQuantidadedeMovimentocount },
        { "Hidrost�tica", Hidrost�ticacount },
        { "Termologia", Termologiacount },
        { "Termodin�mica", Termodin�micacount },
        { "Temperatura e Calor", TemperaturaeCalorcount },
        { "Temperatura e Calor II", TemperaturaeCalorIIcount },
        { "Gases", Gasescount },
        { "Eletricidade I", EletricidadeIcount },
        { "Eletricidade II", EletricidadeIIcount },
        { "Eletricidade III", EletricidadeIIIcount },
        { "Eletrodin�mica", Eletrodin�micacount },
        { "Eletrost�tica", Eletrost�ticacount },
        { "Eletromagnetismo", Eletromagnetismocount },
        { "Ac�stica", Ac�sticacount },
        { "Ondulat�ria I", Ondulat�riaIcount },
        { "Ondulat�ria II", Ondulat�riaIIcount },
        { "Ondulat�ria III", Ondulat�riaIIIcount },
        { "�ptica", �pticacount },
        { "F�sica Moderna", F�sicaModernacount }
    };

        foreach (var subtopic in subtopicTexts.Keys)
        {
            int count = questionsData.Count(q => q.subtopico == subtopic);
            subtopicTexts[subtopic].text = count + " Quest�es";
        }
    }

    private void CountQuestionsByVestibular()
    {
        EnemCountText.text = questionsData.Count(q => q.vestibular == "Enem") + " Quest�es";
        VestibularACountText.text = questionsData.Count(q => q.vestibular == "Vestibular A") + " Quest�es";
        VestibularBCountText.text = questionsData.Count(q => q.vestibular == "Vestibular B") + " Quest�es";
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
            Debug.Log("Voc� est� na primeira pergunta!");
        }
    }

    public void ResetProgress()
    {
        control = 0;
        FilterQuestions();
    }
}

