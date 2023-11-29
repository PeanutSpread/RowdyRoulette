using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEvent : MonoBehaviour
{
    public void OnEnable()
    {
        EventManager.OnBombPull += BombEventStart;
    }

    public void OnDisable()
    {
        EventManager.OnBombPull -= BombEventStart;
    }

    private void BombAppear()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        gameObject.GetComponent<MeshCollider>().enabled = true;
    }

    private void BombDisappear()
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<MeshCollider>().enabled = false;
    }

    public void BombEventStart()
    {
        BombAppear();
    }

}
