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
    public GameObject cardPrefab;

    [Header("References")]
    public GameObject cardSlotParent;
    public GameObject cam;

    private Player player;

    private void Start()
    {
        player = new Player("test");
    }

    public void TakeOutCard(CardComponent card, GameObject cardSlot) 
    {

        // Put in front of cam
        GameObject cardObject = Instantiate(cardPrefab, cam.transform.position + (cam.transform.forward * cardSpawnDistance), Quaternion.identity);
        cardObject.GetComponent<CardComponent>().Copy(card);

        //interactableCardSlotObj = cardSlot;
        //interactableCard = card;
    }

    public void AddCardToHand(GameObject cardObject)
    {
        CardComponent cardComponent = cardObject.GetComponent<CardComponent>();

        // Add a card to your hand
        GameObject cardslot = Instantiate(cardSlotUI, cardSlotParent.transform);
        cardslot.GetComponent<CardSlotController>().Initialize(cardComponent, this);

        player.TakeCard(cardComponent.GetCard());
    }

    public void OnLetGo(GameObject cardObject)
    {
        // If we let go of a card we own close to yourself, it will destroy it
        if (cardObject.GetComponent<CardComponent>().GetOwner() == player.getID()) 
        {

            if (Vector3.Distance(gameObject.transform.position, cardSlotParent.transform.position) < cardStoreThreshold) 
            {
                Destroy(cardObject);
            }
        }
    }
}
