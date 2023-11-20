using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public GameObject CardPrefab;

    private Card card;
    private Material face;

    public void InitSlot(Card card, Material face)
    {
        this.card = card;
        this.face = face;
    }

    public void OnChoose()
    {
        GameObject cardObject = Instantiate(CardPrefab);
        cardObject.GetComponent<CardComponent>().Copy(card);
        cardObject.SetFace(face);
        Destroy(gameObject);
    }
}
