using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

//1  https://www.youtube.com/watch?v=7Yv-3DevlDQ
//2  https://www.youtube.com/watch?v=nkes83f6YW0
//3  https://www.youtube.com/watch?v=ItOYpI9ak4E&list=PLuKMRhgr5rGkgABx8Sezws-ekSWIWRf4Q&index=3

//AbilitySystem Canvas has to be connected to Ability manager/Controller/PlayerData
//and therefore Ability SO:s / Ability Sets  and their projectiles

//ScriptableObjects can reference Prefab GameObjects

public class AbilitySystemCanvas : MonoBehaviour
{
    [Header("Spawn location for Projectile")]
    public GameObject spawnLocation;


    [Header("Ability SO")]
    //public AbilitySetScriptableObject abilitySetSO;                                                                           //These two are not needed for now
    //public List<AbilityScriptableObject> AbilityTypes = new List<AbilityScriptableObject>();
    public List<AbilityScriptableObject> abilities;

    [SerializeField]private int abilityIndex = 0;


    public AbilityScriptableObject ability1;
    public AbilityScriptableObject ability2;
    public AbilityScriptableObject ability3;
    public AbilityScriptableObject ability4;
    public AbilityScriptableObject ability5;

    [Header("Ability 1")]
    public Image abilityImage1;
    public Text abilityText1;
    ////----------------------------  Variables below are taken from AbilityScriptableObejct ability
    //public float abilityCooldown1 = 3f;
    //private bool isAbilityCooldown1 = false;
    //private float currentAbilityCooldown1;
    //public KeyCode abilityKey1;

    ////------------------------------------- Variables for AOE skills
    //Ability 1 Input variables
    //Vector3 position;
    //public Canvas abilityCanvas;
    //public Image skillshot;
    //public Transform player;


    [Header("Ability 2")]
    public Image abilityImage2;
    public Text abilityText2;
    ////----------------------------  Variables below are taken from AbilityScriptableObejct ability
    //public float abilityCooldown2 = 3f;
    //private bool isAbilityCooldown2 = false;
    //private float currentAbilityCooldown2;
    //public KeyCode abilityKey2;

    ////------------------------------------- Variables for AOE skills
    //Ability 2 Input Variables
    //public Image targetCircle;
    //public Image indicatorRangeCircle;
    //public Canvas avility2Canvas;
    //private Vector3 posUp;
    //public float maxAbility2Ddistance;


    [Header("Ability 3")]
    public Image abilityImage3;
    public Text abilityText3;
    ////----------------------------  Variables below are taken from AbilityScriptableObejct ability
    //public float abilityCooldown3 = 3f;
    //private bool isAbilityCooldown3 = false;
    //private float currentAbilityCooldown3;
    //public KeyCode abilityKey3;

    [Header("Ability 4")]
    public Image abilityImage4;
    public Text abilityText4;
    ////----------------------------  Variables below are taken from AbilityScriptableObejct ability
    //public float abilityCooldown4 = 3f;
    //private bool isAbilityCooldown4 = false;
    //private float currentAbilityCooldown4;
    //public KeyCode abilityKey4;

    [Header("Ability 5")]
    public Image abilityImage5;
    public Text abilityText5;
    ////----------------------------  Variables below are taken from AbilityScriptableObejct ability
    //public float abilityCooldown5 = 10f;
    //private bool isAbilityCooldown5 = false;
    //private float currentAbilityCooldown5;
    //public KeyCode abilityKey5;

    public void Awake()
    {

    }
    void Start()
    {
        foreach (AbilityScriptableObject ability in abilities)
        {
            ability.Initialize(spawnLocation);
        }

        ability1.Initialize(spawnLocation);             //Initializez Projectile Spawn location
        ability2.Initialize(spawnLocation);             //Initializez Projectile Spawn location
        ability3.Initialize(spawnLocation);             //Initializez Projectile Spawn location
        ability4.Initialize(spawnLocation);             //Initializez Projectile Spawn location

        //below will be made heal so propably can be discarded or changed?
        ability5.Initialize(spawnLocation);             //Initializez Projectile Spawn location


        abilityImage1.fillAmount = 0;                   // used for Image fill in UI
        abilityImage2.fillAmount = 0;
        abilityImage3.fillAmount = 0;
        abilityImage4.fillAmount = 0;
        abilityImage5.fillAmount = 0;

        abilityText1.text = "";                                 //used for UI ability text ( number )
        abilityText2.text = "";
        abilityText3.text = "";
        abilityText4.text = "";
        abilityText5.text = "";

    }


