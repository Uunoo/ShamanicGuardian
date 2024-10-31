using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using static UnityEngine.RuleTile.TilingRuleOutput;
public class EnemyController : MonoBehaviour
{
    [Header("Components")]
    Rigidbody2D rb;

    [Header("Player to follow")]
    [SerializeField]
    private GameObject player;

    [Header("Enemy Scriptable Object for Enemy")]
    [SerializeField]
    private EnemyScriptableObject enemyScriptableObject;

    [Header("Enemy Health Amount (Dont Touch This Tralalaa)")]
    [SerializeField]
    public int enemyHealth;

    [Header("Enemy Audio sources")]
    [SerializeField]
    private AudioSource enemyMovement;
    [SerializeField]
    private AudioSource enemyAttack;
    [SerializeField]
    private AudioSource enemyTakeDamage;

    [Header("Enemy Animations")]
    private Animator enemyAnimator;



    ////Below for possible Awake on Animations (delete if we do it another way)
    //private void Awake()
    //{
    //    //enemyAnimator = GetComponent<Animator>();
    //    //enemyIdleAnimation =
    //    //enemyMoveAnimation =
    //    //enemyAttackAnimation =
    //}



    //void Chase()
    //{
    //    GameObject.FindGameObjectWithTag("Player");
    //    enemyScriptableObject.enemyPlayerDistance = Vector2.Distance(transform.position, player.transform.position);
    //    Vector2 direction = player.transform.position - transform.position;
    //    direction.Normalize();
    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


    //    if (enemyScriptableObject.enemyPlayerDistance < enemyScriptableObject.enemyAggroRange) //Change number if you think otherwise is better, so chasing would start before or later
    //    {
    //        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyScriptableObject.enemyMovementSpeed * Time.deltaTime);
    //        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    //    }


    //    /////// OLD version for previous way of using scripts and SO:s
    //    //enemyScriptableObject.enemyAttackScriptableObject.enemyPlayerDistance = Vector2.Distance(transform.position, player.transform.position);
    //    //Vector2 direction = player.transform.position - transform.position;
    //    //direction.Normalize();
    //    //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


    //    //if (enemyScriptableObject.enemyAttackScriptableObject.enemyPlayerDistance < enemyScriptableObject.enemyAttackScriptableObject.enemyAggroRange) //Change number if you think otherwise is better, so chasing would start before or later
    //    //{
    //    //    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyScriptableObject.enemyRankScriptableObject.enemyMovementSpeed * Time.deltaTime);
    //    //    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    //    //}



    //}


    void EnemyAttack()
    {
        // You can use attack type SO (get the variables) with example = enemyScrptableObject.enemyAttackScriptableObject.enemyAttackDamage; or enemyScrptableObject.enemyAttackScriptableObject.enemyAttackRange; 
        // for range projectile  enemySO.EnemyAttackScriptableObject.enemyProjectile

        //also needs audiosources  and probably animation if it is made

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

    void Start()
    {
        enemyHealth = enemyScriptableObject.enemyMaxHealth;
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CameraConfiner")
        {
            Destroy(this.gameObject);
            Debug.Log("Enemy out of map.. DESTROYED");
        }
    }



    void Update()
    {
   
        //Chase();
        //EnemyAttack();
        //EnemyTakeDamage();


        if (enemyHealth <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Object/Enemy Destroyed");
        }

    }


}


    ////private void OnEnable()
    ////{
    ////    enemyHealth = enemyScriptableObject.enemyMaxHealth;

    ////    if (enemyHealthChangeEvent == null)
    ////    {
    ////        enemyHealthChangeEvent = new UnityEvent<int>();
    ////    }

    ////    enemyHealthChangeEvent.AddListener(ChangeSliderValue);

    ////}

    ////private void OnDisable()
    ////{
    ////    enemyHealthChangeEvent.RemoveListener(ChangeSliderValue);
    ////}

    ////private void Start()
    ////{
    ////    enemyHealth = enemyScriptableObject.enemyMaxHealth;
    ////    ChangeSliderValue(enemyScriptableObject.enemyMaxHealth);
    ////}


    ////public void ChangeSliderValue(int amount)
    ////{
    ////    enemyHealthBar.value = ConvertIntToFloatDecimal(amount);
    ////}

    ////private float ConvertIntToFloatDecimal(int amount)
    ////{
    ////    return (float)amount / enemyScriptableObject.enemyMaxHealth;
    ////}
    ////public void EnemyDecreaseHealth(int amount)
    ////{
    ////    enemyHealth -= amount;
    ////    enemyHealthChangeEvent.Invoke(enemyHealth);

