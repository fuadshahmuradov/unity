using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadTeslaScene()
    {
        SceneManager.LoadScene("Tesla");
    }
    public void LoadLaunchesScene()
    {
        SceneManager.LoadScene("Launches");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
