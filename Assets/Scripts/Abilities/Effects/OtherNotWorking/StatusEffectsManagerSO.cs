using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Ability Status Effect")]
public class StatusEffectsManagerSO : ScriptableObject
{
    public string EffectName;
    public int DOTAmount;
    public float TickSpeed;
    public float MovementPenalty;
    public float Lifetime;

    public GameObject EffectParticles;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
