using System;
using System.Collections.Generic;
using UnityEngine;

public static class ProgressoDiarioManager
{
    private static Dictionary<string, int> progressoDiario = new Dictionary<string, int>();

    public static void AdicionarProgresso(int progresso)
    {
        string dataAtual = DateTime.Now.ToString("dd/MM/yyyy");
        if (progressoDiario.ContainsKey(dataAtual))
        {
            progressoDiario[dataAtual] += progresso;
        }
        else
        {
            progressoDiario[dataAtual] = progresso;
        }
    }

    public static Dictionary<string, int> GetProgressoDiario()
    {
        return progressoDiario;
    }

    public static void SetProgressoDiario(Dictionary<string, int> novoProgresso)
    {
        progressoDiario = novoProgresso ?? new Dictionary<string, int>();
    }
}
