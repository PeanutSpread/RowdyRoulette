using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void StartInteraction(GameObject obj);
    public static StartInteraction onStartInteraction;

    public delegate void EndInteraction(GameObject obj);
    public static EndInteraction onEndInteraction;

    public delegate void StartTriggerCollision(GameObject source, GameObject collider);
    public static StartTriggerCollision onStartTriggerCollision;

    public delegate void EndTriggerCollision(GameObject source, GameObject collider);
    public static EndTriggerCollision onEndTriggerCollision;

    public delegate void Turn();
    public static Turn OnNextTurn;
    public static Turn OnGameStart;

    public delegate void User(GameObject playerObject);
    public static User OnPlayerJoined;

    public delegate void Bomb();
    public static Bomb OnBombPull;
    public static Bomb OnBombDefused;
    public static Bomb OnBombExplode;

    public delegate void SpecialCard();
    public static SpecialCard OnFavour;
    public static SpecialCard OnFuture;
    public static SpecialCard OnNope;
    public static SpecialCard OnShuffle;

    public GameObject BombObject;
    public GameObject DiscardPileObject;
    public GameObject DeckObject;
    public bool onDisable = false;

    public static string whoseTurn = "";
    private List<string> turnOrder = new List<string>();

    private void AddPlayer(GameObject playerObject)
    {
        Player player = playerObject.GetComponent<PlayerController>().player;
        turnOrder.Add(player.getID());
        DeckObject.GetComponent<Deck>().AddPlayer(playerObject);
    }

    private void ProcessTurn()
    {
        string playerID = turnOrder[0];
        turnOrder.RemoveAt(0);
        turnOrder.Add(playerID);
    }

    private void EnableSequence()
    {
        BombObject.GetComponent<BombEvent>().OnEnable();
        DiscardPileObject.GetComponent<DiscardPile>().OnEnable();
        DeckObject.GetComponent <Deck>().OnEnable();
        EventManager.OnPlayerJoined += AddPlayer;
        EventManager.OnNextTurn += ProcessTurn;
    }

    private void DisableSequence()
    {
        BombObject.GetComponent<BombEvent>().OnDisable();
        DiscardPileObject.GetComponent<DiscardPile>().OnDisable();
        DeckObject.GetComponent<Deck>().OnDisable();
        EventManager.OnPlayerJoined -= AddPlayer;
        EventManager.OnNextTurn -= ProcessTurn;
    }
    
    void Start()
    {
        EnableSequence();
    }

    private void Update()
    {
        if (onDisable)
        {
            DisableSequence();
        }
    }

}
