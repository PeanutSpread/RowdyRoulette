using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card : MonoBehaviour
{

    public CardType type;
    public int group = 0;
    public Material[] CardFaces = new Material[Enum.GetValues(typeof(CardType)).Length];
    public GameObject prefab { get; set; }
    
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
        changeFace(type);
    }

    public void Copy(Card otherCard)
    {
        InitCard(otherCard.GetType(), otherCard.GetGroup());
    }

    private void changeFace(CardType cardType)
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
