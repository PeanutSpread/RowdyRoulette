using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Settings")]
    public float cardSpawnDistance = 0.7f;
    public float cardStoreThreshold = 1f;

    [Header("Prefabs")]
    public GameObject cardSlotUI;
    public GameObject testCard;

    [Header("References")]
    public GameObject cardSlotParent;
    public GameObject cam;

    // This is the card the player can interact with
    // Only 1 card can be interacted with at a time
    private GameObject interactableCardObj;
    private GameObject interactableCardSlotObj;
    private CardComponent interactableCard;

    private Player player;
    private List<CardComponent> hand;

    private void Start()
    {
        hand = new List<CardComponent>();
        EventManager.onEndInteraction += OnLetGo;

        player = new Player();

        CardComponent card = new CardComponent();
        card.prefab = testCard;
        AddCardToHand(card);
    }

    public void TakeOutCard(CardComponent card, GameObject cardSlot) 
    {
        // Simulate taking a card thats in your hand
        if (interactableCardObj != null) 
        {
            Destroy(interactableCardObj);
        }

        // Put in front of cam
        interactableCardObj = Instantiate(card.prefab, cam.transform.position + (cam.transform.forward * cardSpawnDistance), Quaternion.identity);
        interactableCardSlotObj = cardSlot;
        interactableCard = card;
    }

    public void AddCardToHand(CardComponent card)
    {
        // Add a card to your hand
        GameObject cardslot = Instantiate(cardSlotUI, cardSlotParent.transform);
        cardslot.GetComponent<CardSlotController>().Initialize(card, this);

        hand.Add(card);
    }

    public void OnLetGo(GameObject obj)
    {
        // If we let go of a card we own close to yourself, it will destroy it
        if (obj == interactableCardObj) 
        {

            if (Vector3.Distance(gameObject.transform.position, cardSlotParent.transform.position) < cardStoreThreshold) 
            {
                Destroy(interactableCardObj);
                interactableCard = null;
            }
        }
    }
}
