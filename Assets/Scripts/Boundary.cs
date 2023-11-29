using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    // If a card falls out of bounds, put it in front of owned player
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Card")
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (var player in players)
            {
                if (player.GetComponent<PlayerController>().player.getID() == collision.gameObject.GetComponent<CardComponent>().GetOwner()) 
                {
                    collision.gameObject.transform.position = player.transform.position + new Vector3(0, 0, 1);
                }
            }
        }
    }
}
