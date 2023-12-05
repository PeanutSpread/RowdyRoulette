using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : CardPile
{

    public bool isBombActive = false;
    private Dictionary<string, GameObject> players = new Dictionary<string, GameObject>();

    public void OnEnable()
    {
        EventManager.OnBombPull += BombEventConditions;
        EventManager.OnGameStart += InitDiscardPile;
        EventManager.OnBombExplode += BombEventEnd;
    }

    public void OnDisable()
    {
        EventManager.OnBombPull -= BombEventConditions;
        EventManager.OnGameStart -= InitDiscardPile;
        EventManager.OnBombExplode -= BombEventEnd;
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

    public void AddPlayer(GameObject playerObject)
    {
        string playerID = playerObject.GetComponent<PlayerController>().player.getID();
        players[playerID] = playerObject;
    }

    private void RemoveCardFromHand(GameObject cardObject)
    {
        string playerID = cardObject.GetComponent<CardComponent>().GetOwner();
        Debug.Log(playerID);
        GameObject playerObject = players[playerID];
        playerObject.GetComponent<PlayerController>().RemoveCardFromHand(cardObject);
    }

    private void AddToPile(GameObject cardObject)
    {
        Card card = cardObject.GetComponent<CardComponent>().GetCard();
        if (card.GetType() != CardType.Bomb)
        {
            if (!isBombActive && card.GetType() != CardType.Defuse || isBombActive && card.GetType() == CardType.Defuse)
            {
                RemoveCardFromHand(cardObject);
                cardList.Add(card);
                SetFace(CardFaces[(int)card.GetType()]);
                Destroy(cardObject);
                IncreaseHeight();

                if (isBombActive)
                {
                    BombEventEnd();
                    EventManager.OnBombDefused.Invoke(null);
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
            AddToPile(other.gameObject.transform.parent.gameObject);
        }
    }

    private void BombEventConditions(PlayerController playerController = null)
    {
        isBombActive = true;
    }

    private void BombEventEnd(PlayerController playerController = null)
    {
        isBombActive=false;
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
