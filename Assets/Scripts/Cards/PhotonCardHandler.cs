using System.Collections;
using System.Collections.Generic;
using Photon.Pun;

public class PhotonCardHandler : MonoBehaviourPun {
    void Start () {

        if (PhotonNetwork.IsMasterClient) {

            PhotonNetwork.Instantiate ("CardV2", transform.position, transform.rotation);
        }
    }

    [PunRPC]
    public void SyncCardPosition (Vector3 newPosition) {
        //Synchronize the card's position for remote players
        transform.position = newPosition;
    }
}