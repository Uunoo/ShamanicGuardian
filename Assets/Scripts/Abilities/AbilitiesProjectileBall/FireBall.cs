using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    [HideInInspector] public int damage;    //// Gets damage from line (abilitySO) clonedSkillPrefab.GetComponent<ProjectileBall>().damage = damage;
    [HideInInspector] public int DOTdamage;
    [HideInInspector] public bool DOTActive;
    [HideInInspector] public float DOTTime;
    [HideInInspector] public int DOTTickMultiplier;

    public float TimeToLive = 3f;          //added for selfDestruct  // ---> Below script for more ways 

    private EnemyEffectManager enemyEffectManager;
    public List<int> DOTTicks = new List<int>();
    //[SerializeField] StatusEffectManager effects;

    private EnemyController enemyController;
    private EnemyRanged enemyRanged;
    private EnemyMelee enemyMelee;

    public bool FireBlockActivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
   
        //-------------Damage to enemy Controller
        EnemyController ed = other.GetComponent<EnemyController>();

        if (ed != null)
        {
            ed.EnemyTakeDamage(damage);
            Destroy(this.gameObject);

            //StartCoroutine(DamageOverTime());
        }

        // other(thing which we collide with) GetComponent from enemy(Script)
        if (other.GetComponent<EnemyEffectManager>() != null) // if this component is not null then get the apply burn below 
        {
            other.GetComponent<EnemyEffectManager>().ApplyBurn(DOTTickMultiplier);
            Destroy(this.gameObject);
        }


        Damageable d = other.GetComponent<Damageable>();

        if (d != null)
        {
            d.TakeDamage(damage);
            Destroy(this.gameObject);
        }

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

        //if (d != null)
        //StartCoroutine DOTDam;

        //Destroy(this.gameObject);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enviroment")
            Destroy(this.gameObject);

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



}

//public void ApplyBurn(int ticks)
//{
//    if (DOTTicks.Count > 0)
//    {
//        DOTTicks.Add(ticks);
//        StartCoroutine(Burn());

//    }
//    else
//    {
//        DOTTicks.Add(ticks);

//    }

//}

//IEnumerator Burn()
//{
//    while (DOTTicks.Count > 0)
//    {
//        for (int i = 0; i < DOTTicks.Count; i++)
//        {

//            DOTTicks[i]--;

//        }

//        enemyController.enemyHealth -= DOTdamage;  // change damage to DOTdamage

//        Debug.Log(  "Damage taken:" +DOTdamage);

//        DOTTicks.RemoveAll(i => i == 0);

//        yield return new WaitForSeconds(1);
//    }

//}















//public void ApplyBurn(int DOTTicks)
//{ 


//}
//public IEnumerator DamageOverTime()
//{
//    float damageTickTime = DOTTime;
//    //DOTActive = false;

//    if (DOTActive == true) 
//    {
//        for (int i = 0; i < DOTdamage; i++)
//        {



//        }

//    }


//    yield return null;
//}



// from SO video
//private void OnTriggerEnter2D(Collider2D other)
//{
//    if (!other.CompareTag("Enemy")) return;

//    var effectable = other.GetComponent<IEffectable>();

//    if (effectable != null)
//    {
//        effectable.ApplyEffect(effects);
//    }
//}