using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    public string gameVersion = "1.0";
    public string region = "sa"; // Região do servidor (sa para América do Sul)

    void Start()
    {
        ConnectToPhoton();
    }

    public void ConnectToPhoton()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Conectando ao Photon...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado ao servidor Photon!");
        // Aqui você pode habilitar botões para criar/entrar em salas
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Desconectado do Photon: " + cause.ToString());
    }

    // Métodos para criar e entrar em salas
    public void CreateRoom(string roomName)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10; // Ajuste conforme necessário
        PhotonNetwork.CreateRoom(roomName, roomOptions);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    // Callbacks de sala
    public override void OnJoinedRoom()
    {
        Debug.Log("Entrou na sala: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Falha ao criar sala: " + message);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Falha ao entrar na sala: " + message);
    }
}