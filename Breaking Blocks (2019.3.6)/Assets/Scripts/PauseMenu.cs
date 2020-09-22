using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    GameSession gamesession;

    // Update is called once per frame
    void Update()
    {
        if(!GameIsPaused)
        {
            Resume();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Awake()
    {
        gamesession = FindObjectOfType<GameSession>();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        gamesession.gameSpeed = 0f;
        GameIsPaused = true;
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamesession.gameSpeed = 0.78f;
        GameIsPaused = false;
    }
}
