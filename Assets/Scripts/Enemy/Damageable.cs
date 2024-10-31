using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private int Health = 100;

    public void TakeDamage(int damage)
    {
        Health -= damage;

        Debug.Log(this.gameObject.name + "Damage taken:" + damage);

        if (Health <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Object Destroyed");
        }

        

    }
}
