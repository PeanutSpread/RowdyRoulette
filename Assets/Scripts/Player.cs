using System.Collections;
using System.Collections.Generic;

public class Player 
{
    private List<Card> hand;

    public Player() {
        hand = new List<Card>();
    }

    public void TakeCard(Card card)
    { 
        hand.Add(card);
    }

    public void PlayCard(Card card)
    {
        hand.Remove(card);
    }
}
