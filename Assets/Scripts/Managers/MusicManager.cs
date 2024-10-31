using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public static MusicManager instance;

    [SerializeField] private AudioSource MusicObject;

    [SerializeField] private AudioClip MainMenuMusic;
    [SerializeField] private AudioClip pauseMenuMusic;
    [SerializeField] private AudioClip FirstLevelMusic;
    [SerializeField] private AudioClip FirstLevelWindEffect;
    [SerializeField] private AudioClip WinScreenMusic;
    [SerializeField] private AudioClip LoseScreenMusic;

    private AudioClip currentMusicClip; // Tracks the current playing music

    private void Awake()
    {
        // Singleton setup
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void Start()
    {
        PlaySceneMusic(SceneManager.GetActiveScene().name); 
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlaySceneMusic(scene.name); 
    }

    private void PlaySceneMusic(string sceneName)
    {
        AudioClip newMusicClip = null;

        // Play correct music based on the scene name
        switch (sceneName)
        {
            case "MainMenu":
                newMusicClip = MainMenuMusic;
                break;
            case "Level1":
                newMusicClip = FirstLevelMusic;
                break;
            case "Level2":
                newMusicClip = FirstLevelMusic; 
                break;
            case "Level3":
                newMusicClip = FirstLevelMusic;
                break;
            case "WinScreen":
                newMusicClip = WinScreenMusic;
                break;
            case "GameOver":
                newMusicClip = LoseScreenMusic;
                break;
        }

        // Only change the music if the new clip is different from the current one
        if (newMusicClip != currentMusicClip)
        {
            PlayMusicClip(newMusicClip);
            currentMusicClip = newMusicClip;
        }
    }

    public void PlayMusicClip(AudioClip musicClip)
    {
        if (MusicObject.isPlaying) MusicObject.Stop(); // Stop any currently playing music
        MusicObject.clip = musicClip;
        MusicObject.loop = true;
        MusicObject.Play();
    }
}