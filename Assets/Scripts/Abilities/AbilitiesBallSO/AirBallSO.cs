using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = " AirBallScriptableObject", menuName = "Scriptable Object Ability Ball/Create  AirBall SO", order = 2)]
public class AirBallSO : AbilityScriptableObject    //This class inherits from AbilitySO
{

    private Transform spawnPosition;
    private Vector3 direction;

    [Header("Projectile info and its Effects (Can be adjusted)")]
    public GameObject AirBallInstance;
    public float movementForce;

    public int damage;   // you can change the damage to specific abilityDamage and define the value by +- resistance type = damage

    //Additional Effects      ----------- do we need slow?
    public float slowMovementSpeed;   // these two will need to be added to projectile and make additional statement to void Use()
    public float slowTime;

    // ability AIR needs    ----      pushBack/knock enemy works with float / transform? + direction?
    public float knockBackForce;
    public float knockBackTime;

    ////------------------------------------Interactable with object needs to be checked how to and where to-----------------------------------------------

    public override void Initialize(GameObject obj) //this will initialize the skill to the game object  
    {
        spawnPosition = obj.transform;
        movementForce = 750f;
        damage = 10;
        knockBackForce = 10;
        knockBackTime = 1.5f;
    }

    public override void Use()  //this will call the function when we wanna use the skill (Called in Ability Canvas ability)
    {
        //Instantiate the firebals
        GameObject clonedSkillPrefab = Instantiate(AirBallInstance, spawnPosition.position, spawnPosition.rotation);

        // Get mouse position for whereit is shot at
        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = Camera.main.transform.position.z * -1;

        // Get displacement for direction
        Vector3 displacement = Camera.main.ScreenToWorldPoint(mousePosition) - clonedSkillPrefab.transform.position;

        direction = displacement.normalized;

        //added for rotation------> (if ability is like triangle(or has a sprite) so it shoots in line of the direction)
        float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        clonedSkillPrefab.transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + -90);

        //-----------------------------<    and at part 2 added next.--->

        // now projectile has damage added to it + other needed variables
        clonedSkillPrefab.GetComponent<AirBall>().damage = damage;
        clonedSkillPrefab.GetComponent<AirBall>().knockBackForce = knockBackForce;
        clonedSkillPrefab.GetComponent<AirBall>().knockBackTime = knockBackTime;
        //Adds force(speed) for the gameobject/rigidbody for the direction it is shot at
        clonedSkillPrefab.GetComponent<Rigidbody2D>().AddForce(direction * movementForce, ForceMode2D.Force);


    }
}
