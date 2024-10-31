using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthSaveSO", menuName = "Scriptable Object Manager/Create Health Save SO")]
public class HealthSaveSO : ScriptableObject
{
    [SerializeField]
    private float healthNow;

    public float Health
    {
        get { return healthNow; }
        set { healthNow = value; }
    }
}
