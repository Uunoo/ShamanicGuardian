using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBall : MonoBehaviour
{
    [HideInInspector]
    public int damage;    //// Gets damage from line (abilitySO) clonedSkillPrefab.GetComponent<ProjectileBall>().damage = damage;
    public float TimeToLive = 3f;          //added for selfDestruct  // ---> Below script for more ways 



 
    private void OnTriggerEnter2D(Collider2D other)
    {
     
        EnemyController ed = other.GetComponent<EnemyController>();

        if (ed != null)
            ed.EnemyTakeDamage(damage);


        Damageable d = other.GetComponent<Damageable>();

        if (d != null)
            d.TakeDamage(damage);


        Destroy(this.gameObject);
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enviroment")
            Destroy(this.gameObject);

    }

    private void Start()
    {
        Destroy(gameObject, TimeToLive);   //added for selfDestruct  // ---> Below script for more ways 

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }



    // Update is called once per frame
    void Update()
    {
        
    }



}


////------------------------------------------------------------------------------------------------------------------------------------
//////add for Projectile Self Destruct  // https://discussions.unity.com/t/destroying-projectile-prefabs-after-time/187507/4 
///// more ways-->

///// </summary>////This seems much simpler - just add this script to the bullet prefab
///// 1

//public class Lifetime : MonoBehaviour
//{
//    public float TimeToLive = 5f;
//    private void Start()
//    {
//        Destroy(gameObject, TimeToLive);
//    }
//}


//////You could also use a Co-routine, essentially the same thing but doesn’t hold up the thread in an update loop.
///// 3
//void OnAwake()
//{
//    StartCoroutine(DestroySelfAfterSeconds(float destroyTime: 5f));
//}

//Enumerator DestroySelfAfterSeconds(destroyTime)
//{
//    return new WaitForSeconds(destroyTime);
//    Destroy(gameObject);
//}

//////There is a much easier way to do this. Simple subtract time.deltatime from 5 and remove it when it is less than 0.
/////  3
//void Update()
//{
//    liveTime -= Time.deltaTime;
//    if (liveTime <= 0)
//    {
//        Destroy(this.gameObject);
//    }
//}

////-------------------------------------------------------------------------------------------------------