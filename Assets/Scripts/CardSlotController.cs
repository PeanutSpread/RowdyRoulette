using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlotController : MonoBehaviour
{
    // Assign on instantitate
    private PlayerController playerController;
    private CardComponent card;

    // Always has
    public GameObject cardSlot;

    // Start is called before the first frame update
    public void Initialize(CardComponent card, PlayerController playerController)
    {
        this.playerController = playerController;
        this.card = card;

        // Instantiate the card in the slot and make sure you cant move it
        GameObject cardObj = Instantiate(card.prefab, cardSlot.transform);
        cardObj.GetComponent<ObjectManipulator>().enabled = false;
    }

    public void OnPressed()
    {
        playerController.TakeOutCard(card, gameObject);
    }
}
