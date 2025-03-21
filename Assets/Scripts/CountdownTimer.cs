using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_InputField timerInputField;
    public TextMeshProUGUI timerText;
    public TMP_InputField linkedInputField;
    public TextMeshProUGUI linkedText;
    public GameObject targetObject;
    
    public TextMeshProUGUI resultAcertos;
    public TextMeshProUGUI resultErros;
    public TextMeshProUGUI resultTempo;
    public TextMeshProUGUI resultTempoMedio;
    public TextMeshProUGUI resultTaxaAcerto;
    public TextMeshProUGUI resultNota;

    private float remainingTime;
    private bool isCountingDown = false;
    public int questoesRespondidas;
    private int linkedValue;
    private float startTime;
    private float endTime;
    private bool hasEnded = false;

    void Update()
    {
        if (questions.prova)
        {
            questoesRespondidas = questions.errosprova + questions.acertosprova;
            linkedText.text = $"Questões: {questoesRespondidas} / {linkedValue}";

            if (isCountingDown && remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                int hours = Mathf.FloorToInt(remainingTime / 3600);
                int minutes = Mathf.FloorToInt((remainingTime % 3600) / 60);
                int seconds = Mathf.FloorToInt(remainingTime % 60);
                timerText.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
            }
            else if (remainingTime <= 0 && isCountingDown && !hasEnded)
            {
                isCountingDown = false;
                timerText.text = "Tempo: 00:00:00";
                endTime = Time.time;
                CheckEndConditions();
            }

            if (questoesRespondidas >= linkedValue && !hasEnded)
            {
                endTime = Time.time;
                CheckEndConditions();
            }
        }
    }

    public void StartTimer()
    {
        questions.prova = true;
        startTime = Time.time; // Reinicia o tempo inicial
        endTime = 0;
        hasEnded = false;

        questions.errosprova = 0;
        questions.acertosprova = 0;

        remainingTime = 0;
        timerText.text = "00:00:00"; // Atualiza o texto imediatamente na interface

        if (int.TryParse(timerInputField.text, out int minutes))
        {
            remainingTime = minutes * 60;
            isCountingDown = true;
        }
        else
        {
            Debug.LogWarning("Insira um valor numérico válido para o timer.");
        }

        if (int.TryParse(linkedInputField.text, out linkedValue)) { }
        else
        {
            Debug.LogWarning("Insira um valor numérico válido no segundo campo.");
        }

        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

   private void CheckEndConditions()
    {
        if (targetObject != null && !hasEnded)
        {
            hasEnded = true;
            isCountingDown = false;
            float timeElapsed = endTime - startTime;
            
            int acertos = questions.acertosprova;
            int erros = questions.errosprova;
            float tempoMedio = questoesRespondidas > 0 ? timeElapsed / questoesRespondidas : 0;
            float taxaAcerto = linkedValue > 0 ? ((float)acertos / linkedValue) * 100 : 0;
            int nota = Mathf.RoundToInt(taxaAcerto * 10);

            int tempoMedioMin = Mathf.FloorToInt(tempoMedio / 60);
            int tempoMedioSeg = Mathf.FloorToInt(tempoMedio % 60);

            resultAcertos.text = $"{acertos}";
            resultErros.text = $"{erros}";
            resultTempo.text = $"{Mathf.FloorToInt(timeElapsed / 60):D2}:{Mathf.FloorToInt(timeElapsed % 60):D2}";
            resultTempoMedio.text = $"{tempoMedioMin:D2}:{tempoMedioSeg:D2}";
            resultTaxaAcerto.text = $"{taxaAcerto:F0}";
            resultNota.text = $"{nota}";

            targetObject.SetActive(true);
        }
    }
}
