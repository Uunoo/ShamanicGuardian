using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureHealBall : MonoBehaviour
{

    [HideInInspector] public int healAmount;    //// Gets damage from line (abilitySO) clonedSkillPrefab.GetComponent<ProjectileBall>().damage = damage;
    public float TimeToLive = 3f;          //added for selfDestruct  // ---> Below script for more ways 

    public PlayerDataScriptableObject playerSO;

    //do this script to enemy.??.. 

    private void OnTriggerEnter2D(Collider2D other)
    {
        //PlayerController other = other.GetComponent<PlayerController>();

        //if (other != null)
        //    other.PlayerHeal(healAmount);

        if (other.CompareTag("Player"))
        {
            playerSO.IncreaseHealth(healAmount);

        }

        Destroy(this.gameObject);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enviroment")
            Destroy(this.gameObject);

        if (collision.gameObject.tag == "Player")
        {
            playerSO.IncreaseHealth(healAmount);

        }
    }

    private void Start()
    {
        //playerController = GetComponent<PlayerController>();
        Destroy(gameObject, TimeToLive);   //added for selfDestruct  // ---> Below script for more ways 
    }



    // Update is called once per frame
    void Update()
    {

    }



}


