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

    public delegate void Bomb();
    public static Bomb OnBombPull;
    public static Bomb OnBombDefused;
    public static Bomb OnBombExplode;

    public delegate void SpecialCard();
    public static SpecialCard OnFavour;
    public static SpecialCard OnFuture;
    public static SpecialCard OnNope;
    public static SpecialCard OnShuffle;


}
