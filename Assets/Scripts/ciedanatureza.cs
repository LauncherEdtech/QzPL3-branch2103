using UnityEngine;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;

public class ciedanatureza : MonoBehaviour
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
    }

    private List<QuestionData> questionsData;
    public static int control;
    public int controle;

    public static int controlequestion;

    private void Start()
    {
        LoadQuizFromJson();
        DisplayCurrentQuestion();
    }

    void Update()
    {
        if (questions.display == true)
        {
            DisplayCurrentQuestion();
        }
        controle = control;
        controlequestion = questionsData.Count;
    }

    private void LoadQuizFromJson()
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("CiedaNaturezaData");
        questionsData = JsonConvert.DeserializeObject<List<QuestionData>>(jsonFile.text);
    }

    private void DisplayCurrentQuestion()
    {
        if (control < questionsData.Count)
        {
            QuestionData currentQuestion = questionsData[control];

            aquestion = currentQuestion.question;
            aanswerA = currentQuestion.answerA;
            aanswerB = currentQuestion.answerB;
            aanswerC = currentQuestion.answerC;
            aanswerD = currentQuestion.answerD;
            aanswerE = currentQuestion.answerE;
            acorrectAnswer = currentQuestion.correctAnswer;
            acorrectAnswermessage = currentQuestion.correctAnswermessage;
            image = currentQuestion.image;

        }
        else
        {
            Debug.Log("Quiz ended!");
            // Aqui você pode exibir a pontuação final ou fazer outras ações.
        }
    }

    public void NextQuestion()
    {
        DisplayCurrentQuestion();
    }
}
