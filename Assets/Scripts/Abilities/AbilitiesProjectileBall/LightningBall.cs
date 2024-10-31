using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningBall : MonoBehaviour
{

    [HideInInspector] public int damage;    //// Gets damage from line (abilitySO) clonedSkillPrefab.GetComponent<ProjectileBall>().damage = damage;
    public float TimeToLive = 3f;          //added for selfDestruct  // ---> Below script for more ways 

    private EnemyController enemyController;
    private EnemyEffectManager enemyEffectManager;

    private EnemyRanged enemyRanged;
    private EnemyMelee enemyMelee;

    private void OnTriggerEnter2D(Collider2D other)
    {

        EnemyController ed = other.GetComponent<EnemyController>();

        if (ed != null)
        {
            ed.EnemyTakeDamage(damage);
            Destroy(this.gameObject);
        }


            //Damageable d = other.GetComponent<Damageable>();

            //if (d != null)
            //    d.TakeDamage(damage);

        EnemyRanged eR = other.GetComponent<EnemyRanged>();
        if (eR != null)
        {
            eR.EnemyTakeDamage(damage);
            Destroy(this.gameObject);
        }

        EnemyMelee eM = other.GetComponent<EnemyMelee>();

        if (eM != null)
        {
            eM.EnemyTakeDamage(damage);
            Destroy(this.gameObject);
        }

        if (other.GetComponent<EnemyEffectManager>() != null)
        {
            other.GetComponent<EnemyEffectManager>().Stun();
            Destroy(this.gameObject);
        }

        //Destroy(this.gameObject);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enviroment")
            Destroy(this.gameObject);

        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        ////Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        //if (collision.gameObject.tag == "Player" )
        //{ Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());  }

    }

    private void Start()
    {
        enemyEffectManager = GetComponent<EnemyEffectManager>();
        enemyController = GetComponent<EnemyController>();
        enemyMelee = GetComponent<EnemyMelee>();
        enemyRanged = GetComponent<EnemyRanged>();

        Destroy(gameObject, TimeToLive);   //added for selfDestruct  // ---> Below script for more ways 

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }



    // Update is called once per frame
    void Update()
    {

    }



}


