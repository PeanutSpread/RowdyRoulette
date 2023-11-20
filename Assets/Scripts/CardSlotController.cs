using MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlotController : MonoBehaviour
{
    // Assign on instantitate
    private PlayerController playerController;

    public GameObject cardSlotPrefab;

    public void AddCard(GameObject cardObject)
    {
        GameObject cardSlotObject = Instantiate(cardSlotPrefab);
        cardSlotObject.transform.parent = gameObject.transform;
        cardSlotObject.GetComponent<CardSlot>().InitSlot(cardObject);

    }
}
