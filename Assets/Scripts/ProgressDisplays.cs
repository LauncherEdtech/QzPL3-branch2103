using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressDisplays : MonoBehaviour
{
    // public TextMeshProUGUI totalQuestionsText;
    public Image progressBar;
    //public int total;          // Total de questões disponíveis

    void Update()
    {
        UpdateProgressDisplay();
    }

    void UpdateProgressDisplay()
    {
        // Atualiza o texto com o total de questões respondidas e o total disponível
        // totalQuestionsText.text = $"Total de questões: {radial.acertos + radial1.erros} / {total}";

        // Calcula a proporção de progresso
        float progress = (radial.acertos + radial1.erros) / (float)radial.total;

        // Atualiza a barra de progresso
        progressBar.fillAmount = progress;
    }
}
