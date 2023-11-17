using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Card
{

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
}
