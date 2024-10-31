using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    private string spawnPointTag;
    private bool hasSpawned = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Asetetaan tagi, jota etsit‰‰n seuraavassa kohtauksessa
    public void SetSpawnPoint(string tag)
    {
        if (!string.IsNullOrEmpty(tag)) // Tarkista, ett‰ tag ei ole tyhj‰ tai null
        {
            spawnPointTag = tag;
            hasSpawned = false; // Asetetaan uudelleen spawnattavaksi
        }
        else
        {
            Debug.LogWarning("SetSpawnPoint called with an empty or null tag!");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!hasSpawned && !string.IsNullOrEmpty(spawnPointTag))
        {
            GameObject spawnPoint = GameObject.FindWithTag(spawnPointTag);
            if (spawnPoint != null)
            {
                GameObject player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    player.transform.position = spawnPoint.transform.position;
                    hasSpawned = true; // No New Spawn
                }
            }
            else
            {
                Debug.LogWarning("Spawn point with tag " + spawnPointTag + " not found in scene " + scene.name);
            }
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}

