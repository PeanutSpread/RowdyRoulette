using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void OnPressed()
    {
        EventManager.OnGameStart.Invoke();
        Destroy(gameObject);
    }
}
