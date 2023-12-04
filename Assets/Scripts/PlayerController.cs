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

    private void Start()
    {
        player = new Player("Test");

        EventManager.OnPlayerJoined.Invoke(gameObject);
    }

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

    public void RemoveCardFromHand(GameObject cardObject)
    {
        Card card = cardObject.GetComponent<CardComponent>().GetCard();
        player.RemoveCard(card);
    }

    public bool HasDefuse()
    {
        foreach (Card card in player.getHand())
        {
            if (card.GetType() == CardType.Defuse)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If we let go of a card we own close to yourself, we will parent it to us
        if (other.gameObject.tag == "Card")
        {
            GameObject cardObject = other.transform.parent.gameObject;
            if (cardObject.GetComponent<CardComponent>().GetOwner() == player.getID() && cardObject.GetComponent<InteractionCondition>().getHoldStatus())
            {
                Debug.Log("entered");

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
                Debug.Log("left");
                cardObject.GetComponent<CardComponent>().useGravity = true;
                cardObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

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
