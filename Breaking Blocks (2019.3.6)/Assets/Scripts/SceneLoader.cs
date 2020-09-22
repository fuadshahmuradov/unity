using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameSession gamesession;
    PauseMenu pausemenu;

    private void Awake()
    {
        gamesession = FindObjectOfType<GameSession>();
        pausemenu = FindObjectOfType<PauseMenu>();
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start Menu");
        FindObjectOfType<GameSession>().ResetScore();
    }

    public void LoadNewGame()
    {
        gamesession.ResetScore();
        gamesession.ResetMaxLevel();
        gamesession.ResetLife();
        LoadLevel1();
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadNews()
    {
        SceneManager.LoadScene("News");
    }

    public void LoadLostLevel()
    {
        if(gamesession.HaveLife())
        {
            pausemenu.GameIsPaused = false;
            int lostLevel = gamesession.MaxLevel();
            gamesession.LoseLife();
            gamesession.ResetScore();
            SceneManager.LoadScene("Level " + lostLevel);
        }
        else
        {
            pausemenu.GameIsPaused = false;
            LoadNewGame();
        }
        
    }

    public void LoadCurrentLevel()
    {
        if (gamesession.HaveLife())
        {

            string currentScene = SceneManager.GetActiveScene().name;
            gamesession.LoseLife();
            gamesession.ResetScore();
            SceneManager.LoadScene(currentScene);
        }
        else
        {
            LoadNewGame();
        }
    }
    public void LoadSavedLevel()
    {
        int savedLevel = gamesession.MaxLevel();
        gamesession.ResetLifeToZero();
        SceneManager.LoadScene("Level " + savedLevel);
    }

    public void LoadHellO()
    {
        SceneManager.LoadScene("Level 10");
    }

    public void LoadGod()
    {
        SceneManager.LoadScene("God");
    }
    public void LoadGodCreate()
    {
        SceneManager.LoadScene("GodCreate");
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene("Level 6");
    }
    public void LoadLevel7()
    {
        SceneManager.LoadScene("Level 7");
    }
    public void LoadLevel8()
    {
        SceneManager.LoadScene("Level 8");
    }
    public void LoadLevel9()
    {
        SceneManager.LoadScene("Level 9");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
}
