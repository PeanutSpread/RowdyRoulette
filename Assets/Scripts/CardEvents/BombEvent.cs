using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEvent : MonoBehaviour
{

    public void OnEnable()
    {
        EventManager.OnBombPull += BombEventStart;
        EventManager.OnBombDefused += BombEventDefuse;
        EventManager.OnBombExplode += BombEventExplode;
    }

    public void OnDisable()
    {
        EventManager.OnBombPull -= BombEventStart;
        EventManager.OnBombDefused -= BombEventDefuse;
        EventManager.OnBombExplode -= BombEventExplode;

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

    public void BombEventStart(PlayerController playerController)
    {
        BombAppear();
        gameObject.transform.position = playerController.cardSpawn.transform.position;
        gameObject.transform.rotation = playerController.cardSpawn.transform.rotation;
        Quaternion rotation = gameObject.transform.rotation;
        rotation.x = 0;
        gameObject.transform.rotation = rotation;
    }

    public void BombEventExplode(PlayerController playerController)
    {
        BombDisappear();
    }

    public void BombEventDefuse(PlayerController playerController)
    {
        BombDisappear();
    }

}
