using System.Collections.Generic;

// Classe principal que representa uma prova
[System.Serializable]
public class Exam
{
    public string title; // O título da prova
    public int year; // O ano da prova
    public List<Discipline> disciplines; // Lista de disciplinas da prova
    public List<Language> languages; // Lista de idiomas da prova
}

// Classe que representa uma disciplina em uma prova
[System.Serializable]
public class Discipline
{
    public string label; // Nome da disciplina
    public string value; // Identificador da disciplina
}

// Classe que representa um idioma em uma prova
[System.Serializable]
public class Language
{
    public string label; // Nome do idioma (ex.: "Inglês")
    public string value; // Identificador do idioma (ex.: "ingles")
}

// Classe que representa uma questão
[System.Serializable]
public class Question
{
    public string title; // Título da questão
    public int index; // Índice da questão
    public string discipline; // Disciplina da questão
    public string language; // Idioma da questão
    public int year; // Ano da prova a que pertence
    public string context; // Texto ou contexto da questão
    public List<string> files; // Links para arquivos relacionados à questão
    public string correctAlternative; // Letra da alternativa correta (ex.: "A")
    public string alternativesIntroduction; // Introdução das alternativas
    public List<Alternative> alternatives; // Lista de alternativas da questão
}

// Classe que representa uma alternativa de resposta
[System.Serializable]
public class Alternative
{
    public string letter; // Letra da alternativa (ex.: "A", "B", etc.)
    public string text; // Texto da alternativa
    public string file; // Link para arquivo relacionado à alternativa (se houver)
    public bool isCorrect; // Se a alternativa é correta
}

// Classe para a resposta das questões (em casos de listagem)
[System.Serializable]
public class QuestionsResponse
{
    public List<Question> questions; // Lista de questões retornadas
    public Metadata metadata; // Metadados sobre a consulta
}

// Classe que representa os metadados da consulta
[System.Serializable]
public class Metadata
{
    public int limit; // Número máximo de questões retornadas
    public int offset; // Número inicial das questões retornadas
    public int total; // Total de questões disponíveis
    public bool hasMore; // Indica se há mais questões disponíveis
}
