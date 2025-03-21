using UnityEngine;
using System;
using TMPro;
using Unity.Notifications.Android;

public class VidasTimer : MonoBehaviour
{
    // Variáveis para armazenar os horários
    public string horarioVidasZeradas;
    public string horarioCom10Minutos;

    // Referências dos componentes de UI
    public TMP_Text timerPanel;
    public GameObject painelvida;
    public TMP_Text timerTop;
    public GameObject textoTop;

    public bool horarioRegistrado = false;
    public bool horarioZerou = false;
    public PermissaoNotificacoes permissaoNotificacoes;
    void Start()
    {
        CreateNotificationChannel();
        // Verifica se o horário já foi registrado, caso contrário, tenta carregar as informações salvas
        if (PlayerPrefs.HasKey("HorarioVidasZeradas"))
        {
            horarioVidasZeradas = PlayerPrefs.GetString("HorarioVidasZeradas");
            horarioCom10Minutos = PlayerPrefs.GetString("HorarioCom10Minutos");
            horarioRegistrado = true;
        }
    }

    void Update()
    {
        UpdateTimer();
        // Verifica se as vidas chegaram a 0 e se o horário ainda não foi registrado
        if (questions.vidas <= 0 && !horarioRegistrado)
        {
            // Salva o horário em que as vidas chegaram a 0
            SalvarHorarioVidasZeradas();
        }

        if (questions.vidas > 0 && !horarioZerou)
        {
           
            DeletaHorarioVidasZeradas();
        }

        // Ativa ou desativa os objetos de UI com base nas vidas
        if (questions.vidas <= 0)
        {
            textoTop.SetActive(true);
            painelvida.SetActive(true);
        }
        else
        {
            textoTop.SetActive(false);
            painelvida.SetActive(false);
        }
    }

    void CreateNotificationChannel()
    {
        // Cria um canal de notificação com ID único
        var channel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Notifications",
            Description = "Notifications for the game.",
            Importance = Importance.Default,
            EnableVibration = true, // Ativa a vibração
            LockScreenVisibility = LockScreenVisibility.Public
        };

        // Registra o canal de notificação no Android
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        Debug.Log("Canal de notificação criado.");
    }

    void SalvarHorarioVidasZeradas()
    {
        horarioZerou = false;
        // Registra o horário atual quando as vidas chegam a 0
        DateTime horarioAtual = DateTime.Now;
        horarioVidasZeradas = horarioAtual.ToString("yyyy-MM-dd HH:mm:ss");

        // Registra o horário final, com 10 minutos a mais
        DateTime horarioFinal = horarioAtual.AddMinutes(10);
        horarioCom10Minutos = horarioFinal.ToString("yyyy-MM-dd HH:mm:ss");

        // Salva os horários usando PlayerPrefs
        PlayerPrefs.SetString("HorarioVidasZeradas", horarioVidasZeradas);
        PlayerPrefs.SetString("HorarioCom10Minutos", horarioCom10Minutos);
        PlayerPrefs.Save();

        // Marca que o horário foi registrado para não salvar novamente
        horarioRegistrado = true;

        AgendarNotificacao();
        // Exibe no console para verificação
        Debug.Log("Horário em que as vidas chegaram a 0: " + horarioVidasZeradas);
        Debug.Log("Horário final com 10 minutos a mais: " + horarioCom10Minutos);
        permissaoNotificacoes.EnviarNotificacaoComDelay();
    }

    void DeletaHorarioVidasZeradas()
    {
        // Remove as chaves salvas no PlayerPrefs
        PlayerPrefs.DeleteKey("HorarioVidasZeradas");
        PlayerPrefs.DeleteKey("HorarioCom10Minutos");
        PlayerPrefs.Save(); // Garante que as alterações sejam salvas imediatamente

        // Reseta as variáveis locais
        horarioVidasZeradas = null;
        horarioCom10Minutos = null;
        horarioRegistrado = false;
        horarioZerou = true; // Marca que as vidas não estão mais zeradas

        // Exibe no console para verificação
        permissaoNotificacoes.CancelarNotificacao();
        Debug.Log("Os horários salvos foram deletados.");
    }

    void UpdateTimer()
    {
        // Verifica se o horário final (horarioCom10Minutos) foi definido
        if (!string.IsNullOrEmpty(horarioCom10Minutos))
        {
            // Converte o horário final para DateTime
            DateTime horarioFinal = DateTime.Parse(horarioCom10Minutos);

            // Calcula o tempo restante até o horário final
            TimeSpan tempoRestante = horarioFinal - DateTime.Now;

            // Se o tempo restante for maior que zero, exibe o tempo formatado
            if (tempoRestante.TotalSeconds > 0)
            {
                timerPanel.text = string.Format("{0:D2}:{1:D2}",
                     tempoRestante.Minutes, tempoRestante.Seconds);
                timerTop.text = string.Format("{0:D2}:{1:D2}",
                     tempoRestante.Minutes, tempoRestante.Seconds);
            }
            else
            {
                // Se o tempo terminou, exibe 00:00:00 e pode adicionar ações
                timerTop.text = "00:00:00";
                questions.vidas = 10;
                questions.salvar = true;
            }
        }
    }

    void AgendarNotificacao()
    {
        if (!string.IsNullOrEmpty(horarioCom10Minutos))
        {
            // Converte o horário final para DateTime
            DateTime horarioFinal = DateTime.Parse(horarioCom10Minutos);
            Debug.Log($"Horário Final: {horarioFinal}");  // Adicione o log para verificar o valor de horarioFinal

            // Verifica se o horário final é futuro (evita agendar notificações no passado)
            if (horarioFinal > DateTime.Now)
            {
                // Cria a notificação
                AndroidNotification notification = new AndroidNotification();
                notification.Title = "Alerta!";
                notification.Text = "Você tem 10 minutos restantes.";
                notification.FireTime = horarioFinal; // Define o horário exato para disparar a notificação

                // Envia a notificação para ser disparada no horário especificado
                AndroidNotificationCenter.SendNotification(notification, "1"); // Passando "1" como identificador único para a notificação
                Debug.Log($"Notificação agendada para: {horarioFinal}");
            }
            else
            {
                Debug.Log("O horário especificado já passou. Não será possível agendar a notificação.");
            }
        }
    }





}
