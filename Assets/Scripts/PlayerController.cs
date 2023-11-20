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

    public void TakeOutCard(GameObject cardObject) 
    {
        GameObject cardSlot = cardObject.transform.parent.gameObject;
        cardObject.transform.parent = null;
        // Put in front of cam
        cardObject.transform.position = cam.transform.position + (cam.transform.forward * cardSpawnDistance);
        Destroy(cardSlot);

    }

    public void AddCardToHand(GameObject cardObject)
    {
        // Add a card to your hand
        GameObject cardslot = Instantiate(cardSlotUI, cardSlotParent.transform);
        cardSlotParent.GetComponent<CardSlotController>().AddCard(cardObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If we let go of a card we own close to yourself, it will destroy it
        if (other.gameObject.tag == "Card")
        {
            if (other.gameObject.GetComponent<CardComponent>().GetOwner() == "Test")
            {
                AddCardToHand(other.gameObject);
            }
        }
    }
}
