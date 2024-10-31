using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeWeapon : MonoBehaviour
{
    public EnemyMelee enemyMelee;
    public EnemyScriptableObject EnemySO;

    public int damage = 10;
    public float projectileForce = 10f;   // CHECK THE PROJECTILE SHOOT FROM ABILITY PROJECTILES AND ENEMY RANGED 
    public float TimeToLive = 1f;          //added for selfDestruct  // ---> Below script for more ways 

    private Rigidbody2D rb;

    [SerializeField]
    private PlayerDataScriptableObject playerSO;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerSO.DecreaseHealth(damage);

        }

        if (collision.CompareTag("Player"))
        {
            playerSO.DecreaseHealth(EnemySO.enemyAttackDamage);

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyMelee = GetComponent<EnemyMelee>();
        Destroy(gameObject, TimeToLive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
