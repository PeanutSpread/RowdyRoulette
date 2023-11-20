using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public void InitSlot(GameObject cardObject)
    {
        cardObject.transform.SetParent(gameObject.transform, true);
        cardObject.transform.position = Vector3.zero;
        cardObject.transform.rotation = gameObject.transform.rotation;
    }
}
