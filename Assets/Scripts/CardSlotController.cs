using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlotController : MonoBehaviour
{
    // Assign on instantitate
    private PlayerController playerController;

    public GameObject cardSlotPrefab;

    public void AddCard(CardComponent card, Material face)
    {
        GameObject cardSlotObject = Instantiate(cardSlotPrefab);
        cardSlotObject.GetComponent<CardSlot>().InitSlot(card.GetCard(), face);

    }

    // Start is called before the first frame update
    public void Start()
    {
        
    }

    public void Update()
    {

    }
}
