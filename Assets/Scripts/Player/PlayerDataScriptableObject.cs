using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PlayerDataScriptableObject", menuName = "Scriptable Object Player/Create Player Data SO")]
public class PlayerDataScriptableObject : ScriptableObject
{
    public string Descrition;

    [Header("Player Stats")]

    public string PlayerName;

    public int PlayerHP; // baseline = 100,    +10 for each level
                               // 
    public int maxHP;

    [System.NonSerialized] public UnityEvent<int> playerHealthChangeEvent;

    // public int PlayerMana = 100;
    // public int PlayerXP = 0;
    // public int PlayerLevel = 1;


    private void OnEnable()
    {
        PlayerHP = maxHP;
        if (playerHealthChangeEvent == null)
        {
            playerHealthChangeEvent = new UnityEvent<int>();
        }
    }

    public void DecreaseHealth(int amount)
    {
        PlayerHP -= amount;
        playerHealthChangeEvent.Invoke(PlayerHP);
        Debug.Log("Player took damage: "+ amount);
    }

    public void IncreaseHealth(int amount)
    {
        PlayerHP += amount;
        playerHealthChangeEvent.Invoke(PlayerHP);
        //if (PlayerHP <= maxHP)
        //{
        //    PlayerHP += amount;
        //    playerHealthChangeEvent.Invoke(PlayerHP);
        //    Debug.Log("Player Healed: " + amount);
        //}
        //if (PlayerHP > maxHP)
        //{
        //    PlayerHP = maxHP; 
        //}
    }
}
