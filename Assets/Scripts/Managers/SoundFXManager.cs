using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundFXManager : MonoBehaviour
{

    public static SoundFXManager instance; //Creating a singleton pattern for easy access from anywhere

    [SerializeField] private AudioSource SoundFXObject;

    [SerializeField] private AudioClip shootFireEffect;
    [SerializeField] private AudioClip shootLightningEffect;
    [SerializeField] private AudioClip shootAirEffect;
    [SerializeField] private AudioClip shootWaterEffect;
    [SerializeField] private AudioClip shootHealEffect;
    [SerializeField] private AudioClip playerMovementEffect;
    [SerializeField] private AudioClip enemyOneMovementEffect;
    //[SerializeField] private AudioClip PlayerTakeDamage;
    [SerializeField] private AudioClip enemyAttackEffect;
    //[SerializeField] private AudioClip enemyTwoMovementEffect;
    [SerializeField] private AudioClip enemyTakeDamageEffect;

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
    }


    public void PlaySoundFXClip(AudioClip audioClip, Transform spawnTransform, float volume) //Called in need of a short sound effect e.g. player getting hit
    {
        AudioSource audioSource = Instantiate(SoundFXObject, spawnTransform.position, Quaternion.identity); // The audio source only appears when it is needed

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength); //The audio source is destroyed when it is no longer needed
    }
}
