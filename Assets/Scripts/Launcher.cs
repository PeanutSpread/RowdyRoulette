using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class Launcher : MonoBehaviourPunCallbacks {
    #region Private Serializable Fields
    [Tooltip ("Max players")]
    [SerializeField]
    private byte maxPlayersPerRoom = 4;
    #endregion

    #region Private Fields

    string gameVersion = "1";

    #endregion

    #region MonoBehaviour CallBacks
    // Start is called before the first frame update
    void Awake () {
        // #Critical
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start () {
        Connect ();
    }

    #endregion

    #region Public Methods

    public void Connect () {
        // we check if we are connected or not, we join if we are , else we initiate the connection to the server.
        if (PhotonNetwork.IsConnected) {
            // #Critical we need at this point to attempt joining a Random Room. If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one.
            PhotonNetwork.JoinRandomRoom ();
        } else {
            // #Critical, we must first and foremost connect to Photon Online Server.
            PhotonNetwork.ConnectUsingSettings ();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    #endregion

    #region MonoBehaviourPunCallbacks Callbacks

    public override void OnConnectedToMaster () {
        Debug.Log ("OnConnectedToMaster() was called by PUN");
        PhotonNetwork.JoinRandomRoom ();
    }

    public override void OnDisconnected (DisconnectCause cause) {
        Debug.LogWarningFormat ("OnDisconnected() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed (short returnCode, string message) {
        Debug.Log ("OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");

        PhotonNetwork.CreateRoom (null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
    }

    public override void OnJoinedRoom () {
        Debug.Log ("OnJoinedRoom() called by PUN. Now this client is in a room.");
    }

    #endregion

}