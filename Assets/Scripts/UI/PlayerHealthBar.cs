using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
  
    [SerializeField] private PlayerDataScriptableObject playerDataScriptableObject;
    [SerializeField] private Slider healthBar;

    void Start()
    {
        ChangeSliderValue(playerDataScriptableObject.maxHP);
    }

    private void OnEnable()
    {
        playerDataScriptableObject.playerHealthChangeEvent.AddListener(ChangeSliderValue);
    }

    private void OnDisable()
    {
        playerDataScriptableObject.playerHealthChangeEvent.RemoveListener(ChangeSliderValue);
    }

    public void ChangeSliderValue(int amount)
    {
        healthBar.value = ConvertIntToFloatDecimal(amount);
    }

    private float ConvertIntToFloatDecimal(int amount)
    {
        return (float)amount / playerDataScriptableObject.maxHP;
    } 
}
