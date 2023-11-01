using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    private CardType type;
    private uint group = 0;
    
    // Return the type of card
    public cardType GetType() 
    {
        return type;
    }

    public int GetGroup() 
    {
        return group;
    }

    // Setting up the card's specific values
    public void InitCard()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
