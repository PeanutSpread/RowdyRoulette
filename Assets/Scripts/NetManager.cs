using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetManager : MonoBehaviourPunCallbacks {
    public GameObject player;
    public Transform spawnPoint;
    void Start () {
        ConnectToPhoton ();
    }

    void ConnectToPhoton () {
        PhotonNetwork.ConnectUsingSettings ();
    }

    public override void OnConnectedToMaster () {
        Debug.Log ("Connected to Photon Master Server");
        JoinRoom ();
    }

    void JoinRoom () {
        PhotonNetwork.JoinOrCreateRoom ("YourRoomName", new Photon.Realtime.RoomOptions (), TypedLobby.Default);
    }

    public override void OnJoinedRoom () {
        base.OnJoinedRoom ();

        GameObject _player = PhotonNetwork.Instantiate (player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup> ().IsLocalPlayer ();
    }

    void LoadCardTableScene () {
        PhotonNetwork.LoadLevel ("CardTableScene");
    }
}