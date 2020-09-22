using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip splashMusic;
    [SerializeField] AudioClip levelMusic;
    [SerializeField] AudioClip creditsMusic;

    void Start()
    {
        print("MusicPlayer.cs");
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMasterVolume();

        int musicPlayerCount = FindObjectsOfType<MusicPlayer>().Length;
        if (musicPlayerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
    private void Update()
    {
        if(SplashMusic())
        {
            ChangeMusic(splashMusic);
        }
        if (LevelMusic())
        {
            ChangeMusic(levelMusic);
        }
        if (CreditsMusic())
        {
            ChangeMusic(creditsMusic);
        }
    }

    public void ChangeMusic(AudioClip clip)
    {
        if (audioSource.clip.name == clip.name)
            return;

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }

    bool SplashMusic()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Splash Screen" || currentScene == "Start Screen" || currentScene == "Options Screen")
            return true;
        else
            return false;
    }

    bool LevelMusic()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Level 1" || currentScene == "Level 2" || currentScene == "Level 3"|| currentScene == "Level 4" || currentScene == "Level 5" || currentScene == "Level 6"|| currentScene == "Level 7")
            return true;
        else
            return false;
    }
    bool CreditsMusic()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == "Credits")
            return true;
        else
            return false;
    }
}
