using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    
    private List<Card> cardList = new List<Card>(); 

    // Get the remaining amount of cards in the deck
    public int GetCardCount() {
        return cardList.Count;
    }

    // Insert card back into the deck
    public void InsertCard(Card card, int index) {
        cardList.Insert(index, card);
    }

    // Check the top [amount] cards
    public List<Card> CheckCards(int amount) {
        return cardList.GetRange(0,3);
    }

    // Shuffle deck order
    public void Shuffle()
    {
        int amnt = GetCardCount();
        while (amnt > 1)
        {
            amnt--;
            int ndx = Random.Range(0,amnt+1);
            Card value = cardList[ndx];
            cardList[ndx] = cardList[amnt];
            cardList[amnt] = value;
        }

    }

    // Take a card from the deck
    public Card Hit()
    {
        Card card = cardList[0];
        cardList.RemoveAt(0);
        return card;
    }

    // Deal in players
    private void Deal() 
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        Deal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
