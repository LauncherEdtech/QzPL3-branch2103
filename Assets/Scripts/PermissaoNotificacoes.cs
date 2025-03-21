using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;

public class PermissaoNotificacoes : MonoBehaviour
{
    private int notificationId; // Vari�vel para armazenar o ID da notifica��o

    void Awake()
    {
        // Configura��es para notifica��es
        var channel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Notifications",
            Importance = Importance.Default,
            Description = "General notifications",
        };

        // Registra o canal de notifica��es
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    // Enviar uma notifica��o em tempo real
    public void EnviarNotificacao(string titulo, string mensagem)
    {
        var notification = new AndroidNotification()
        {
            Title = titulo,
            Text = mensagem,
            FireTime = System.DateTime.Now.AddSeconds(1), // Envia imediatamente
        };

        notificationId = AndroidNotificationCenter.SendNotification(notification, "default_channel");
        Debug.Log("Notifica��o enviada com ID: " + notificationId);
    }

    // Enviar uma notifica��o ap�s 30 segundos, mesmo com o app fechado
    public void EnviarNotificacaoComDelay()
    {
        var notification = new AndroidNotification()
        {
            Title = "Lembrete",
            Text = "Est� na hora de voltar para o jogo!",
            FireTime = System.DateTime.Now.AddSeconds(15), // 30 segundos ap�s a chamada
        };

        notificationId = AndroidNotificationCenter.SendNotification(notification, "default_channel");
        Debug.Log("Notifica��o programada com ID: " + notificationId);
    }

    // Cancelar a notifica��o agendada
    public void CancelarNotificacao()
    {
        if (notificationId != 0)
        {
            AndroidNotificationCenter.CancelNotification(notificationId);
            Debug.Log("Notifica��o cancelada com ID: " + notificationId);
        }
        else
        {
            Debug.Log("Nenhuma notifica��o agendada para cancelar.");
        }
    }
}
