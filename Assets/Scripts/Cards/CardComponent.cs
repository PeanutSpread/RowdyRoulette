using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponent : MonoBehaviour
{
    private Card card;
    private string owner;

    [SerializeField]
    private string cardTypeStr;

    public bool useGravity = true;

    InteractionCondition interactionCondition;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        interactionCondition = GetComponent<InteractionCondition>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionCondition.getHoldStatus())
            rb.constraints = RigidbodyConstraints.None;
        else if (!useGravity)
            rb.constraints = RigidbodyConstraints.FreezeAll;
    }

    // Return the type of card
    public new CardType GetType()
    {
        return card.GetType();
    }

    public int GetGroup()
    {
        return card.GetGroup();
    }

    public Card GetCard()
    {
        return card;
    }

    public string GetOwner()
    {
        return owner;
    }

    public void SetOwner(string owner)
    {
        this.owner = owner;
    }

    public void SetFace(Material face)
    {
        GameObject meshObject = gameObject.transform.GetChild(0).gameObject;
        meshObject.GetComponent<Renderer>().materials = new Material[]{ meshObject.GetComponent<Renderer>().materials[0], face };
    }

    // Setting up the card's specific values
    public void InitCard(CardType cardType, int cardGroup = 0)
    {
        card = new Card();
        card.InitCard(cardType, cardGroup);
        cardTypeStr = Enum.GetName(typeof(CardType), card.GetType());
    }

    public void InitCard(Card otherCard)
    {
        card = new Card();
        card.InitCard(otherCard.GetType(), otherCard.GetGroup());
        cardTypeStr = Enum.GetName(typeof(CardType), card.GetType());
    }

    public void Copy(Card otherCard)
    {
        card = otherCard;
        cardTypeStr = Enum.GetName(typeof(CardType), card.GetType());
    }

    public void Copy(CardComponent otherCard)
    {
        card = (otherCard.GetCard());
        cardTypeStr = Enum.GetName(typeof(CardType), card.GetType());
    }


}
