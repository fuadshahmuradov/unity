using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 5;
    int currentSceneIndex;

    void Start()
    {
        print("LevelLoader.cs");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadOptionsScreen()
    {
        SceneManager.LoadScene("Options Screen");
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadLevel1()
    {
        PlayerPrefsController.SetMaxLevel(1);
        SceneManager.LoadScene("Level 1");
    }
    public void LoadMaxLevel()
    {
        int maxLevel = PlayerPrefsController.GetMaxLevel();
        SceneManager.LoadScene("Level "+maxLevel);
    }
    public void LoadAbout()
    {
        SceneManager.LoadScene("About Screen");
    }
    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("Lose Screen");
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
}
