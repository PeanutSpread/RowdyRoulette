using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card : MonoBehaviour
{

    public Material[] CardFaces = new Material[Enum.GetValues(typeof(CardType)).Length];

    private CardType type;
    private int group = 0;

    
    // Return the type of card
    public new CardType GetType() 
    {
        return type;
    }

    public int GetGroup() 
    {
        return group;
    }

    // Setting up the card's specific values
    public void InitCard(CardType cardType, int cardGroup = 0)
    {
        type = cardType;
        group = cardGroup;
    }

    public void Copy(Card otherCard)
    {
        InitCard(otherCard.GetType(), otherCard.GetGroup());
    }

    public void setFace()
    {
        GameObject meshObject = gameObject.transform.GetChild(0).gameObject;
        meshObject.GetComponent<MeshRenderer>().material = CardFaces[(int) type];
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
