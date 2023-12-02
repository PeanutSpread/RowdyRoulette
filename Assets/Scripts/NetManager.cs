using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using System.Linq;

public class NetManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public List<Transform> spawnPoints;
    public Deck deck;
    public GameObject inputSim;

    private GameObject ownedPlayer;


    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("joining");
        PhotonNetwork.JoinOrCreateRoom("test", null, null);
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;

        int id = players.Length - 1; // Assign the player count as the ID
        Player player = new Player($"Player{id}");

        Debug.Log($"{id} joined");

        GameObject _player = PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[id].position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();
        _player.GetComponent<PlayerController>().player = player;

        inputSim.SetActive(true);

        ownedPlayer = _player;
    }

    public void DeckPull()
    {
        deck.Pull(ownedPlayer.GetComponent<PlayerController>());
    }
}
