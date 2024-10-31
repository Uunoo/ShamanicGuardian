using System.Collections;
using System.Collections.Generic;
using UnityEngine;
////---   REMEMBER TO CHECK ENEMY STATE IF IT DOESNT WORK 
public class KnockbackEffect : MonoBehaviour
{

    private Rigidbody2D rb;
    private EnemyController enemyController;

    public float knockBackForce;
    public float knockBackTime;
    public float stunTime;
    public float slowAmount;
    public float slowTime;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyController = GetComponent<EnemyController>();
    }

    public void Knockback(Transform projectileTransform, float knockBackForce, float stunTime)
    {
        //enemyController.ChangeState(EnemyState.KnockBack); // this line for enemy states

        StartCoroutine(StunTimer(stunTime));

        Vector2 direction = (transform.position - projectileTransform.position).normalized;
        rb.velocity = direction * knockBackForce;
        Debug.Log("knockback applied.");



    }



    IEnumerator StunTimer(float stunTime)
    {
        yield return new WaitForSeconds(stunTime);
        rb.velocity = Vector2.zero;
        //enemyController.ChangeState(EnemyState.Idle)// this line for enemy states

    }


    IEnumerator SlowTimer(float slowTime)
    {
        yield return new WaitForSeconds(slowTime);
            rb.velocity = Vector2.zero;
        //enemyController.ChangeState(EnemyState.Idle)// this line for enemy states


    }


    ////Testing first
    //private bool isKnockedBack;
    //Rigidbody2D rb;
    //public void Knockback(Transform enemy)
    //{ 
    //    isKnockedBack = true;

    //    Vector2 direction = transform.position - enemy.position;
    //    rb.velocity = direction;


    //}



}
