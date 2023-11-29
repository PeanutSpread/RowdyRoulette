using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    public GameObject cam;
    public List<GameObject> scriptsToEnable;
    public List<GameObject> scriptsToDisable;

    public void IsLocalPlayer()
    {
        cam.SetActive(true);
        foreach (GameObject script in scriptsToEnable)
        {
            script.SetActive(true);
        }

        foreach (GameObject script in scriptsToDisable)
        {
            script.SetActive(false);
        }
    }
}
