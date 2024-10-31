using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

// https://www.youtube.com/watch?v=k85ocpVScO4   part 1
// https://www.youtube.com/watch?v=ydPMIh9leSc part 2

[CreateAssetMenu(fileName = "FireBallScriptableObject", menuName = "Scriptable Object Ability Ball/Create FireBall SO", order = 0)]
public class FireBallSO : AbilityScriptableObject  //This class inherits from AbilitySO
{
    private Transform spawnPosition;
    private Vector3 direction;

    [Header("Projectile info and its Effects (Can be adjusted)")]
    public GameObject fireBallInstance;
    public float movementForce;

    public int damage;   // you can change the damage to specific abilityDamage and define the value by +- resistance type = damage

    //Additional Effects
    [Header("DamageOverTime effect")]
    //Coroutine DamageOverTime;
    public int DOTdamage;
    public int DOTTickMultiplier; 
    public bool DOTActive;        //Damage over time activated
    //public float DOTTime;          //Damage over time time
    ////------------------------------------Interactable with object needs to be checked how to and where to-----------------------------------------------

    public bool FireBlockActivate;

    public override void Initialize(GameObject obj) //this will initialize the skill to the game object  
    {
        spawnPosition = obj.transform;
        movementForce = 750f;
        damage = 10;
         //Damage over time time
        DOTActive = false;        //Damage over time activated
        
        DOTTickMultiplier = 3;
        //DOTTime = 5;   
        //DOTdamage = 5;      //Damage for DOT

         FireBlockActivate = false;
    }

    public override void Use() //this will call the function when we wanna use the skill (Called in Ability Canvas ability)
    {
        //Instantiate the firebals
        GameObject clonedSkillPrefab = Instantiate(fireBallInstance, spawnPosition.position, spawnPosition.rotation);

        // Get mouse position for where it is shot at
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = Camera.main.transform.position.z * -1; 

        // Get displacement for direction
        Vector3 displacement = Camera.main.ScreenToWorldPoint(mousePosition) - clonedSkillPrefab.transform.position;

        direction = displacement.normalized;

        //added for rotation------> (if ability is like triangle(or has a sprite) so it shoots in line of the direction)
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        clonedSkillPrefab.transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + -90);

        //-----------------------------<    and at part 2 added next.--->

        // now projectile has damage added to it (Get the component script ProjectileBall) 
        clonedSkillPrefab.GetComponent<FireBall>().damage = damage;
        clonedSkillPrefab.GetComponent<FireBall>().DOTTickMultiplier = DOTTickMultiplier;
        clonedSkillPrefab.GetComponent<FireBall>().DOTActive = DOTActive;
        // clonedSkillPrefab.GetComponent<FireBall>().DOTTime = DOTTime;
        //clonedSkillPrefab.GetComponent<FireBall>().DOTdamage = DOTdamage;


        clonedSkillPrefab.GetComponent<FireBall>().FireBlockActivate = FireBlockActivate;
        //Adds force(speed) for the gameobject/rigidbody for the direction it is shot at
        clonedSkillPrefab.GetComponent<Rigidbody2D>().AddForce(direction * movementForce, ForceMode2D.Force);
        
       




    }
}
