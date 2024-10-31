using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{

    [Header("Enemy Scriptable Object for Enemy")]
    [SerializeField]
    private EnemyScriptableObject enemyScriptableObject;

    public Transform targetPlayer;
    public float speed;
    public float rotateSpeed;
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


    private EnemyState enemyState;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = enemyScriptableObject.enemyMaxHealth;
    }


    void Update()
    {
        if (!targetPlayer)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
        if (Vector2.Distance(targetPlayer.position, transform.position) <= distanceToHit)
        {
            MeleeAttack();
        }

        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Object/Enemy Destroyed");
        }

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


    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            targetPlayer = (GameObject.FindGameObjectWithTag("Player").transform);
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetPlayerDirection = targetPlayer.position - transform.position;
        float angle = Mathf.Atan2(targetPlayerDirection.y, targetPlayerDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            targetPlayer = null;
        }
        else if (other.gameObject.CompareTag("EnemyProjectile"))
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
    public enum EnemyState
    {
        GetTarget,
        RotateTowardsTarget,
        MeleeAttack,
        Root,
        Stun,
        KnockBack

    }
}
