using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public GameObject cam;

    public void IsLocalPlayer()
    {
        cam.SetActive(true);
    }
}
