using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Deck : MonoBehaviour
{
    
    private List<Card> cardList = new List<Card>();
    public GameObject cardPrefab;

    private const int DEFAULT_DECK_SIZE = 46;
    private const int DEFAULT_GROUP_AMOUNT = 5;
    private const int DEFAULT_DEFUSE_AMOUNT = 6;
    private readonly float[] CARD_PERCENTAGES = {4/46, 5/46, 20/46, 5/46, 4/46 };

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
            int ndx = UnityEngine.Random.Range(0,amnt+1);
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

    public void Setup(int players, int deckSize = DEFAULT_DECK_SIZE, int groupAmounts = DEFAULT_GROUP_AMOUNT, float[] cardPercentages = null)
    {
        //for Enum.GetValues(typeof(CardType)).Length

    }

    private void GenerateCards(CardType cardType, int group, int amount)
    {
        // causing an error for no reason ?
        /*for (int i; i < amount; i++)
        {
            Card card = new Card();
            card.InitCard(cardType, group);
            cardList.Add(card);
        }*/
    }

    void OnMouseDown()
    {
        Card card = Hit();
        GameObject cardObject = Instantiate(cardPrefab);
        cardObject.GetComponent<Card>().Copy(card);
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
