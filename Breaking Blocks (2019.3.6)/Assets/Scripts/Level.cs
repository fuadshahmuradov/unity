using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    // parameters
    [SerializeField] int breakableBlocks; // Serialized for debugging purposes

    //cached reference
    SceneLoader sceneloader;
    GameSession gamesession;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
        gamesession = FindObjectOfType<GameSession>();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            gamesession.LevelPassed();
            sceneloader.LoadNextScene();
        }
    }

}
