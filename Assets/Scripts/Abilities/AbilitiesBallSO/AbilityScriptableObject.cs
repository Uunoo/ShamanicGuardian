using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[CreateAssetMenu(fileName = "AbilityScriptableObject", menuName = "Scriptable Object Ability/Create Ability SO")]
public abstract class AbilityScriptableObject : ScriptableObject  //This is a base class  // ---Changed public class to Abstract for this script to get Initialize and Use
{
    [Header("Basic Info")]
    public string skillName;
    public string Description;
    public Sprite abilitySprite;

    [Header("Canvas Info (DONT TOUCH)")]
    //public Sprite abilitySprite;                    // is already on canvas
    //public Image abilityImage;                   // is already on canvas
    public float currentAbilityCooldown;          // needed also for canvas
    public bool isAbilityCooldown = false;       // needed also for canvas


    [Header("Ability Usage  (Can be adjusted) + Canvas Info")]
    public float abilityCooldown;                    // needed also for canvas
    public KeyCode abilityKey;                      // needed also for canvas




    //public Sprite skillSprite;
    public abstract void Initialize(GameObject obj); //this will initialize the skill to the game object                // ---Changed public class to Abstract for this script to get Initialize and Use
    public abstract void Use();       //this will call the function when we wanna use the skill           // ---Changed public class to Abstract for this script to get Initialize and Use


}

//// Below was discarded for more simple use                                // ---Changed public class to Abstract for this script to get Initialize and Use
//public AbilityBehaviourScriptableObject abilityBehaviourSO;
//public AbilityEffectScriptableObject abilityEffectSO;

//Creates AbilityType list  (you can add different ready made SO AbilityTypes to the SO if you want to) 
//public List<AbilityType> AbilityTypes = new List<AbilityType>();

//Creates AbilityEffect list  (you can add different ready made SO AbilityEffects to the SO if you want to) 
//public List<AbilityEffectScriptableObject> AbilityEffects = new List<AbilityEffectScriptableObject>();

//Creates AbilityBehaviour list  (you can add different ready made SO AbilityBehaviours to the SO if you want to) 
//public List<AbilityBehaviourScriptableObject> AbilityBehaviours = new List<AbilityBehaviourScriptableObject>();