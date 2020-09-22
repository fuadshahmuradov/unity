using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    // config params
    [Range(0.1f,10f)] [SerializeField] public float gameSpeed = 0.78f;
    [SerializeField] int pointsPerBlockDestroyed =  10;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] bool isAutoPlayEnabled;

    // state variables
    [SerializeField] int currentScore = 0;
    [SerializeField] int maxLevel = 1;
    [SerializeField] int lives = 1;
    [SerializeField] public bool godUnlocked = false;

    // cached references
    SceneLoader sceneloader;
    private void Awake()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
        maxLevel = 1;
        lives = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
        livesText.text = ": " + lives.ToString();
        scoreText.text = currentScore.ToString();
        if (maxLevel == 11)
        {
            godUnlocked = true;
        }
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        IfAddLife();
    }

    public void ResetScore()
    {
        currentScore = 0;
        //Destroy(gameObject);
    }
    public void ResetMaxLevel()
    {
        maxLevel = 1;
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void LevelPassed()
    {
        maxLevel++;
    }

    public int MaxLevel()
    {
        return maxLevel;
    }

    public void LoseLife()
    {
        lives--;
        livesText.text = ": " + lives.ToString();
    }
    public void ResetLife()
    {
        lives = 1;
        livesText.text = ": " + lives.ToString();
    }
    public void ResetLifeToZero()
    {
        lives = 0;
        livesText.text = ": " + lives.ToString();
    }
    void IfAddLife()
    {
        if (currentScore % 150 == 0)
        {
            AddLife();
        }   
    }
    void AddLife()
    {
        lives++;
    }

    public bool HaveLife()
    {
        if (lives > 0)
        {
             return true;
        }   
        else
        {
            return false;
        }
    }

    public int Lives()
    {
        return lives;
    }


    // Save&Load System
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data =  SaveSystem.LoadPlayer();
        maxLevel = data.maxLevel;
        ResetLifeToZero();
        //sceneloader.LoadSavedLevel();
    }
    void OnApplicationQuit()
    {
        SaveSystem.SavePlayer(this);
    }
}
