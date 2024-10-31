using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class EnemyMeleeBat : MonoBehaviour
{

    [Header("Enemy Scriptable Object for Enemy")]
    [SerializeField]
    private EnemyScriptableObject enemyScriptableObject;

    public Transform targetPlayer;
    public float speed;
   // public float rotateSpeed;
    private Rigidbody2D rb;
    public float distanceToHit;
    public float distanceToStop;
    public Transform attackPoint;
    public float attackRate;
    private float timeToAttack;
    public GameObject meleeDamage;
    private float distanceToPlayer;
  
    [Header("Enemy Health Amount (Dont Touch This Tralalaa)")]
    [SerializeField]
    private int enemyHealth;

    private EnemyEffectManager enemyEffectManager;

    [Header("Enemy State Active)")]
    [SerializeField] private EnemyStateMeleeBat enemyStateMeleeBat;
    [SerializeField] private Animator animationMeleeBat;

    private bool isChasing;
    public CircleCollider2D circleCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = enemyScriptableObject.enemyMaxHealth;
        enemyEffectManager = GetComponent<EnemyEffectManager>();
        animationMeleeBat = GetComponent<Animator>();
        //circleCollider = GetComponent<CircleCollider2D>();
        ChangeState(EnemyStateMeleeBat.Idle);
        GetTarget();
    }


    void Update()
    {
        Chase();
        if (isChasing == true)
        {
            Vector2 direction = (targetPlayer.position - transform.position).normalized;
            rb.velocity = direction * speed;
        }

        //Debug.Log("Enemy State BAT: " + enemyStateMeleeBat);

        if (enemyStateMeleeBat == EnemyStateMeleeBat.Chase)
        {
            //Vector2 direction = (targetPlayer.position - transform.position).normalized;
            //rb.velocity = direction * speed;
        
        }

        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Object/Enemy Destroyed");
        }

        //if (enemyStateMeleeBat == EnemyStateMeleeBat.Idle)
        //{
        //    if (!targetPlayer && enemyStateMeleeBat == EnemyStateMeleeBat.GetTarget)
        //    {

        //        GetTarget();
        //        //ChangeState(EnemyStateMelee.Chase);

        //    }
        //    else if (enemyStateMeleeBat == EnemyStateMeleeBat.RotateTowardsTarget)
        //    {
        //        RotateTowardsTarget();

        //    }
        //    if (Vector2.Distance(targetPlayer.position, transform.position) <= distanceToHit && enemyStateMeleeBat == EnemyStateMeleeBat.MeleeAttack)
        //    {
        //        MeleeAttack();

        //        //    }

       
        //}

    }
    private void MeleeAttack()
    {
        
        if (timeToAttack <= 0f && Vector2.Distance(targetPlayer.position, transform.position) <= distanceToHit)
        {
            GameObject meleeInstance = Instantiate(meleeDamage, attackPoint.position, attackPoint.rotation);
            Debug.Log("Meleeattack");

            Destroy(meleeInstance, 0.5f); // Destroy the melee attack object after 0.5 seconds

            timeToAttack = attackRate; // Reset attack cooldown

        }
        else
        {
            timeToAttack -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        //if (enemyStateMeleeBat == EnemyStateMeleeBat.Chase)
        //{
        //    Chase();
        //}
        if (targetPlayer != null)
        {
            float distanceToPlayer = Vector2.Distance(targetPlayer.position, transform.position);

            if (distanceToPlayer > distanceToHit && distanceToPlayer >= distanceToStop)
            {
                rb.velocity = transform.up * speed; // Move towards the player
            }
            else
            {
                rb.velocity = Vector2.zero; // Stop moving if within melee range
            }
        }
    }

    private void Chase()
    {
        if (targetPlayer != null)
        {
           
            float distanceToPlayer = Vector2.Distance(targetPlayer.position, transform.position);

            if (distanceToPlayer > distanceToHit && distanceToPlayer >= distanceToStop)
            {
                //rb.velocity = transform.up * speed; // Move towards the player
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
            }
            else
            {
                rb.velocity = Vector2.zero; // Stop moving if within melee range
            }
        }
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            targetPlayer = (GameObject.FindGameObjectWithTag("Player").transform);
            
        }
    }

    //private void RotateTowardsTarget()
    //{
        
    //    Vector2 targetPlayerDirection = targetPlayer.position - transform.position;
    //    float angle = Mathf.Atan2(targetPlayerDirection.y, targetPlayerDirection.x) * Mathf.Rad2Deg - 90f;
    //    Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
    //    transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);

    //}

    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    Destroy(other.gameObject);
        //    targetPlayer = null;
        //}
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }


    public void EnemyTakeDamage(int damage)
    {
        enemyHealth -= damage;

        Debug.Log(this.gameObject.name + "Damage taken:" + damage);

        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Object/Enemy Destroyed");
        }

        //needs audiosources  and probably animation if it is made

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (targetPlayer == null)
            {
                targetPlayer = collision.transform;
            }

            isChasing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.velocity = Vector2.zero;
            isChasing = false;
        }
    }

    




    void ChangeState(EnemyStateMeleeBat newState)
    {
        ////Exit the current animation
        //if (enemyStateMeleeBat == EnemyStateMeleeBat.Idle)
        //    animationMeleeBat.SetBool("bataniamtion", false);
        //else if (enemyStateMeleeBat == EnemyStateMeleeBat.Chase)
        //    animationMeleeBat.SetBool("bataniamtion", false);

        ////Update current state
        //enemyStateMeleeBat = newState;

        ////Update new animation
        //if (enemyStateMeleeBat == EnemyStateMeleeBat.Idle)
        //    animationMeleeBat.SetBool("bataniamtion", false);
        //else if (enemyStateMeleeBat == EnemyStateMeleeBat.Chase)
        //    animationMeleeBat.SetBool("bataniamtion", false);

    }
}


public enum EnemyStateMeleeBat
{
    Idle,
    Chase,
    MeleeAttack,
    Root,
    Stun,
    KnockBack

}