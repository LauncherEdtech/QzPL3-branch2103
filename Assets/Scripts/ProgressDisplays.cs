using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ProgressDisplays : MonoBehaviour
{
    // public TextMeshProUGUI totalQuestionsText;
    public Image progressBar;
    //public int total;          // Total de quest�es dispon�veis

    void Update()
    {
        UpdateProgressDisplay();
    }

    void UpdateProgressDisplay()
    {
        // Atualiza o texto com o total de quest�es respondidas e o total dispon�vel
        // totalQuestionsText.text = $"Total de quest�es: {radial.acertos + radial1.erros} / {total}";

        // Calcula a propor��o de progresso
        float progress = (radial.acertos + radial1.erros) / (float)radial.total;

        // Atualiza a barra de progresso
        progressBar.fillAmount = progress;
    }
}
