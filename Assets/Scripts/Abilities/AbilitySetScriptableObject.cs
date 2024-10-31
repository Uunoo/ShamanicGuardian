using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AbilitySetScriptableObject", menuName = "Scriptable Object Ability/Create Ability Set SO", order = 0)]
public class AbilitySetScriptableObject : ScriptableObject
{
    public string Description;


    //Creates Ability list  (you can add different ready made SO Abilities to the SO AbilitySet) 
    public List<AbilityScriptableObject> Abilities = new List<AbilityScriptableObject>();
}
