using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffectManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private EnemyController enemyController;
    private EnemyRangedBat enemyRangedBat;

    [Header("FIRE DamageOverTime Info")]
    public FireBallSO fireBall;
    public List<int> burnTickTimers = new List<int>();

    [Header("ICE Slow / Root info")]
    public IceWaterBallSO iceWaterBall;
    //public float slowAmount;
    //public float slowTime;

    [Header("AIR KnockBack info")]
    public AirBallSO airBall;
    //public float knockBackForce;
    //public float knockBackTime;
    public bool knockBack = false;

    [Header("LIGHTNING Stun info")]
    public LightningBallSO lightningBall;
    //public float stunTime;

    void Start()
    {
        enemyRangedBat = GetComponent<EnemyRangedBat>();
        enemyController = GetComponent<EnemyController>();
        rb = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
       // Debug.Log(knockBack);
        

    }
    ////-----------------------------------------------------------------------------------------------------------
    //// -----------------------------------------------FIRE BURN DOT-----------------------------------------
    public void ApplyBurn(int ticks)
    {
        if (burnTickTimers.Count <= 0)
        {
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());

        }
        else 
        {
            burnTickTimers.Add(ticks);
        
        }

    }

    IEnumerator Burn()
    {
        while (burnTickTimers.Count > 0)
        {
            for (int i = 0; i < burnTickTimers.Count; i++)
            {
                fireBall.DOTActive = true;
                burnTickTimers[i]--;

            }

            enemyController.enemyHealth -= fireBall.DOTdamage;  // change damage to DOTdamage
         
            Debug.Log( enemyController.enemyHealth -= fireBall.DOTdamage);

            burnTickTimers.RemoveAll(i => i == 0); // removei ( number) when i ( number) is 0

            yield return new WaitForSeconds(1);
        }
        fireBall.DOTActive = false;
    }

    ////-----------------------------------------------------------------------------------------------------------
    
    ////------------------------------------KNOCKBACK----------------------------------------------------------


    ////---   REMEMBER TO CHECK ENEMY STATE IF IT DOESNT WORK 
    public void Knockback(Transform projectileTransform, float knockBackForce, float knockBackTime)
    {
        knockBack = true;
        //enemyController.ChangeState(EnemyState.KnockBack); // this line for enemy states

        StartCoroutine(KnockStunTimer(airBall.knockBackTime));

        Vector2 direction = (transform.position - projectileTransform.position).normalized;
        rb.velocity = direction * airBall.knockBackForce;
        Debug.Log("knockback applied.");

        knockBack = false;

    }



    IEnumerator KnockStunTimer(float knockBackTime)
    {
        yield return new WaitForSeconds(airBall.knockBackTime);
        rb.velocity = Vector2.zero;
        //enemyController.ChangeState(EnemyState.Idle)// this line for enemy states

    }
    ////--------------------------------------------------------------------------------------------------------------------
    
    ////----------------------------------------Freeze/Root/Slow----------------------------------------------------------

    IEnumerator SlowTimer(float slowTime)
    {
        yield return new WaitForSeconds(slowTime);
        rb.velocity = Vector2.zero;
        //enemyController.ChangeState(EnemyState.Idle)// this line for enemy states


    }

    public void FreezeRoot(Transform projectileTransform, float StopForce, float slowTime)
    {
        StartCoroutine(FreezeStunTimer(lightningBall.stunTime));
        Vector2 direction = (transform.position - projectileTransform.position).normalized;
        rb.velocity = direction * iceWaterBall.knockBackForce;

        
        // enemyController.enemyMovement = 0
    }
    IEnumerator FreezeStunTimer(float freezeTime)
    {
        yield return new WaitForSeconds(iceWaterBall.slowTime);
        rb.velocity = Vector2.zero;
        //enemyController.ChangeState(EnemyState.Idle)// this line for enemy states

    }
    ////-----------------------------------------------------------------------------------------------------------
    
    ////---------------------------------------------Stun----------------------------------------------------------
    public void Stun()
    {
        StartCoroutine(KnockStunTimer(lightningBall.stunTime));
        //enemyController.enemymovement = 0;  
        //enemyController.enemyFirerate = 0;
    }

    IEnumerator StunTimer(float stuntimeTime)
    {
        yield return new WaitForSeconds(lightningBall.stunTime);
        rb.velocity = Vector2.zero;
        //enemyController.ChangeState(EnemyState.Idle)// this line for enemy states

    }


}
