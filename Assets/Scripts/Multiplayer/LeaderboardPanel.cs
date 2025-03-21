using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

namespace Photon.Pun.Demo.Asteroids
{
    public class LeaderboardPanel : MonoBehaviourPunCallbacks
    {
        public GameObject LeaderboardEntryPrefab;
        private Dictionary<int, GameObject> playerListEntries;

        #region UNITY

        public void Awake()
        {
            playerListEntries = new Dictionary<int, GameObject>();

            // Cria entradas para todos os jogadores e ordena
            foreach (Player p in PhotonNetwork.PlayerList.OrderByDescending(p => p.GetScore()))
            {
                CreatePlayerEntry(p);
            }
            SortEntries();
        }

        #endregion

        #region PUN CALLBACKS

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            CreatePlayerEntry(newPlayer);
            SortEntries();
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            if (playerListEntries.TryGetValue(otherPlayer.ActorNumber, out GameObject entry))
            {
                Destroy(entry);
                playerListEntries.Remove(otherPlayer.ActorNumber);
            }
            SortEntries();
        }

        public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
        {
            SortEntries(); // Atualiza sempre que propriedades mudam
        }

        #endregion

        private void CreatePlayerEntry(Player player)
        {
            if (playerListEntries.ContainsKey(player.ActorNumber)) return;

            GameObject entry = Instantiate(LeaderboardEntryPrefab);
            entry.transform.SetParent(gameObject.transform);
            entry.transform.localScale = Vector3.one;
            entry.GetComponent<Text>().color = AsteroidsGame.GetColor(player.GetPlayerNumber());

            playerListEntries.Add(player.ActorNumber, entry);
        }

        private void SortEntries()
        {
            // Ordena jogadores por score (decrescente) e ActorNumber (crescente)
            List<Player> sortedPlayers = PhotonNetwork.PlayerList
                .OrderByDescending(p => p.GetScore())
                .ThenBy(p => p.ActorNumber)
                .ToList();

            // Atualiza textos e posições
            for (int i = 0; i < sortedPlayers.Count; i++)
            {
                Player p = sortedPlayers[i];
                int position = i + 1;

                if (playerListEntries.TryGetValue(p.ActorNumber, out GameObject entry))
                {
                    // Formata: "1° lugar: Nome - Acertos: X"
                    entry.GetComponent<Text>().text = $"{position}° lugar: {p.NickName} - Acertos: {p.GetScore()}";
                    entry.transform.SetSiblingIndex(i);
                }
            }
        }
    }
}