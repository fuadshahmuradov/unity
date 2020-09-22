using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] AudioClip winSound;
    [SerializeField] AudioClip loseSound;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;
    bool levelLost = false;

    private void Start()
    {
        print("LevelController.cs");
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition() 
    {
        if(!levelLost)
        {
            winLabel.SetActive(true);
            GetComponent<AudioSource>().PlayOneShot(winSound);
            yield return new WaitForSeconds(waitToLoad);
            PlayerPrefsController.SetMaxLevel(PlayerPrefsController.GetMaxLevel() + 1);
            FindObjectOfType<LevelLoader>().LoadNextScene();
        }
        
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        levelLost = true;
        GetComponent<AudioSource>().PlayOneShot(loseSound);
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
