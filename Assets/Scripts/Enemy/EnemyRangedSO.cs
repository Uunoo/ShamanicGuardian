using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedSO : MonoBehaviour
{
    [Header("Enemy Scriptable Object for Enemy")]
    [SerializeField]
    public EnemyScriptableObject enemySO;

    public Transform targetPlayer;
    public float speed;
    public float rotateSpeed;
    private Rigidbody2D rb;
    public float distanceToShoot;
    public float distanceToStop;
    public Transform firingPoint;
    public float fireRate;
    private float timeToFire;
    public GameObject rangedEnemyProjectile;
    [Header("Enemy Health Amount (Dont Touch This Tralalaa)")]
    [SerializeField]
    private int enemyHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyHealth = enemySO.enemyMaxHealth;
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
        if (targetPlayer != null && Vector2.Distance(targetPlayer.position, transform.position) <= distanceToStop)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        if (timeToFire <= 0f)
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
                rb.velocity = transform.up * speed;
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



}
