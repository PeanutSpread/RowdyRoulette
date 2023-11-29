using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class NetworkManagement : MonoBehaviourPunCallbacks {
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
        Debug.Log ("Joined Room");
        LoadCardTableScene ();
    }

    void LoadCardTableScene () {
        PhotonNetwork.LoadLevel ("CardTableScene");
    }
}