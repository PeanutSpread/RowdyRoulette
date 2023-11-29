using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;

public class Deck : CardPile
{
    private const int DEFAULT_DECK_SIZE = 46;
    private const int DEFAULT_GROUP_AMOUNT = 5;
    private const int DEFAULT_DEFUSE_AMOUNT = 6;
    private readonly float[] CARD_PERCENTAGES = { 4f / 46f, 5f / 46f, 20f / 46f, 5f / 46f, 4f / 46f };

    private List<GameObject> playerObjects = new List<GameObject>();

    public void OnEnable()
    {
        EventManager.OnGameStart += InitDeck;
    }

    public void OnDisable()
    {
        EventManager.OnGameStart -= InitDeck;
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

    public void AddPlayer(GameObject playerObject)
    {
        playerObjects.Add(playerObject);
    }

    public void Pull(PlayerController playerController = null)
    {
        GameObject cardObject = null;
        if (playerController == null)
            cardObject = TakeCard();
        else
            cardObject = TakeCard(playerController.GetSpawnTransform());

        if (cardObject != null)
        {
            if (cardObject.GetComponent<CardComponent>().GetType() == CardType.Bomb)
            {
                EventManager.OnBombPull.Invoke();
            } else {
                EventManager.OnNextTurn.Invoke();
            }
        }
    }

    private void AddDefuse(PlayerController playerController)
    {
        createCard(playerController.GetSpawnTransform(), CardType.Defuse, 0);
    }

    // Deal in players
    private void Deal() 
    {
        foreach (GameObject playerObject in playerObjects)
        {
            AddDefuse(playerObject.GetComponent<PlayerController>());
            for (int i = 0; i > 4; i++)
            {
                Pull(playerObject.GetComponent<PlayerController>());
            }
        }
    }

    private void Setup(int deckSize = DEFAULT_DECK_SIZE, int groupAmounts = DEFAULT_GROUP_AMOUNT, float[] cardPercentages = null)
    {
        int groups = 0;
        CardType[] cardTypes = Enum.GetValues(typeof(CardType)).Cast<CardType>().ToArray();
        if (cardPercentages == null)
        {
            cardPercentages = CARD_PERCENTAGES;
        }

        for (int i = 2; i < Enum.GetValues(typeof(CardType)).Length; i++)
        {
            if (cardTypes[i] == CardType.Generic)
                groups = groupAmounts;

            if (groups != 0)
            {
                for (int x = 0; x < groupAmounts; x++)
                {
                    GenerateCards(cardTypes[i], x + 1, (int)(cardPercentages[i - 2] * deckSize) / groupAmounts);
                }
            }
            else
            {
                GenerateCards(cardTypes[i], groups, (int)(cardPercentages[i - 2] * deckSize));
            }
            groups = 0;
        }

        Shuffle();

    }

    private void AddBombsAndDefuses(int players) {
        GenerateCards(CardType.Bomb, 0, players - 1);
        GenerateCards(CardType.Defuse, 0 , DEFAULT_DEFUSE_AMOUNT - players);
        Shuffle();
    }

    private void GenerateCards(CardType cardType, int group, int amount)
    {
        for (int _ = 0; _ < amount; _++)
        {
            Card card = new Card();
            card.InitCard(cardType, group);
            cardList.Add(card);
        }
    }

    public void InitDeck()
    {
        base.Start();

        Setup();
        Deal();
        AddBombsAndDefuses(3);

        amount = GetCardCount();
        SetupHeight();
    }

    // Start is called before the first frame update
    new void Start()
    {
        InitDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
