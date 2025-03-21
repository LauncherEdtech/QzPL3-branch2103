using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Unity.Notifications.Android;

public class PermissaoNotificacoes : MonoBehaviour
{
    private int notificationId; // Variável para armazenar o ID da notificação

    void Awake()
    {
        // Configurações para notificações
        var channel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Notifications",
            Importance = Importance.Default,
            Description = "General notifications",
        };

        // Registra o canal de notificações
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    // Enviar uma notificação em tempo real
    public void EnviarNotificacao(string titulo, string mensagem)
    {
        var notification = new AndroidNotification()
        {
            Title = titulo,
            Text = mensagem,
            FireTime = System.DateTime.Now.AddSeconds(1), // Envia imediatamente
        };

        notificationId = AndroidNotificationCenter.SendNotification(notification, "default_channel");
        Debug.Log("Notificação enviada com ID: " + notificationId);
    }

    // Enviar uma notificação após 30 segundos, mesmo com o app fechado
    public void EnviarNotificacaoComDelay()
    {
        var notification = new AndroidNotification()
        {
            Title = "Lembrete",
            Text = "Está na hora de voltar para o jogo!",
            FireTime = System.DateTime.Now.AddSeconds(15), // 30 segundos após a chamada
        };

        notificationId = AndroidNotificationCenter.SendNotification(notification, "default_channel");
        Debug.Log("Notificação programada com ID: " + notificationId);
    }

    // Cancelar a notificação agendada
    public void CancelarNotificacao()
    {
        if (notificationId != 0)
        {
            AndroidNotificationCenter.CancelNotification(notificationId);
            Debug.Log("Notificação cancelada com ID: " + notificationId);
        }
        else
        {
            Debug.Log("Nenhuma notificação agendada para cancelar.");
        }
    }
}
