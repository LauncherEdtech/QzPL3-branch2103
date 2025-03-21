using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using System.Linq;

public class biologia : MonoBehaviour
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

    public TextMeshProUGUI botanicacount;
    public TextMeshProUGUI ecologiacount;
    public TextMeshProUGUI ecologiaIIcount;
    public TextMeshProUGUI ecologiaIIIcount;
    public TextMeshProUGUI ecologiaIVcount;
    public TextMeshProUGUI ecologiaBiologiacount;
    public TextMeshProUGUI fotossintesecount;
    public TextMeshProUGUI biotecnologiaIcount;
    public TextMeshProUGUI biotecnologiaIIcount;
    public TextMeshProUGUI geneticaIcount;
    public TextMeshProUGUI geneticaIIcount;
    public TextMeshProUGUI anatomiaFisiologiacount;
    public TextMeshProUGUI histologiacount;
    public TextMeshProUGUI imunologiacount;
    public TextMeshProUGUI evolucaocount;
    public TextMeshProUGUI medidasDeSaudeIcount;
    public TextMeshProUGUI reproducaoDesenvolvimentoAnimalcount;
    public TextMeshProUGUI taxonomiacount;
    public TextMeshProUGUI citologiaIcount;
    public TextMeshProUGUI citologiaIIcount;
    public TextMeshProUGUI acidoNucleicocount;
    public TextMeshProUGUI bioquimicacount;
    public TextMeshProUGUI aguaESaisMineraiscount;
    public TextMeshProUGUI proteinacount;
    public TextMeshProUGUI respiracaoCelularFermetacaocount;

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
        TextAsset jsonFile = Resources.Load<TextAsset>("BiologiaData");
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
        { "Botanica", botanicacount },
        { "Ecologia", ecologiacount },
        { "Ecologia II", ecologiaIIcount },
        { "Ecologia III", ecologiaIIIcount },
        { "Ecologia IV", ecologiaIVcount },
        { "Ecologia Biologia", ecologiaBiologiacount },
        { "Fotossintese", fotossintesecount },
        { "Biotecnologia I", biotecnologiaIcount },
        { "Biotecnologia II", biotecnologiaIIcount },
        { "Genetica I", geneticaIcount },
        { "Genetica II", geneticaIIcount },
        { "Anatomia-Fisiologia", anatomiaFisiologiacount },
        { "Histologia", histologiacount },
        { "Imunologia", imunologiacount },
        { "Evolução", evolucaocount },
        { "Medidas de Saúde I", medidasDeSaudeIcount },
        { "Reprodução e Desenvolvimento Animal", reproducaoDesenvolvimentoAnimalcount },
        { "Taxonomia", taxonomiacount },
        { "Citologia I", citologiaIcount },
        { "Citologia II", citologiaIIcount },
        { "Acido Nucleico", acidoNucleicocount },
        { "Bioquimica", bioquimicacount },
        { "Agua e Sais Minerais", aguaESaisMineraiscount },
        { "Proteina", proteinacount },
        { "Respiracao Celular e Fermetacao", respiracaoCelularFermetacaocount }
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