    ////    if (enemyHealth <= 0)
    ////        Destroy(this.gameObject);
    ////}


//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.Scripting.APIUpdating;
//using UnityEngine.UI;
//using static UnityEngine.RuleTile.TilingRuleOutput;
//public class EnemyController : MonoBehaviour, IEffectable
//{
//    [Header("Components")]
//    Rigidbody2D rb;

//    [Header("Player to follow")]
//    [SerializeField]
//    private GameObject player;

//    [Header("Enemy Scriptable Object for Enemy")]
//    [SerializeField]
//    private EnemyScriptableObject enemyScriptableObject;
//    [Header("Status Effects data for Enemy")]
//    [SerializeField]
//    private StatusEffectsManagerSO data;
//    [Header("Enemy Health Amount (Dont Touch This Tralalaa)")]
//    [SerializeField]
//    private int enemyHealth;

//    [Header("Enemy Audio sources")]
//    [SerializeField]
//    private AudioSource enemyMovement;
//    [SerializeField]
//    private AudioSource enemyAttack;
//    [SerializeField]
//    private AudioSource enemyTakeDamage;

//    [Header("Enemy Animations")]
//    private Animator enemyAnimator;

//    //[SerializeField] private Slider enemyHealthBar;
//    //[System.NonSerialized] public UnityEvent<int> enemyHealthChangeEvent;


//    ////Below for possible Awake on Animations (delete if we do it another way)
//    //private void Awake()
//    //{
//    //    //enemyAnimator = GetComponent<Animator>();
//    //    //enemyIdleAnimation =
//    //    //enemyMoveAnimation =
//    //    //enemyAttackAnimation =
//    //}



//    void Chase()
//    {
//        GameObject.FindGameObjectWithTag("Player");
//        enemyScriptableObject.enemyPlayerDistance = Vector2.Distance(transform.position, player.transform.position);
//        Vector2 direction = player.transform.position - transform.position;
//        direction.Normalize();
//        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


//        if (enemyScriptableObject.enemyPlayerDistance < enemyScriptableObject.enemyAggroRange) //Change number if you think otherwise is better, so chasing would start before or later
//        {
//            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyScriptableObject.enemyMovementSpeed * Time.deltaTime);
//            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
//        }


//        /////// OLD version for previous way of using scripts and SO:s
//        //enemyScriptableObject.enemyAttackScriptableObject.enemyPlayerDistance = Vector2.Distance(transform.position, player.transform.position);
//        //Vector2 direction = player.transform.position - transform.position;
//        //direction.Normalize();
//        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


//        //if (enemyScriptableObject.enemyAttackScriptableObject.enemyPlayerDistance < enemyScriptableObject.enemyAttackScriptableObject.enemyAggroRange) //Change number if you think otherwise is better, so chasing would start before or later
//        //{
//        //    transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, enemyScriptableObject.enemyRankScriptableObject.enemyMovementSpeed * Time.deltaTime);
//        //    transform.rotation = Quaternion.Euler(Vector3.forward * angle);
//        //}



//    }


//    void EnemyAttack()
//    {
//        // You can use attack type SO (get the variables) with example = enemyScrptableObject.enemyAttackScriptableObject.enemyAttackDamage; or enemyScrptableObject.enemyAttackScriptableObject.enemyAttackRange; 
//        // for range projectile  enemySO.EnemyAttackScriptableObject.enemyProjectile

//        //also needs audiosources  and probably animation if it is made

//    }

//    public void EnemyTakeDamage(int damage)
//    {
//        enemyHealth -= damage;

//        Debug.Log(this.gameObject.name + "Damage taken:" + damage);

//        if (enemyHealth <= 0)
//        {
//            Destroy(this.gameObject);
//            Debug.Log("Object/Enemy Destroyed");
//        }

//        //needs audiosources  and probably animation if it is made

//    }

//    void Start()
//    {
//        enemyHealth = enemyScriptableObject.enemyMaxHealth;

//    }



//    void Update()
//    {

//        Chase();
//        EnemyAttack();
//        //EnemyTakeDamage();

//        if (data != null) HandleEffect();


//    }

//    private float currentMoveSpeed;
//    void HandleMove()
//    {
//        //var currentMoveSpeed = data == null? moveSpeed :  movespeed / data.MovementPenalty; // can use + or - for counting speed     
//        //// Moved this into applyeffect
//    }


//    private GameObject effectParticles;

//    public void ApplyEffect(StatusEffectsManagerSO data)
//    {
//        RemoveEffect();
//        this.data = data;

//        currentMoveSpeed = currentMoveSpeed / data.MovementPenalty;

//        effectParticles = Instantiate(data.EffectParticles, transform);
//    }

//    private float currentEffectTime = 0f;
//    private float nextTickTime = 0f;

//    public void RemoveEffect()
//    {
//        data = null;
//        currentEffectTime = 0f;
//        nextTickTime = 0f;

//        currentMoveSpeed = moveSpeed;

//        if (effectParticles != null) Destroy(effectParticles);

//    }

//    public void HandleEffect()
//    {
//        currentEffectTime += Time.deltaTime;

//        if (currentEffectTime >= data.Lifetime) RemoveEffect();

//        if (data == null) return;

//        if (data.DOTAmount != 0 && currentEffectTime > nextTickTime)
//        {
//            nextTickTime += data.TickSpeed;
//            enemyHealth -= data.DOTAmount;

//            enemyHealth = Mathf.Clamp(enemyHealth, 0, enemyScriptableObject.enemyMaxHealth);

//        }

//    }