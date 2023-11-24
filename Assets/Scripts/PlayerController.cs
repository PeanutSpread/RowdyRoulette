using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject cam;

    private Player player;

    private void Start()
    {
        player = new Player("Test");
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
                cardObject.GetComponent<Rigidbody>().isKinematic = true;
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
                cardObject.GetComponent<Rigidbody>().isKinematic = false;
                cardObject.transform.parent = null;
            }
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    // If we let go of a card we own close to yourself, it will destroy it
    //    if (other.gameObject.tag == "Card")
    //    {
    //        GameObject cardObject = other.transform.parent.gameObject;
    //        if (cardObject.GetComponent<CardComponent>().GetOwner() == player.getID())
    //        {
    //            if (cardObject.transform.parent.gameObject.GetComponent<CardSlot>() == null)
    //            {
    //                if (cardObject.GetComponent<InteractionCondition>().getHoldStatus() == false)
    //                    AddCardToHand(cardObject);
    //            }
    //        }
    //    }
    //}
}
