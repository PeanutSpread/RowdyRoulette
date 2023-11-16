using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    public void OnTriggerEnter(Collider collider) 
    {
        if (EventManager.onStartTriggerCollision != null)
        {
            EventManager.onStartTriggerCollision(gameObject, collider.gameObject);
        }
    }

    public void OnTriggerExit(Collider collider) 
    {
        if (EventManager.onEndTriggerCollision != null)
        {
            EventManager.onEndTriggerCollision(gameObject, collider.gameObject);
        }
    }
}
