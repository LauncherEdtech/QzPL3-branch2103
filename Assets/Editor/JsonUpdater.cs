using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEditor;
using UnityEngine;

public class JsonUpdater : EditorWindow
{
    private string filePath = "Assets/Resources/IdiomasData.txt"; // Caminho padrão do JSON

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
        public string vestibular; // Novo campo
    }

    [MenuItem("Tools/Update JSON")]
    public static void ShowWindow()
    {
        GetWindow<JsonUpdater>("JSON Updater");
    }

    private void OnGUI()
    {
        GUILayout.Label("Atualizar JSON", EditorStyles.boldLabel);
        filePath = EditorGUILayout.TextField("Caminho do JSON", filePath);

        if (GUILayout.Button("Atualizar JSON"))
        {
            UpdateJsonFile();
        }
    }

    private void UpdateJsonFile()
    {
        if (!File.Exists(filePath))
        {
            Debug.LogError("Arquivo JSON não encontrado no caminho especificado: " + filePath);
            return;
        }

        // Ler o arquivo JSON
        string json = File.ReadAllText(filePath);

        // Deserializar a lista de questões
        List<QuestionData> questionsData = JsonConvert.DeserializeObject<List<QuestionData>>(json);

        // Atualizar o campo 'vestibular' para questões que não o possuem
        foreach (var question in questionsData)
        {
            if (string.IsNullOrEmpty(question.vestibular))
            {
                question.vestibular = "Enem";
            }
        }

        // Serializar de volta para o JSON
        string updatedJson = JsonConvert.SerializeObject(questionsData, Formatting.Indented);

        // Salvar o arquivo atualizado
        File.WriteAllText(filePath, updatedJson);

        Debug.Log("Arquivo JSON atualizado com sucesso!");
    }
}
