using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName ="EnemyScriptableObject", menuName = "Scriptable Object Enemy/Create Enemy SO")]
public class EnemyScriptableObject : ScriptableObject
{

    public string Description;
    [Header("Enemy Rank Description")]
    public string RankDescription;

    // public EnemyAttackScriptableObject enemyAttackScriptableObject;    // Makes a dragdrop slot for EnemyAttackSO
    [Header("Attack Type Description")]
    public string AttackTypeDescription;
    [Header("Attack Damage for enemy")]
    public int enemyAttackDamage;
    [Header("Attack Speed for enemy attacks")]
    public float enemyAttackSpeed;                   //  attackSpeed can be made fast depending on EnemyRank


    [Header("Attack Range Value for enemy attack distance")]
    public float enemyAttackRange;
    [Header("Aggro Range Value for enemy aggro distance")]
    public float enemyAggroRange;
    [Header("Shows players distance from enemy")]
    public float enemyPlayerDistance;

    //we can try to attach enemy projectiles over here
    [Header("Projectile GameObject for Ranged enemy")]
    public GameObject enemyProjectile;

    // public EnemyRankScriptableObject enemyRankScriptableObject;   // Makes a dragdrop slot for EnemyRankSO
    [Header("Enemy Movement Speed")]
    public float enemyMovementSpeed;
    [Header("Enemy MAX Health Amount")]
    public int enemyMaxHealth;




    //[Header("Enemy Health Amount")]
    //public int enemyHealth;



    //public GameObject enemyEnemy;
    //public static Action<int> OnEnemyHit;
    //[System.NonSerialized] public UnityEvent<int> enemyHealthChangeEvent;

    //private void OnEnable()
    //{
    //    enemyHealth = enemyMaxHealth;
    //    if (enemyHealthChangeEvent == null)
    //    {
    //        enemyHealthChangeEvent = new UnityEvent<int>();
    //    }
        
    //}

    //public void EnemyDecreaseHealth(int amount)
    //{
    //    enemyHealth -= amount;
    //    enemyHealthChangeEvent.Invoke(enemyHealth);


    //}







    ////below is for Possible resistances for different elements (use int or other?)
    //public int resistanceFire
    //public int resistanceWaterIce
    //public int resistanceAir
    //public int resistanceLightning




    ////Below testing for Functions and Execution Order
    ////https://discussions.unity.com/t/scriptableobject-behaviour-discussion-how-scriptable-objects-work/708570
    ///

    //private void Awake()
    //{
    //    Debug.Log("Awake");
    //}
    //private void OnEnable()
    //{
    //    Debug.Log("OnEnable");
    //}
    //private void OnDisable()
    //{
    //    Debug.Log("OnDestroy");
    //}
    //private void OnDestroy()
    //{
    //    Debug.Log("OnDestroy");
    //}
    //private void OnValidate()
    //{
    //    Debug.Log("OnValidate");
    //}


}
