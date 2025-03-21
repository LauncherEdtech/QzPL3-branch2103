using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;
using System.Linq;

public class ProgressGrafBarra : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public RectTransform graphContainer;
    public List<int> progresso;
    public List<string> dias;

    private float offsetX = 10f;
    private float offsetY = 10f;

    void Start()
    {
        dropdown.onValueChanged.AddListener(OnDropdownChanged);
        AtualizarGraficoBarras(7);
    }

   public void OnDropdownChanged(int value)
{
    switch (value)
    {
        case 0:
                AtualizarGraficoBarras(7); // Gráfico de linhas
                break;
        case 1:
            AtualizarGraficoBarras(14); // Gráfico de barras
            break;
        case 2:
            AtualizarGraficoBarras(30); // Gráfico de barras para 30 dias
            break;
    }
}

    public void AtualizarGraficoBarras(int diasIntervalo)
    {
        dias = ObterUltimosDias(diasIntervalo);

        ObterProgresso(diasIntervalo, progresso =>
        {
            Debug.Log("Dados carregados para o gráfico de barras: " + string.Join(", ", progresso));

            foreach (Transform child in graphContainer)
            {
                Destroy(child.gameObject);
            }

            if (progresso.Count == 0)
            {
                Debug.LogWarning("Nenhum dado de progresso encontrado.");
                return;
            }

            int maxProgresso = Mathf.Max(30, progresso.Max());
            if (maxProgresso == 0)
            {
                maxProgresso = 1; // Evita divisão por zero
            }

            float graphWidth = graphContainer.rect.width;
            float graphHeight = graphContainer.rect.height;

            float spacing = graphWidth / dias.Count;
            float barWidth = spacing * 0.8f; // Define a largura das barras (80% do espaço disponível)

            for (int i = 0; i < dias.Count; i++)
            {
                float x = offsetX + i * spacing + barWidth / 2;
                float y = (progresso[i] / (float)maxProgresso) * graphHeight;

                Debug.Log($"Dia: {dias[i]}, Progresso: {progresso[i]}, MaxProgresso: {maxProgresso}, Posição: ({x}, {y})");

                CriarBarra(new Vector2(x, y), barWidth, y);

                if (dias.Count == 30 && i % 2 != 0)
                {
                    continue;
                }

                AdicionarRotuloHorizontal(DateTime.Parse(dias[i]).ToString("dd/MM"), x);
            }

            // Gera rótulos verticais e linhas horizontais
            for (int j = 0; j <= maxProgresso; j += 5)
            {
                float y = (j / (float)maxProgresso) * graphHeight;
                AdicionarRotuloVertical(j.ToString(), y);
                CriarLinhaHorizontal(y);
            }
        });
    }

    private void CriarBarra(Vector2 position, float width, float height)
    {
        GameObject barra = new GameObject("Barra", typeof(Image));
        barra.transform.SetParent(graphContainer, false);

        RectTransform rectTransform = barra.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(0.5f, 0);

        rectTransform.anchoredPosition = new Vector2(position.x, 0); // Base da barra no eixo Y
        rectTransform.sizeDelta = new Vector2(width, height); // Define largura e altura da barra

        barra.GetComponent<Image>().color = new Color(0.3f, 0.6f, 1.0f, 1.0f); // Cor da barra
    }



    public void AtualizarGrafico(int diasIntervalo)
    {
        dias = ObterUltimosDias(diasIntervalo);

        ObterProgresso(diasIntervalo, progresso =>
        {
            Debug.Log("Dados carregados para o gráfico: " + string.Join(", ", progresso));

            foreach (Transform child in graphContainer)
            {
                Destroy(child.gameObject);
            }

            if (progresso.Count == 0)
            {
                Debug.LogWarning("Nenhum dado de progresso encontrado.");
                return;
            }

            int maxProgresso = Mathf.Max(30, progresso.Max());
            if (maxProgresso == 0)
            {
                maxProgresso = 1; // Evita divisão por zero
            }

            float graphWidth = graphContainer.rect.width;
            float graphHeight = graphContainer.rect.height;

            float spacing = graphWidth / (dias.Count - 1);
            Vector2 previousPoint = Vector2.zero;

            // Gera rótulos verticais e linhas horizontais
            // Gera rótulos verticais e linhas horizontais
            for (int j = 0; j <= maxProgresso; j += 5)
            {
                float y = (j / (float)maxProgresso) * graphHeight; // Corrigido para considerar o tamanho total do gráfico
                AdicionarRotuloVertical(j.ToString(), y); // Adiciona o número vertical
                CriarLinhaHorizontal(y); // Adiciona linha horizontal
            }

            // Gera pontos e linhas do gráfico
            for (int i = 0; i < dias.Count; i++)
            {
                float x = offsetX + i * spacing;
                float y = (progresso[i] / (float)maxProgresso) * graphHeight; // Altura proporcional ao progresso

                Debug.Log($"Dia: {dias[i]}, Progresso: {progresso[i]}, MaxProgresso: {maxProgresso}, Posição: ({x}, {y})");

                Vector2 currentPoint = new Vector2(x, y);
                CriarPonto(currentPoint);

                if (i > 0)
                {
                    CriarLinha(previousPoint, currentPoint);
                }

                previousPoint = currentPoint;

                if (dias.Count == 30 && i % 2 != 0)
                {
                    continue;
                }

                AdicionarRotuloHorizontal(DateTime.Parse(dias[i]).ToString("dd/MM"), x);
            }

        });
    }


    private void CriarLinhaHorizontal(float y)
    {
        GameObject linha = new GameObject("LinhaHorizontal", typeof(Image));
        linha.transform.SetParent(graphContainer, false);

        RectTransform rectTransform = linha.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        rectTransform.anchoredPosition = new Vector2(graphContainer.rect.width / 2, y); // Posição horizontal
        rectTransform.sizeDelta = new Vector2(graphContainer.rect.width, 1); // Largura da linha

        linha.GetComponent<Image>().color = Color.gray; // Cor da linha
    }


    private List<string> ObterUltimosDias(int diasIntervalo)
    {
        List<string> dias = new List<string>();
        for (int i = 0; i < diasIntervalo; i++)
        {
            dias.Add(DateTime.Now.AddDays(-i).ToString("yyyy-MM-dd")); // Ajustar para o formato compatível
        }
        dias.Reverse();
        Debug.Log("Dias gerados: " + string.Join(", ", dias));
        return dias;
    }


    private void ObterProgresso(int diasIntervalo, Action<List<int>> callback)
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), result =>
        {
            progresso = new List<int>();
            Dictionary<string, int> dailyProgress = new Dictionary<string, int>();

            if (result.Data != null && result.Data.ContainsKey("DailyProgress"))
            {
                dailyProgress = JsonConvert.DeserializeObject<Dictionary<string, int>>(result.Data["DailyProgress"].Value);
                Debug.Log("Dados de progresso bruto: " + result.Data["DailyProgress"].Value);
            }

            List<string> diasOrdenados = ObterUltimosDias(diasIntervalo);
            foreach (string dia in diasOrdenados)
            {
                if (dailyProgress.ContainsKey(dia))
                {
                    Debug.Log($"Progresso encontrado para {dia}: {dailyProgress[dia]}");
                    progresso.Add(dailyProgress[dia]);
                }
                else
                {
                    Debug.LogWarning($"Nenhum progresso encontrado para {dia}. Adicionando 0.");
                    progresso.Add(0);
                }
            }

            Debug.Log("Progresso organizado: " + string.Join(", ", progresso));
            callback(progresso);
        },
        error =>
        {
            Debug.LogError("Erro ao obter progresso diário: " + error.GenerateErrorReport());
            callback(new List<int>());
        });
    }


    private void CriarPonto(Vector2 position)
    {
        GameObject ponto = new GameObject("Ponto", typeof(Image));
        ponto.transform.SetParent(graphContainer, false);

        RectTransform rectTransform = ponto.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);
        rectTransform.anchoredPosition = position;
        rectTransform.sizeDelta = new Vector2(10, 10);

        Color azulClaro = new Color(0.5f, 0.7f, 1.0f, 1.0f);
        ponto.GetComponent<Image>().color = azulClaro;
    }

    private void CriarLinha(Vector2 pontoA, Vector2 pontoB)
    {
        if (pontoA == pontoB)
        {
            Debug.LogWarning("Pontos A e B são iguais. Linha não será criada.");
            return;
        }

        GameObject linha = new GameObject("Linha", typeof(Image));
        linha.transform.SetParent(graphContainer, false);

        RectTransform rectTransform = linha.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(0.5f, 0.5f);

        // Calcula direção e distância
        Vector2 direction = pontoB - pontoA;
        float distance = direction.magnitude;

        if (distance <= Mathf.Epsilon)
        {
            Debug.LogWarning("Distância entre os pontos é muito pequena. Linha não será criada.");
            return;
        }

        // Configura tamanho e posição
        rectTransform.sizeDelta = new Vector2(distance, 2f); // Linha com altura de 2
        rectTransform.anchoredPosition = pontoA + direction / 2;

        // Calcula ângulo de rotação
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica rotação
        rectTransform.localEulerAngles = new Vector3(0, 0, angle);

        // Define cor da linha
        Color azulClaro = new Color(0.5f, 0.7f, 1.0f, 1.0f);
        linha.GetComponent<Image>().color = azulClaro;

        Debug.Log($"Linha criada de ({pontoA.x}, {pontoA.y}) para ({pontoB.x}, {pontoB.y}) com ângulo {angle} graus.");
    }


    private void AdicionarRotuloHorizontal(string texto, float x)
    {
        GameObject rotulo = new GameObject("RotuloHorizontal", typeof(TextMeshProUGUI));
        rotulo.transform.SetParent(graphContainer, false);

        RectTransform rectTransform = rotulo.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(0.5f, 1f);
        rectTransform.anchoredPosition = new Vector2(x, -10);

        // Aplica a rotação ao rótulo (40 graus no eixo Z)
        rectTransform.localEulerAngles = new Vector3(0, 0, 40);

        TextMeshProUGUI text = rotulo.GetComponent<TextMeshProUGUI>();
        text.text = texto;
        text.fontSize = 14;
        text.alignment = TextAlignmentOptions.Center;
    }

    private void AdicionarRotuloVertical(string texto, float y)
    {
        GameObject rotulo = new GameObject("RotuloVertical", typeof(TextMeshProUGUI));
        rotulo.transform.SetParent(graphContainer, false);

        RectTransform rectTransform = rotulo.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.pivot = new Vector2(1f, 0.5f); // Pivô alinhado à direita
        rectTransform.anchoredPosition = new Vector2(-10, y); // Posição à esquerda do gráfico

        TextMeshProUGUI text = rotulo.GetComponent<TextMeshProUGUI>();
        text.text = texto;
        text.fontSize = 14;
        text.alignment = TextAlignmentOptions.Right; // Alinha texto à direita
    }


}