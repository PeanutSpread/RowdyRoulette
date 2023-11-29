using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectToSceneConnection : MonoBehaviourPunCallbacks {
    void Start () {
        ConnectToRoom ();
    }

    void ConnectToRoom () {
        PhotonNetwork.ConnectUsingSettings ();
    }

    public override void OnConnectedToMaster () {
        // Create or join a room when connected to the Photon Master Server
        PhotonNetwork.JoinOrCreateRoom ("YourRoomName", new RoomOptions (), TypedLobby.Default);
    }

    public override void OnJoinedRoom () {
        // Load the game scene when joined to the room
        PhotonNetwork.LoadLevel ("YourGameScene");
    }
}