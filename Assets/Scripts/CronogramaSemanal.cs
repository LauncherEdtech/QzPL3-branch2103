using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Tarefa
{
    public string nome;
    public string descricao;
}

public class CronogramaSemanal : MonoBehaviour
{
    public GameObject itemDeTarefaPrefab;
    public Transform conteinerDeTarefas;
    public TMP_InputField nomeTarefaInput;
    public TMP_InputField descricaoTarefaInput;

    private DateTime dataAtual;
    private List<Tarefa> tarefasDaSemana = new List<Tarefa>();

    private void Start()
    {
        dataAtual = DateTime.Now;
        CarregarTarefasSalvas(); // Carregue as tarefas salvas ao iniciar o aplicativo
        AtualizarInterface();
    }

    public void AvancarSemana()
    {
        dataAtual = dataAtual.AddDays(7);
        AtualizarInterface();
    }

    public void RetrocederSemana()
    {
        dataAtual = dataAtual.AddDays(-7);
        AtualizarInterface();
    }

    public void AdicionarTarefa()
    {
        Tarefa novaTarefa = new Tarefa
        {
            nome = nomeTarefaInput.text,
            descricao = descricaoTarefaInput.text
        };

        tarefasDaSemana.Add(novaTarefa);

        // Limpa os campos de entrada após adicionar a tarefa
        nomeTarefaInput.text = "";
        descricaoTarefaInput.text = "";

        AtualizarInterface();

        SalvarTarefas(); // Salve as tarefas após adicionar uma nova tarefa
    }

    private void AtualizarInterface()
    {
        LimparListaDeTarefas();

        foreach (Tarefa tarefa in tarefasDaSemana)
        {
            GameObject itemTarefa = Instantiate(itemDeTarefaPrefab, conteinerDeTarefas);
            itemTarefa.transform.Find("Nome").GetComponent<TextMeshProUGUI>().text = tarefa.nome;
            itemTarefa.transform.Find("Descricao").GetComponent<TextMeshProUGUI>().text = tarefa.descricao;
        }
    }

    private void LimparListaDeTarefas()
    {
        foreach (Transform child in conteinerDeTarefas)
        {
            Destroy(child.gameObject);
        }
    }

    private void SalvarTarefas()
    {
        // Converter a lista de tarefas em JSON
        string tarefasJson = JsonUtility.ToJson(tarefasDaSemana);

        // Salvar os dados usando PlayerPrefs (ou outro método de armazenamento)
        PlayerPrefs.SetString("TarefasDaSemana", tarefasJson);
        PlayerPrefs.Save();
    }

    private void CarregarTarefasSalvas()
    {
        if (PlayerPrefs.HasKey("TarefasDaSemana"))
        {
            // Carregar os dados salvos
            string tarefasJson = PlayerPrefs.GetString("TarefasDaSemana");
            tarefasDaSemana = JsonUtility.FromJson<List<Tarefa>>(tarefasJson);
        }
    }
}
