using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public EnemyScriptableObject EnemySO;

    public int damage = 10;
    public float projectileForce = 10f;   // CHECK THE PROJECTILE SHOOT FROM ABILITY PROJECTILES AND ENEMY RANGED 
    public float TimeToLive = 3f;          //added for selfDestruct  // ---> Below script for more ways 

    private Rigidbody2D rb;

    [SerializeField]
    private PlayerDataScriptableObject playerSO;



    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            playerSO.DecreaseHealth(damage);

        }

        if (other.CompareTag("Player"))
        {
            playerSO.DecreaseHealth(EnemySO.enemyAttackDamage);

        }


        //PlayerController ed = other.GetComponent<PlayerController>();

        ////if (ed != null)
        ////    ed.PlayerTakeDamage(damage);



        Destroy(this.gameObject);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enviroment")
            Destroy(this.gameObject);

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();   

        Destroy(gameObject, TimeToLive);   //added for selfDestruct  // ---> Below script for more ways 
    }


    private void FixedUpdate()
    {
        rb.velocity = transform.up * projectileForce;
    }


    // Update is called once per frame
    void Update()
    {

    }


}