    void Update()
    {
        if (!SceneController.GameIsPaused)
        {
            AbilitiesShoot();



            //AbilityInput1();
            //AbilityInput2();
            //AbilityInput3();
            //AbilityInput4();
            //AbilityInput5();

            AbilityCooldown(ref ability1.currentAbilityCooldown, ability1.abilityCooldown, ref ability1.isAbilityCooldown, abilityImage1, abilityText1);
            AbilityCooldown(ref ability2.currentAbilityCooldown, ability2.abilityCooldown, ref ability2.isAbilityCooldown, abilityImage2, abilityText2);
            AbilityCooldown(ref ability3.currentAbilityCooldown, ability3.abilityCooldown, ref ability3.isAbilityCooldown, abilityImage3, abilityText3);
            AbilityCooldown(ref ability4.currentAbilityCooldown, ability4.abilityCooldown, ref ability4.isAbilityCooldown, abilityImage4, abilityText4);
            AbilityCooldown(ref ability5.currentAbilityCooldown, ability5.abilityCooldown, ref ability5.isAbilityCooldown, abilityImage5, abilityText5);

        }
    }

   
    public void AbilityInput1()
    {
        if (Input.GetKeyDown(ability1.abilityKey) && !ability1.isAbilityCooldown)
        {
            ability1.isAbilityCooldown = true;
            ability1.currentAbilityCooldown = ability1.abilityCooldown;
            ability1.Use();
        }
    }
    private void AbilityInput2()
    {
        if (Input.GetKeyDown(ability2.abilityKey) && !ability2.isAbilityCooldown)
        {
            ability2.isAbilityCooldown = true;
            ability2.currentAbilityCooldown = ability2.abilityCooldown;
            ability2.Use();
        }
    }
    private void AbilityInput3()
    {
        if (Input.GetKeyDown(ability3.abilityKey) && !ability3.isAbilityCooldown)
        {
            ability3.isAbilityCooldown = true;
            ability3.currentAbilityCooldown = ability3.abilityCooldown;
            ability3.Use();
        }
    }
    private void AbilityInput4()
    {
        if (Input.GetKeyDown(ability4.abilityKey) && !ability4.isAbilityCooldown)
        {
            ability4.isAbilityCooldown = true;
            ability4.currentAbilityCooldown = ability4.abilityCooldown;
            ability4.Use();
        }
    }
    private void AbilityInput5()
    {
        if (Input.GetKeyDown(ability5.abilityKey) && !ability5.isAbilityCooldown)
        {
            ability5.isAbilityCooldown = true;
            ability5.currentAbilityCooldown = ability5.abilityCooldown;
            ability5.Use();
        }
    }

   

    //-------------------------------Below usage for ability Cooldown and UI image fill
    private void AbilityCooldown(ref float currentCooldown, float maxCooldown, ref bool isCooldown, Image skillImage, Text skillText)
    {
        if (isCooldown)
        {
            currentCooldown -= Time.deltaTime;

            if (currentCooldown <= 0f)
            {
                isCooldown = false;
                currentCooldown = 0f;

                if (skillImage != null)
                {
                    skillImage.fillAmount = 0f;
                }
                if (skillText != null)
                {
                    skillText.text = "";
                }
            }
            else
            {
                if (skillImage != null)
                {
                    skillImage.fillAmount = currentCooldown / maxCooldown;
                }
                if (skillText != null)
                {
                    skillText.text = Mathf.Ceil(currentCooldown).ToString();
                }
            }
        }
    }

    private void AbilitiesShoot()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            abilityIndex--;
            if (abilityIndex < 0)
                abilityIndex = abilities.Count - 1;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            abilityIndex++;
            if (abilityIndex > abilities.Count - 1)
                abilityIndex = 0;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            abilities[abilityIndex].Use();

