using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : CardPile
{

    public bool isBombActive = false;

    public void OnEnable()
    {
        EventManager.OnBombPull += BombEventConditions;
        EventManager.OnGameStart += InitDiscardPile;
    }

    public void OnDisable()
    {
        EventManager.OnBombPull -= BombEventConditions;
        EventManager.OnGameStart -= InitDiscardPile;
    }

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
        int group = cards[0].GetGroup();
        foreach (Card card in cards)
        {
            if (group != card.GetGroup())
            {
                return false;
            }
        }
        return true;
    }

    private void AddToPile(GameObject cardObject)
    {
        Card card = cardObject.transform.parent.gameObject.GetComponent<CardComponent>().GetCard();
        if (card.GetType() != CardType.Bomb)
        {
            if (!isBombActive && card.GetType() != CardType.Defuse || isBombActive && card.GetType() == CardType.Defuse)
            {
                cardList.Add(card);
                SetFace(CardFaces[(int)card.GetType()]);
                Destroy(cardObject.transform.parent.gameObject);
                IncreaseHeight();

                if (isBombActive)
                {
                    isBombActive = false;
                    EventManager.OnBombDefused.Invoke();
                    EventManager.OnNextTurn.Invoke();
                }
            }
        }
    }

    public void SetFace(Material face)
    {
        GameObject meshObject = gameObject.transform.GetChild(0).gameObject;
        meshObject.GetComponent<Renderer>().materials = new Material[] { meshObject.GetComponent<Renderer>().materials[0], face };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Card")
        {
            AddToPile(other.gameObject);
        }
    }

    private void BombEventConditions()
    {
        isBombActive = true;
    }

    public void InitDiscardPile()
    {
        base.Start();
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        Show();
    }

    // Start is called before the first frame update
    new void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
