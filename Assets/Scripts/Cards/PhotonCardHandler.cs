using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class PhotonCardHandler : MonoBehaviourPun {

    [PunRPC]
    public void SyncCardPosition (Vector3 newPosition) {
        //Synchronize the card's position for remote players
        transform.position = newPosition;
    }
}