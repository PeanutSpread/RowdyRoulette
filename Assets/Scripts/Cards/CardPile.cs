using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using Photon.Pun;

[RequireComponent(typeof(BoxCollider))]
public abstract class CardPile : MonoBehaviour
{
    public Material[] CardFaces = new Material[Enum.GetValues(typeof(CardType)).Length];
    public GameObject cardPrefab;

    protected List<Card> cardList = new List<Card>();
    protected GameObject cardsMeshObject;
    [SerializeField]
    protected int amount;
    protected float hitBoxStep;

    // Get the remaining amount of cards in the pile
    public int GetCardCount()
    {
        return cardList.Count;
    }

    // Take a card from the pile
    public Card Hit()
    {
        Card card = cardList[0];
        cardList.RemoveAt(0);
        return card;
    }

    protected GameObject TakeCard()
    {
        if (cardList.Count > 0)
        {
            Card card = Hit();
            amount = GetCardCount();
            Vector3 spawnPos = gameObject.transform.position + new Vector3(0, 0.25f, 0);

            GameObject cardObject = PhotonNetwork.Instantiate("CardV2", spawnPos, gameObject.transform.rotation);
            cardObject.GetComponent<CardComponent>().Copy(card);
            cardObject.GetComponent<CardComponent>().SetFace(CardFaces[(int)card.GetType()]);

            ReduceHeight();

            return cardObject;
        }

        return null;
    }


    protected void ReduceHeight()
    {
        Vector3 scale = cardsMeshObject.transform.localScale;
        scale.y -= 100;
        cardsMeshObject.transform.localScale = scale;

        Vector3 hitBoxScale = gameObject.GetComponent<BoxCollider>().size;
        hitBoxScale.y -= hitBoxStep;
        gameObject.GetComponent<BoxCollider>().size = hitBoxScale;

        Vector3 hitBoxSpot = gameObject.GetComponent<BoxCollider>().center;
        hitBoxSpot.y -= hitBoxStep / 2;
        gameObject.GetComponent<BoxCollider>().center = hitBoxSpot;
    }

    protected void IncreaseHeight()
    {
        Vector3 scale = cardsMeshObject.transform.localScale;
        scale.y += 100;
        cardsMeshObject.transform.localScale = scale;

        Vector3 hitBoxScale = gameObject.GetComponent<BoxCollider>().size;
        hitBoxScale.y += hitBoxStep;
        gameObject.GetComponent<BoxCollider>().size = hitBoxScale;

        Vector3 hitBoxSpot = gameObject.GetComponent<BoxCollider>().center;
        hitBoxSpot.y += hitBoxStep / 2;
        gameObject.GetComponent<BoxCollider>().center = hitBoxSpot;
    }

    protected void SetupHeight()
    {
        Vector3 meshScale = cardsMeshObject.transform.localScale;
        meshScale.y = (100 * cardList.Count) + 0.1f;
        cardsMeshObject.transform.localScale = meshScale;

        Vector3 hitBoxScale = gameObject.GetComponent<BoxCollider>().size;
        hitBoxScale.y = hitBoxScale.y * cardList.Count / 3 + 0.001f;
        gameObject.GetComponent<BoxCollider>().size = hitBoxScale;

        Vector3 hitBoxSpot = gameObject.GetComponent<BoxCollider>().center;
        hitBoxSpot.y = hitBoxScale.y / 2;
        gameObject.GetComponent<BoxCollider>().center = hitBoxSpot;

        hitBoxStep = hitBoxScale.y / cardList.Count;
    }

    public void Start()
    {
        BoxCollider cardBox = gameObject.GetComponent<BoxCollider>();
        cardBox.size = new Vector3(0.125f * gameObject.transform.localScale.x, 0.005f * gameObject.transform.localScale.y, 0.2f * gameObject.transform.localScale.z);
        cardBox.center = new Vector3(0, cardBox.size.y/2, 0);
        cardsMeshObject = gameObject.transform.GetChild(0).gameObject;
    }

}
