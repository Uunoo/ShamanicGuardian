using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NatureHealScriptableObject", menuName = "Scriptable Object Ability Ball/Create NatureHeal SO", order = 4)]
public class NatureHealSO : AbilityScriptableObject     //This class inherits from AbilitySO
{

    private Transform spawnPosition;
    private Vector3 direction;


    [Header("Projectile info and its Effects (Can be adjusted)")]
    public GameObject NatureHealInstance;
    //public float movementForce;

    ////Additional Effects        --------
    [Header("Heal info and its Effects (Can be adjusted)")]
    public int healAmount;
    public float healTime;  // for making a channel but probablly will not make it now (maybe for boss and its coroutines)

    ////--///----- whole heal needs to be worked out if just self casted with object or what way we do it???--------------------

    public override void Initialize(GameObject obj) //this will initialize the skill to the game object  
    {
        spawnPosition = obj.transform;
        //movementForce = 500f;
        healAmount = 10;
    }
    
    public override void Use()  //this will call the function when we wanna use the skill (Called in Ability Canvas ability)
    {
        //Instantiate the firebals
        GameObject clonedSkillPrefab = Instantiate(NatureHealInstance, spawnPosition.position, spawnPosition.rotation);

        //// Get mouse position for whereit is shot at
        //Vector3 mousePosition = Input.mousePosition;

        //mousePosition.z = Camera.main.transform.position.z * -1;

        //// Get displacement for direction
        //Vector3 displacement = Camera.main.ScreenToWorldPoint(mousePosition) - clonedSkillPrefab.transform.position;

        //direction = displacement.normalized;

        ////added for rotation------> (if ability is like triangle(or has a sprite) so it shoots in line of the direction)
        //float rotZ = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        //clonedSkillPrefab.transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + -90);

    

        //// now projectile has heal added to it                                                 
        clonedSkillPrefab.GetComponent<NatureHealBall>().healAmount = healAmount;

        ////Adds force(speed) for the gameobject/rigidbody for the direction it is shot at
        //clonedSkillPrefab.GetComponent<Rigidbody2D>().AddForce(direction * movementForce, ForceMode2D.Force);


    }
}
