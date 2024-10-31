using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    public PlayerDataScriptableObject playerSO;


    [Header("Player Skill Sets")]
    public List<AbilitySetScriptableObject> Abilities = new List<AbilitySetScriptableObject>();


    [Header("Ability UI")]
    public Canvas AbilityCanvas;

    [SerializeField, Header("Player health change")]
    private int playerHealthDecreaseOnHit;

    [SerializeField, Header("Player health change")]
    public SceneController sceneController;

    //Next function  OnTriggerEnter does not belong here, it is here only for testing purposes
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            playerSO.DecreaseHealth(playerHealthDecreaseOnHit);
        }
        if (other.CompareTag("EnemyProjectile"))
        {
            playerSO.DecreaseHealth(playerHealthDecreaseOnHit);
            Debug.Log("Player take damage" + playerHealthDecreaseOnHit + playerSO.PlayerHP);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //    if(collision.gameObject.tag == "Enemy")
        //        playerHealthDecreaseOnHit =

        //     if (collision.gameObject.tag == "EnemyProjectile")
        //        playerDataScriptableObject.DecreaseHealth(amount);
        //
    }

    //public void ChangeHealth(int amount)
    //{
    //    playerSO.PlayerHP += amount;

    //    if (playerSO.PlayerHP <= 0)
    //    {
    //        gameObject.SetActive(false);
    //        Debug.Log("Player is Deadd");
    //    }
    //}


    private void Update()
    {
        if (playerSO.PlayerHP <= 0)
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(5);
            Debug.Log("Player is Dead");

        }
    }

}
