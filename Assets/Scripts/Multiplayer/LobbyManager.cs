using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro; // Usando TMP
using UnityEngine.UI;
using System.Collections.Generic;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField createRoomInput;
    [SerializeField] private Transform roomListContent;
    [SerializeField] private GameObject roomListItemPrefab;
    [SerializeField] private Transform playerListContent;
    [SerializeField] private GameObject playerListItemPrefab;
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject lobbyPanel;
    [SerializeField] private GameObject roomPanel;
    [SerializeField] private TMP_Text roomNameText;

    private Dictionary<string, GameObject> roomListItems = new Dictionary<string, GameObject>();
    private Dictionary<int, GameObject> playerListItems = new Dictionary<int, GameObject>();

    void Start()
    {
        // Certifique-se de estar conectado ao Photon antes de usar
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinLobby();
        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Entrou no lobby!");
        // Limpar listas anteriores
        roomListItems.Clear();

        // Ativar painel de lobby
        lobbyPanel.SetActive(true);
        roomPanel.SetActive(false);
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(createRoomInput.text))
            return;

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        PhotonNetwork.CreateRoom(createRoomInput.text, roomOptions);
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        // Atualiza a lista de salas disponíveis
        foreach (Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }

        roomListItems.Clear();

        foreach (RoomInfo room in roomList)
        {
            if (room.RemovedFromList)
                continue;

            GameObject roomItem = Instantiate(roomListItemPrefab, roomListContent);
            roomItem.transform.Find("RoomNameText").GetComponent<TMP_Text>().text = room.Name;
            roomItem.transform.Find("PlayerCountText").GetComponent<TMP_Text>().text =
                room.PlayerCount + " / " + room.MaxPlayers;

            roomItem.GetComponent<Button>().onClick.AddListener(() => JoinRoom(room.Name));

            roomListItems[room.Name] = roomItem;
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        // Limpar lista de jogadores e atualizar UI
        foreach (Transform trans in playerListContent)
        {
            Destroy(trans.gameObject);
        }

        playerListItems.Clear();

        // Mostrar painel de sala
        roomPanel.SetActive(true);
        lobbyPanel.SetActive(false);

        // Atualizar nome da sala
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        // Adicionar todos os jogadores à lista
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            AddPlayerToList(player);
        }

        // Mostrar botão de iniciar apenas para o host
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    private void AddPlayerToList(Player player)
    {
        GameObject playerItem = Instantiate(playerListItemPrefab, playerListContent);
        playerItem.transform.Find("PlayerNameText").GetComponent<TMP_Text>().text = player.NickName;

        playerListItems[player.ActorNumber] = playerItem;
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        // Voltar para o painel de lobby
        roomPanel.SetActive(false);
        lobbyPanel.SetActive(true);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerToList(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Destroy(playerListItems[otherPlayer.ActorNumber]);
        playerListItems.Remove(otherPlayer.ActorNumber);

        // Atualize o botão de iniciar se houver mudança de host
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        // Atualize o botão de iniciar se houver mudança de host
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            // Inicie o jogo (isso carregará a mesma cena para todos os jogadores)
            PhotonNetwork.LoadLevel("GameScene");
        }
    }
}