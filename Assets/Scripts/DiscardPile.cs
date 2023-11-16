using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : Deck
{
    // Play card or cards
    public void Play(Card card)
    {

    }

    public void Play(List<Card> cards)
    {
        switch (cards.Count)
        {
            case 2:
               
                if (SameGroup(cards))
                {
                    // TODO: Pick card at random
                }
                break;
            
            case 3:
                if (SameGroup(cards))
                {
                    // TODO: Request a card of specific type
                }
                break;
            
            case 5:

                // TODO: Grab a card from discard pile
                break;

                
        }
    }

    private bool SameGroup(List<Card> cards) 
    {
        int group = cards[0].group;
        foreach (Card card in cards)
        {
           if (group != card.group)
           {
                return false;
           }
        }
        return true;
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
