using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionCondition : MonoBehaviour
{

    private bool isHeld = false;

    public bool getHoldStatus()
    {
        return isHeld;
    }

    public void OnHoldStart()
    {
        isHeld = true;
    }

    public void OnHoldEnd()
    {
        isHeld = false;
    }


}
