using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    GameSession gamesession;

    AudioSource audioSource;
    [SerializeField] AudioClip pauseButtonSound;

    void Update()
    {
        if (!GameIsPaused)
        {
            Resume();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
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
        print("PauseMenu.cs");
        gamesession = FindObjectOfType<GameSession>();
        audioSource = GetComponent<AudioSource>();
    }

    public void Pause()
    {
        audioSource.PlayOneShot(pauseButtonSound);
        pauseMenuUI.SetActive(true);
        gamesession.gameSpeed = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamesession.gameSpeed = 0.78f;
        //audioSource.PlayOneShot(pauseButtonSound);
        GameIsPaused = false;
    }
}
