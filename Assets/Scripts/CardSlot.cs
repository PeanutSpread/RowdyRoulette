using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{

    private Vector3 Center(Vector3[] corners)
    {
        Vector3 center = new Vector3();
        center.x = (corners[0].x - corners[2].x) / 2 + corners[0].x;
        center.y = (corners[0].y - corners[2].y) / 2 + corners[0].y;
        center.z = corners[0].z;
        return center;
    }

    public void InitSlot(GameObject cardObject)
    {
        Vector3[] corners = new Vector3[4];
        gameObject.GetComponent<RectTransform>().GetWorldCorners(corners);

        cardObject.GetComponent<Rigidbody>().isKinematic = true;
        cardObject.transform.SetParent(gameObject.transform, true);
        cardObject.transform.position = Center(corners);
        cardObject.transform.rotation = gameObject.transform.rotation;
    }
}
