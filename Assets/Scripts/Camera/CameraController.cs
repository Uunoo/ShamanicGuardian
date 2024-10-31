using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera vCam;

    void Awake()
    {
        // Find Cinemachine Virtual Camera
        vCam = FindObjectOfType<CinemachineVirtualCamera>();

        // Audiolistener
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Checking player and update camera following
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null && vCam != null)
        {
            vCam.Follow = player.transform;
            Debug.Log("Camera set to follow Player in new scene.");
        }
    }

    private void OnDestroy()
    {
        // Delete extra audio listeners
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}