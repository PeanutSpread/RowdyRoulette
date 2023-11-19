using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardComponent : MonoBehaviour
{
    private Card card;
    private string owner = "test";

    [SerializeField]
    private string name;

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
        name = Enum.GetName(typeof(CardType), card.GetType());
    }

    public void InitCard(Card otherCard)
    {
        card = new Card();
        card.InitCard(otherCard.GetType(), otherCard.GetGroup());
        name = Enum.GetName(typeof(CardType), card.GetType());
    }

    public void Copy(Card otherCard)
    {
        card = otherCard;
        name = Enum.GetName(typeof(CardType), card.GetType());
    }

    public void Copy(CardComponent otherCard)
    {
        card = (otherCard.GetCard());
        name = Enum.GetName(typeof(CardType), card.GetType());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
