using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GodButtonControl : MonoBehaviour
{
    [SerializeField] Button godButton;
    GameSession gamesession;

    // Start is called before the first frame update
    void Start()
    {
        godButton.interactable = false;
        gamesession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if(gamesession.godUnlocked )
        {
            godButton.interactable = true;
        }
    }
}
