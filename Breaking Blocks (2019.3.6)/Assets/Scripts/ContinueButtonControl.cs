using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButtonControl : MonoBehaviour
{
    [SerializeField] Button continueButton;
    GameSession gamesession;

    private void Awake()
    {
        gamesession = FindObjectOfType<GameSession>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (gamesession.MaxLevel() <= 1)
        { 
            continueButton.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (gamesession.MaxLevel()>=2)
        {
            continueButton.interactable = true;
        }
    }
}
