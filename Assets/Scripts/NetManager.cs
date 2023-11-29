using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using System.Linq;

public class NetManager : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public List<Transform> spawnPoints;

    public Deck deck;

    private GameObject ownerPlayer; 

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

        Debug.Log("joined");

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

        Debug.Log(players.Length + " TEST");
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoints[players.Length].position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer();

        ownerPlayer = _player;
    }

    public void DeckPull() 
    {
        deck.Pull(ownerPlayer.GetComponent<PlayerController>());
    }
}