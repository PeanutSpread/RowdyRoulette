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
    public static Turn OnGameEnd;
    public static Turn OnGameExit;

    public delegate void User(GameObject playerObject);
    public static User OnPlayerJoined;

    public delegate void Bomb(PlayerController playerController);
    public static Bomb OnBombPull;
    public static Bomb OnBombDefused;
    public static Bomb OnBombExplode;
    public static Bomb OnBombExploded;

    public delegate void SpecialCard();
    public static SpecialCard OnCardPull;
    public static SpecialCard OnFavour;
    public static SpecialCard OnFuture;
    public static SpecialCard OnNope;
    public static SpecialCard OnShuffle;

    public GameObject bombObject;
    public GameObject discardPileObject;
    public GameObject deckObject;
    public GameObject scoreObject;

    public static string whoseTurn = "";
    private List<string> turnOrder = new List<string>();

    private void AddPlayer(GameObject playerObject)
    {
        Player player = playerObject.GetComponent<PlayerController>().player;
        turnOrder.Add(player.getID());
        deckObject.GetComponent<Deck>().AddPlayer(playerObject);
        discardPileObject.GetComponent<DiscardPile>().AddPlayer(playerObject);
    }

    private void ProcessTurn()
    {
        string playerID = turnOrder[0];
        turnOrder.RemoveAt(0);
        turnOrder.Add(playerID);
        whoseTurn = turnOrder[0];
    }

    private void EliminatePlayer(PlayerController playerController)
    {
        string playerID = playerController.player.getID();
        turnOrder.Remove(playerID);
        if (turnOrder.Count > 0)
            whoseTurn = turnOrder[0];
        else
            whoseTurn = "";
    }

    private void RandomizeTurnOrder() 
    {
        int amnt = turnOrder.Count;
        while (amnt > 1)
        {
            amnt--;
            int ndx = UnityEngine.Random.Range(0, amnt + 1);
            string value = turnOrder[ndx];
            turnOrder[ndx] = turnOrder[amnt];
            turnOrder[amnt] = value;
        }
        whoseTurn = turnOrder[0];
    }

    private void Primer()
    {
        deckObject.GetComponent<Deck>().Hide();
        discardPileObject.GetComponent<DiscardPile>().Hide();
    }

    private void EnableSequence()
    {
        bombObject.GetComponent<BombEvent>().OnEnable();
        discardPileObject.GetComponent<DiscardPile>().OnEnable();
        deckObject.GetComponent <Deck>().OnEnable();
        scoreObject.GetComponent<ScoreKeeper>().OnEnable();
        EventManager.OnPlayerJoined += AddPlayer;
        EventManager.OnNextTurn += ProcessTurn;
        EventManager.OnBombExploded += EliminatePlayer;
        EventManager.OnGameStart += RandomizeTurnOrder;
        EventManager.OnGameExit += DisableSequence;
    }

    private void DisableSequence()
    {
        bombObject.GetComponent<BombEvent>().OnDisable();
        discardPileObject.GetComponent<DiscardPile>().OnDisable();
        deckObject.GetComponent<Deck>().OnDisable();
        scoreObject.GetComponent<ScoreKeeper>().OnDisable();
        EventManager.OnPlayerJoined -= AddPlayer;
        EventManager.OnNextTurn -= ProcessTurn;
        EventManager.OnBombExploded -= EliminatePlayer;
        EventManager.OnGameStart -= RandomizeTurnOrder;
        EventManager.OnGameExit -= DisableSequence;
    }
    
    public void EndEvent()
    {
        DisableSequence();
    }

    void Start()
    {
        Primer();
        EnableSequence();
    }

}
