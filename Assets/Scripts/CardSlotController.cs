using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlotController : MonoBehaviour
{
    // Assign on instantitate
    private PlayerController playerController;
    private CardComponent card;

    public GameObject cardPrefab;

    // Always has
    public GameObject cardSlot;

    // Start is called before the first frame update
    public void Initialize(CardComponent card, PlayerController playerController)
    {
        this.playerController = playerController;
        this.card = card;

        // Instantiate the card in the slot and make sure you cant move it
        GameObject cardObject = Instantiate(cardPrefab, cardSlot.transform);
        cardObject.GetComponent<ObjectManipulator>().enabled = false;
    }

    public void OnPressed()
    {
        playerController.TakeOutCard(card, gameObject);
    }
}