            //Debug.Log("Pressed left-click. AND SHOOT");
        }
        if (Input.GetKeyDown(ability1.abilityKey) && !ability1.isAbilityCooldown)
        { 
            ability1.isAbilityCooldown = true;
            ability1.currentAbilityCooldown = ability1.abilityCooldown;
            abilityIndex = 0;
        }
        if (Input.GetKeyDown(ability2.abilityKey) && !ability2.isAbilityCooldown)
        {
            ability2.isAbilityCooldown = true;
            ability2.currentAbilityCooldown = ability2.abilityCooldown;
            abilityIndex = 1;
        }
        if (Input.GetKeyDown(ability3.abilityKey) && !ability3.isAbilityCooldown)
        {
            ability3.isAbilityCooldown = true;
            ability3.currentAbilityCooldown = ability3.abilityCooldown;
            abilityIndex = 2;
        }
        if (Input.GetKeyDown(ability4.abilityKey) && !ability4.isAbilityCooldown)
        {
            ability4.isAbilityCooldown = true;
            ability4.currentAbilityCooldown = ability4.abilityCooldown;
            abilityIndex = 3;
        }
        if (Input.GetKeyDown(ability5.abilityKey) && !ability5.isAbilityCooldown)
        {
            ability5.isAbilityCooldown = true;
            ability5.currentAbilityCooldown = ability5.abilityCooldown;
            abilityIndex = 4;
        }
        ////if (Input.GetKeyDown(KeyCode.Alpha3))  THESE WERE LIKE THIS
        ////{
        ////    abilityIndex = 2;
        ////}
        ////if (Input.GetKeyDown(KeyCode.Alpha4))
        ////{
        ////    abilityIndex = 3;
        ////}
        ////if (Input.GetKeyDown(KeyCode.Alpha5))
        ////{
        ////    abilityIndex = 4;
        ////}
    }
    



}


// ---------------------------These were inside Update-----------------------------------------------------------------------------------------------
////-------------------Below was original usabe but added information from SO as above is seen
////
//AbilityCooldown(ref currentAbilityCooldown1, abilityCooldown1, ref isAbilityCooldown1, abilityImage1, abilityText1);
//AbilityCooldown(ref currentAbilityCooldown2, abilityCooldown2, ref isAbilityCooldown2, abilityImage2, abilityText2);
//AbilityCooldown(ref currentAbilityCooldown3, abilityCooldown3, ref isAbilityCooldown3, abilityImage3, abilityText3);
//AbilityCooldown(ref currentAbilityCooldown4, abilityCooldown4, ref isAbilityCooldown4, abilityImage4, abilityText4);
//AbilityCooldown(ref currentAbilityCooldown5, abilityCooldown5, ref isAbilityCooldown5, abilityImage5, abilityText5);

///-----------------------Below another way of using ability image fill with deltatime
////Ability1
//if (isAbilityCooldown1 == true)
//{
//    abilityImage1.fillAmount += 1 / abilityCooldown1 * Time.deltaTime;
//}

//if (abilityImage1.fillAmount == 1)
//{
//    isAbilityCooldown1 = false;
//}

////Ability2
//if (isAbilityCooldown2 == true)
//{
//    abilityImage2.fillAmount += 1 / abilityCooldown2 * Time.deltaTime;
//}

//if (abilityImage2.fillAmount == 1)
//{
//    isAbilityCooldown2 = false;
//}

////Ability3
//if (isAbilityCooldown3 == true)
//{
//    abilityImage3.fillAmount += 1 / abilityCooldown3 * Time.deltaTime;
//}

//if (abilityImage3.fillAmount == 1)
//{
//    isAbilityCooldown3 = false;
//}

////Ability4
//if (isAbilityCooldown4 == true)
//{
//    abilityImage4.fillAmount += 1 / abilityCooldown4 * Time.deltaTime;
//}

//if (abilityImage4.fillAmount == 1)
//{
//    isAbilityCooldown4 = false;
//}

////Ability5
//if (isAbilityCooldown5 == true)
//{
//    abilityImage5.fillAmount += 1 / abilityCooldown5 * Time.deltaTime;
//}

//if (abilityImage5.fillAmount == 1)
//{
//    isAbilityCooldown5 = false;
//}
////-------------------------------------------------------------------------------------------------------------------------------

//} // ---------------------------These were inside Update-----------------------------------------------------------------------------------------------

////-------------------------------------------Below the same as above ut without SO info---------------------
//public void Ability1()
//{

