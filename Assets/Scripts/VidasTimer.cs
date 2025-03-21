using UnityEngine;
using System;
using TMPro;
using Unity.Notifications.Android;

public class VidasTimer : MonoBehaviour
{
    // Vari�veis para armazenar os hor�rios
    public string horarioVidasZeradas;
    public string horarioCom10Minutos;

    // Refer�ncias dos componentes de UI
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
        // Verifica se o hor�rio j� foi registrado, caso contr�rio, tenta carregar as informa��es salvas
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
        // Verifica se as vidas chegaram a 0 e se o hor�rio ainda n�o foi registrado
        if (questions.vidas <= 0 && !horarioRegistrado)
        {
            // Salva o hor�rio em que as vidas chegaram a 0
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
        // Cria um canal de notifica��o com ID �nico
        var channel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Notifications",
            Description = "Notifications for the game.",
            Importance = Importance.Default,
            EnableVibration = true, // Ativa a vibra��o
            LockScreenVisibility = LockScreenVisibility.Public
        };

        // Registra o canal de notifica��o no Android
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
        Debug.Log("Canal de notifica��o criado.");
    }

    void SalvarHorarioVidasZeradas()
    {
        horarioZerou = false;
        // Registra o hor�rio atual quando as vidas chegam a 0
        DateTime horarioAtual = DateTime.Now;
        horarioVidasZeradas = horarioAtual.ToString("yyyy-MM-dd HH:mm:ss");

        // Registra o hor�rio final, com 10 minutos a mais
        DateTime horarioFinal = horarioAtual.AddMinutes(10);
        horarioCom10Minutos = horarioFinal.ToString("yyyy-MM-dd HH:mm:ss");

        // Salva os hor�rios usando PlayerPrefs
        PlayerPrefs.SetString("HorarioVidasZeradas", horarioVidasZeradas);
        PlayerPrefs.SetString("HorarioCom10Minutos", horarioCom10Minutos);
        PlayerPrefs.Save();

        // Marca que o hor�rio foi registrado para n�o salvar novamente
        horarioRegistrado = true;

        AgendarNotificacao();
        // Exibe no console para verifica��o
        Debug.Log("Hor�rio em que as vidas chegaram a 0: " + horarioVidasZeradas);
        Debug.Log("Hor�rio final com 10 minutos a mais: " + horarioCom10Minutos);
        permissaoNotificacoes.EnviarNotificacaoComDelay();
    }

    void DeletaHorarioVidasZeradas()
    {
        // Remove as chaves salvas no PlayerPrefs
        PlayerPrefs.DeleteKey("HorarioVidasZeradas");
        PlayerPrefs.DeleteKey("HorarioCom10Minutos");
        PlayerPrefs.Save(); // Garante que as altera��es sejam salvas imediatamente

        // Reseta as vari�veis locais
        horarioVidasZeradas = null;
        horarioCom10Minutos = null;
        horarioRegistrado = false;
        horarioZerou = true; // Marca que as vidas n�o est�o mais zeradas

        // Exibe no console para verifica��o
        permissaoNotificacoes.CancelarNotificacao();
        Debug.Log("Os hor�rios salvos foram deletados.");
    }

    void UpdateTimer()
    {
        // Verifica se o hor�rio final (horarioCom10Minutos) foi definido
        if (!string.IsNullOrEmpty(horarioCom10Minutos))
        {
            // Converte o hor�rio final para DateTime
            DateTime horarioFinal = DateTime.Parse(horarioCom10Minutos);

            // Calcula o tempo restante at� o hor�rio final
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
                // Se o tempo terminou, exibe 00:00:00 e pode adicionar a��es
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
            // Converte o hor�rio final para DateTime
            DateTime horarioFinal = DateTime.Parse(horarioCom10Minutos);
            Debug.Log($"Hor�rio Final: {horarioFinal}");  // Adicione o log para verificar o valor de horarioFinal

            // Verifica se o hor�rio final � futuro (evita agendar notifica��es no passado)
            if (horarioFinal > DateTime.Now)
            {
                // Cria a notifica��o
                AndroidNotification notification = new AndroidNotification();
                notification.Title = "Alerta!";
                notification.Text = "Voc� tem 10 minutos restantes.";
                notification.FireTime = horarioFinal; // Define o hor�rio exato para disparar a notifica��o

                // Envia a notifica��o para ser disparada no hor�rio especificado
                AndroidNotificationCenter.SendNotification(notification, "1"); // Passando "1" como identificador �nico para a notifica��o
                Debug.Log($"Notifica��o agendada para: {horarioFinal}");
            }
            else
            {
                Debug.Log("O hor�rio especificado j� passou. N�o ser� poss�vel agendar a notifica��o.");
            }
        }
    }





}
