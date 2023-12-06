using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon;
using Photon.Pun;
using UnityEngine;

public class NetManager : MonoBehaviourPunCallbacks {
    public GameObject playerPrefab;
    public Transform mrtkTransform;
    public List<Transform> spawnPoints;
    public Deck deck;

    private GameObject ownedPlayer;

    // Start is called before the first frame update
    void Start () {

        PhotonNetwork.ConnectUsingSettings ();
    }

    public override void OnConnectedToMaster () {
        base.OnConnectedToMaster ();
        Debug.Log ("Connected to Master");
        PhotonNetwork.JoinLobby ();
    }

    public override void OnJoinedLobby () {
        base.OnJoinedLobby ();
        Debug.Log ("Joining lobby");
        PhotonNetwork.JoinOrCreateRoom ("test2", null, null);
    }

    public override void OnJoinedRoom () {
        base.OnJoinedRoom ();

        Photon.Realtime.Player[] players = PhotonNetwork.PlayerList;

        int id = players.Length - 1; // Assign the player count as the ID
        Player player = new Player ($"Player{id}");

        Debug.Log ($"{id} joined");

        GameObject _player = null; // Declare _player outside the if-else block

        if (spawnPoints.Count > 0) {
            int spawnIndex = id % spawnPoints.Count; // Use modulus to wrap around if needed

            _player = PhotonNetwork.Instantiate (playerPrefab.name, spawnPoints[spawnIndex].position, Quaternion.Euler(0, 180, 0));
            mrtkTransform.transform.SetParent(_player.transform);
            mrtkTransform.transform.localPosition = Vector3.zero;

            Debug.Log (_player.GetComponent<PlayerSetup> () == null);
            //_player.GetComponent<PlayerSetup> ().IsLocalPlayer ();
            _player.GetComponent<PlayerController> ().player = player;
        } else {
            Debug.LogError ("No spawn points available!");
            // Handle the situation where there are no spawn points (log an error, show a message, etc.)
        }

        ownedPlayer = _player;

        // Additional logic to check if all players are in the room
        if (players.Length == 2) {
            // All players are in the room, perform any additional logic here
            Debug.Log ("All players are in the same room!");
        }
    }

    public void DeckPull () {
        deck.Pull (ownedPlayer.GetComponent<PlayerController> ());
    }
}