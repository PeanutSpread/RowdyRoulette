using System.Collections;
using System.Collections.Generic;

public class Player 
{
    private List<Card> hand;
    private string id;

    public Player(string playerID) {
        hand = new List<Card>();
        id = playerID;
    }

    public string getID()
    {
        return id;
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
