using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public bool doDisable = false;

    private void OnEnable()
    {
        EventManager.OnBombPull += BombEvent;
    }

    private void OnDisable()
    {
        EventManager.OnBombPull -= BombEvent;
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

    public void BombEvent()
    {
        BombAppear();
    }


    // Start is called before the first frame update
    void Start()
    {
        OnEnable();
    }

    // Update is called once per frame
    void Update()
    {
        if (doDisable)
        {
            OnDisable();
        }
    }
}
