using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    // If a card falls out of bounds, put it in front of owned player
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Card")
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                if (player.GetComponent<PlayerController>().player.getID() == other.transform.parent.GetComponent<CardComponent>().GetOwner())
                {
                    GameObject cardObj = other.gameObject.transform.parent.gameObject;
                    cardObj.gameObject.transform.position = player.GetComponent<PlayerController>().cardSpawn.transform.position + PlayerController.objSpawnHeight;
                    cardObj.gameObject.transform.rotation = player.GetComponent<PlayerController>().cardSpawn.transform.rotation;
                    cardObj.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }

        if (other.gameObject.tag == "Bomb")
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                if (player.GetComponent<PlayerController>().player.getID() == other.gameObject.GetComponent<BombEvent>().GetPlayerName())
                {
                    GameObject bombObj = other.gameObject;
                    bombObj.gameObject.transform.position = player.GetComponent<PlayerController>().cardSpawn.transform.position + PlayerController.objSpawnHeight;
                    bombObj.gameObject.transform.rotation = player.GetComponent<PlayerController>().cardSpawn.transform.rotation;
                    bombObj.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                }
            }
        }
    }
}
