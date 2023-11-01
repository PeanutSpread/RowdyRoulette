using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discard : Deck
{
    // Play card or cards
    public void Discard(Card card)
    {

    }

    public void Discard(List<Card> cards)
    {
        switch (cards.Count())
        {
            case 2:
               
                // TODO: Pick card at random
                break;
        }
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
