using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    public GameObject textObj;
    private int score = 0; 

    public void IncreaseScore()
    {
        score++;
    }

    private void UpdateText()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
