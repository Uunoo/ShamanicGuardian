using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    [SerializeField] private AudioClip playGame;
    

    public void PlayGame()
    {
        SoundFXManager.instance.PlaySoundFXClip(playGame, transform, 0.2f);
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {

            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameIsPaused = false;
        

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void Exit()
    {
        Application.Quit();
    }

    public static void LoadScene(int sceneIndex)
    {

        SceneManager.LoadScene(sceneIndex);
    }

    //PauseMenu -> MainMenu
    public static void Restart()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();
        }
    }


}
