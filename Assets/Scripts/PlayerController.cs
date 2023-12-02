using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;
    public GameObject cardSpawn;
    public Player player;

    public Transform GetSpawnTransform()
    {
        return cardSpawn.transform;
    }

    public void AddCardToHand(GameObject cardObject)
    {
        // Add a card to your hand
        CardComponent cardComponent = cardObject.GetComponent<CardComponent>();
        cardComponent.SetOwner(player.getID());

        player.TakeCard(cardComponent.GetCard());
    }

    private void OnTriggerEnter(Collider other)
    {
        // If we let go of a card we own close to yourself, we will parent it to us
        if (other.gameObject.tag == "Card")
        {
            GameObject cardObject = other.transform.parent.gameObject;
            if (cardObject.GetComponent<CardComponent>().GetOwner() == player.getID() && cardObject.GetComponent<InteractionCondition>().getHoldStatus())
            {
                cardObject.GetComponent<CardComponent>().useGravity = false;
                cardObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

                cardObject.transform.parent = cam.transform;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // If we let go of a card we own away from yourself, we will unparent from us
        if (other.gameObject.tag == "Card")
        {
            GameObject cardObject = other.transform.parent.gameObject;
            if (cardObject.GetComponent<CardComponent>().GetOwner() == player.getID())
            {
                cardObject.GetComponent<CardComponent>().useGravity = true;
                cardObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

                cardObject.transform.parent = null;
            }
        }
    }
}
