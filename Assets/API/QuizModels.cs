using System.Collections.Generic;

// Classe principal que representa uma prova
[System.Serializable]
public class Exam
{
    public string title; // O t�tulo da prova
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
    public string label; // Nome do idioma (ex.: "Ingl�s")
    public string value; // Identificador do idioma (ex.: "ingles")
}

// Classe que representa uma quest�o
[System.Serializable]
public class Question
{
    public string title; // T�tulo da quest�o
    public int index; // �ndice da quest�o
    public string discipline; // Disciplina da quest�o
    public string language; // Idioma da quest�o
    public int year; // Ano da prova a que pertence
    public string context; // Texto ou contexto da quest�o
    public List<string> files; // Links para arquivos relacionados � quest�o
    public string correctAlternative; // Letra da alternativa correta (ex.: "A")
    public string alternativesIntroduction; // Introdu��o das alternativas
    public List<Alternative> alternatives; // Lista de alternativas da quest�o
}

// Classe que representa uma alternativa de resposta
[System.Serializable]
public class Alternative
{
    public string letter; // Letra da alternativa (ex.: "A", "B", etc.)
    public string text; // Texto da alternativa
    public string file; // Link para arquivo relacionado � alternativa (se houver)
    public bool isCorrect; // Se a alternativa � correta
}

// Classe para a resposta das quest�es (em casos de listagem)
[System.Serializable]
public class QuestionsResponse
{
    public List<Question> questions; // Lista de quest�es retornadas
    public Metadata metadata; // Metadados sobre a consulta
}

// Classe que representa os metadados da consulta
[System.Serializable]
public class Metadata
{
    public int limit; // N�mero m�ximo de quest�es retornadas
    public int offset; // N�mero inicial das quest�es retornadas
    public int total; // Total de quest�es dispon�veis
    public bool hasMore; // Indica se h� mais quest�es dispon�veis
}
