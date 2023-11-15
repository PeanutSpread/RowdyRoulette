using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEvent : MonoBehaviour
{
    public void StartInteraction() 
    {
        if (EventManager.onStartInteraction != null)
        {
            EventManager.onStartInteraction(gameObject);
        }
    }

    public void EndInteraction() 
    {
        if (EventManager.onEndInteraction != null)
        {
            EventManager.onEndInteraction(gameObject);
        }
    }
}
