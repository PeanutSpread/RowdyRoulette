using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPile : CardPile
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
        cardList.Add(card);
        SetFace(CardFaces[(int) card.GetType()]);
        Destroy(cardObject.transform.parent.gameObject);
        IncreaseHeight();
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

        // Start is called before the first frame update
        new void Start()
    {
        base.Start();
        gameObject.GetComponent<BoxCollider>().isTrigger = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
