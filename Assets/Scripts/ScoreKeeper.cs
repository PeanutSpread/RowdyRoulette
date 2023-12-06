using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    public GameObject textObj;
    private float score = 0;

    public void OnEnable()
    {
        EventManager.OnCardPull += IncreaseScore;
    }

    public void OnDisable()
    {
        EventManager.OnCardPull -= IncreaseScore;
    }

    public void IncreaseScore()
    {
        
        score += 0.5f;
        UpdateText();
    }

    private void UpdateText()
    {
        textObj.GetComponent<TextMeshPro>().text = ((int)score).ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }
}