//    if (isAbilityCooldown1 == true)
//    {
//        Debug.Log("Cooldown1!");
//    }
//    else
//    {
//        Debug.Log("Ability1 Firing");
//        isAbilityCooldown1 = true;
//        abilityImage1.fillAmount = 0;
//    }
//}
//public void Ability2()
//{
//    if (isAbilityCooldown2 == true)
//    {
//        Debug.Log("Cooldown2!");
//    }
//    else
//    {
//        Debug.Log("Ability2 Firing");
//        isAbilityCooldown2 = true;
//        abilityImage2.fillAmount = 0;
//    }
//}
//public void Ability3()
//{
//    if (isAbilityCooldown3 == true)
//    {
//        Debug.Log("Cooldown3!");
//    }
//    else
//    {
//        Debug.Log("Ability3 Firing");
//        isAbilityCooldown3 = true;
//        abilityImage3.fillAmount = 0;
//    }
//}
//public void Ability4()
//{
//    if (isAbilityCooldown4 == true)
//    {
//        Debug.Log("Cooldown4!");
//    }
//    else
//    {
//        Debug.Log("Ability4 Firing");
//        isAbilityCooldown4 = true;
//        abilityImage4.fillAmount = 0;
//    }
//}
//public void Ability5()
//{
//    if (isAbilityCooldown5 == true)
//    {
//        Debug.Log("Cooldown5!");
//    }
//    else
//    {
//        Debug.Log("Ability5 Firing");
//        isAbilityCooldown5 = true;
//        abilityImage5.fillAmount = 0;
//    }
//}

//}      
////------------------------------------------Below usage of Ability Input system without SO---------------------------------------------------------------------
//    public void AbilityInput1()
//{
//    if (Input.GetKeyDown(abilityKey1) && ! isAbilityCooldown1)
//    {
//        isAbilityCooldown1 = true;
//        currentAbilityCooldown1 = abilityCooldown1;
//        ability1.Use();
//    }
//}
//private void AbilityInput2()
//{
//    if (Input.GetKeyDown(abilityKey2) && ! isAbilityCooldown2)
//    {
//        isAbilityCooldown2 = true;
//        currentAbilityCooldown2 = abilityCooldown2;
//    }
//}
//private void AbilityInput3()
//{
//    if (Input.GetKeyDown(abilityKey3) && ! isAbilityCooldown3)
//    {
//        isAbilityCooldown3 = true;
//        currentAbilityCooldown3 = abilityCooldown3;
//    }
//}
//private void AbilityInput4()
//{
//    if (Input.GetKeyDown(abilityKey4) && ! isAbilityCooldown4)
//    {
//        isAbilityCooldown4 = true;
//        currentAbilityCooldown4 = abilityCooldown4;
//    }
//}
//private void AbilityInput5()
//{
//    if (Input.GetKeyDown(abilityKey5) && ! isAbilityCooldown5)
//    {
//        isAbilityCooldown5 = true;
//        currentAbilityCooldown5 = abilityCooldown5;
//    }
//}
////------------------------------------------Above usage of Ability Input system without SO---------------------------------------------------------------------

//----------------------------------------------------------------------------------------------------------------------------------


////OTher way of doing things
///
/// 
///    //public void Ability1()
//{

//    if (ability1.isAbilityCooldown == true)
//    {
//        Debug.Log("Cooldown1!");
//    }
//    else
//    {
//        Debug.Log("Ability1 Firing");
//        ability1.isAbilityCooldown = true;
//        abilityImage1.fillAmount = 0;
//    }
//}
//public void Ability2()
//{
//    if (ability2.isAbilityCooldown == true)
//    {
//        Debug.Log("Cooldown2!");
//    }
//    else
//    {
//        Debug.Log("Ability2 Firing");
//        ability2.isAbilityCooldown = true;
//        abilityImage2.fillAmount = 0;
//    }
//}
//public void Ability3()
//{
//    if (ability3.isAbilityCooldown == true)
//    {
//        Debug.Log("Cooldown3!");
//    }
//    else
//    {
//        Debug.Log("Ability3 Firing");
//        ability3.isAbilityCooldown = true;
//        abilityImage3.fillAmount = 0;
//    }
//}
//public void Ability4()
//{
//    if (ability4.isAbilityCooldown == true)
//    {
//        Debug.Log("Cooldown4!");
//    }
//    else
//    {
//        Debug.Log("Ability4 Firing");
//        ability4.isAbilityCooldown = true;
//        abilityImage4.fillAmount = 0;
//    }
//}
//public void Ability5()
//{
//    if (ability5.isAbilityCooldown == true)
//    {
//        Debug.Log("Cooldown5!");
//    }
//    else
//    {
//        Debug.Log("Ability5 Firing");
//        ability5.isAbilityCooldown = true;
//        abilityImage5.fillAmount = 0;
//    }
//}