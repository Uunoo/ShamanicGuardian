using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{


    public GameObject Player;
    public GameObject Managers;
    //public GameObject Camera;
    public GameObject Canvas;
    public GameObject spawnPoint1To2;
    public GameObject spawnPoint1To3;
    public GameObject spawnPoint2To1;
    public GameObject spawnPoint3To1;
    public GameObject spawningPoint2To1;
    public GameObject spawningPoint1To2;
    public GameObject spawningPoint3To1;
    public GameObject spawningPoint1To3;




    private bool isTransitioning = false;

    private void Awake()
    {
        if (FindObjectsOfType<PlayerSpawner>().Length > 1)
        {
            Destroy(gameObject);
            Destroy(Managers.gameObject);
            Destroy(Canvas.gameObject);
            //Destroy(Camera.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Managers.gameObject);
        DontDestroyOnLoad(Canvas.gameObject);
        //DontDestroyOnLoad(Camera.gameObject);
        
    }

    // Scene Changing
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTransitioning) return;

        if (collision.CompareTag("1ToScene2"))
        {
            SpawnManager.Instance.SetSpawnPoint("Spawn2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);


        }
        else if (collision.CompareTag("2ToScene1"))
        {
            SpawnManager.Instance.SetSpawnPoint("Spawn1-2");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.CompareTag("1ToScene3"))
        {
            SpawnManager.Instance.SetSpawnPoint("Spawn3");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.CompareTag("3ToScene1"))
        {
            SpawnManager.Instance.SetSpawnPoint("Spawn1-3");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }





}
