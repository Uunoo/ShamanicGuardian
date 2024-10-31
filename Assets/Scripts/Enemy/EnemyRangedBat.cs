using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedBat : MonoBehaviour
{
    [Header("Enemy Scriptable Object for Enemy")]
    [SerializeField] private EnemyScriptableObject enemyScriptableObject;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public BoxCollider2D boxCollider2D;
    public Transform targetPlayer;
    public float speed;
    public float rotateSpeed;

    public float distanceToShoot;
    public float distanceToStop;
    public Transform firingPoint;
    public float fireRate;
    private float timeToFire;
    public GameObject rangedEnemyProjectile;
    [Header("Enemy Health Amount (Dont Touch This Tralalaa)")]
    [SerializeField]
    private int enemyHealth;

    private EnemyState enemyState;
    public float distanceToHit;
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
        //else
        //{
        //    RotateTowardsTarget();
        //}
        if (targetPlayer != null && Vector2.Distance(targetPlayer.position, transform.position) <= distanceToStop)
        {
            Shoot();
        }

        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Object/Enemy Destroyed");
        }

    }
    private void Shoot()
    {
        if (timeToFire <= 0f )//&& Vector2.Distance(targetPlayer.position, transform.position) <= distanceToHit)
        {
            Instantiate(rangedEnemyProjectile, firingPoint.position, firingPoint.rotation);
            Debug.Log("Shoot");
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        if (targetPlayer != null)
            if (Vector2.Distance(targetPlayer.position, transform.position) >= distanceToShoot)
            {
                //rb.velocity = transform.up * speed; // Move towards the player
                //Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
                transform.position =  Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }


    }

    private void Chase()
    {
        if (targetPlayer != null)
            if (Vector2.Distance(targetPlayer.position, transform.position) >= distanceToShoot)
            {
                //rb.velocity = transform.up * speed; // Move towards the player
                //Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
                transform.position = Vector2.MoveTowards(transform.position, targetPlayer.position, speed * Time.deltaTime);
            }
            else
            {
                rb.velocity = Vector2.zero;
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
        Shoot,
        Root,
        Stun,
        KnockBack

    }
}
