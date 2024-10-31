using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

// https://www.youtube.com/watch?v=4Y05Gbq7GG8&list=PLRRnET3ZAhEzXYJq7I4_RzzHGSBbWlE4D&index=2
// Basic continuous wave spawner.. gets harde and harder by the wave.. can add UI text for waves

public class EnemyWaveSpawner : MonoBehaviour
{

    public EnemySpawnerSO enemySpawnerSO;   //for info from SO  

    public Transform enemySpawnPoint1;
    //public Transform enemySpawnPoint2; // Can add more Spawnpoints for different enemies
    //public Transform enemySpawnPoint3; // Can add more Spawnpoints for different enemies

    //public BoxCollider2D enemyWaveTrigger;

    public UnityEvent battleEvent; // testing for battle event
    public List <GameObject> spawnList = new List<GameObject>();

    //------------Variables for basic Infinite enemy spawner  (waveSpawnerInfinite)----------------------

    //public float spawnRate = 1.0f;
    //public float timeBetweenWaves = 3.0f;

    //public int enemyCount;

    //bool waveIsDone = true;

    //public GameObject enemy1;



    void Start()
    {
        
    }


    void Update()
    {
        //spawnList.Add(Instantiate(enemySpawnerSO.enemy1));

        //// Below was for (waveSpawnerInfinite)-
        //if (waveIsDone == true)        // (these are an anti-bug measure 1/3)(waveSpawnerInfinite)
        //{
        //    StartCoroutine(waveSpawnerInfinite());  
        //}


    }

    ////For some fucked up reason i couldnt get this to work so i made it on Spawn Trigger
    //public void OnTriggerEnter2D(Collider2D collision)
    //{
    //    bool waveTriggered = enemySpawnerSO.enemyWaveTriggered;
    //    waveTriggered = false;
    //    //eWD = enemyWaveTrigger;

    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Debug.Log("Player Hit" +collision);
    //        StartCoroutine(enemyWaveSpawner());
    //        waveTriggered = true;
    //        //Collision Spawned ---- EVENT hide GameObject

    //    }

    //}


    public IEnumerator enemyWaveSpawner()       ///test for basic wave spawner with SO
    {
      
        // below we get the information for different variables from SO and address them here so the SO information wont be changed
        int eWC = enemySpawnerSO.enemyWaveCount;

        enemySpawnerSO.waveIsDone = true;

        //// Commented below since they are not needed ffor now ( these are to make the waves harder and harder by different waves) 1/2
        //enemySpawnerSO.spawnRate = spawnRate;
        //enemySpawnerSO.enemyCount = enemyCount;


        while (eWC >= 1)
        {
            Debug.Log("Enemy wave count left:" + eWC);
            Debug.Log("Enemy wave is done:" + enemySpawnerSO.waveIsDone);
            enemySpawnerSO.waveIsDone = false;     // (these are an anti-bug measure 2/3)

            for (int eC = 0; eC < enemySpawnerSO.enemyCount; eC++)    // This Spawn one Wave  //eC enemyCount
            {
                GameObject enemyClone1 = Instantiate(enemySpawnerSO.enemy1, enemySpawnPoint1);   //Object to spawn

                //// Line Below is for another spawnpoint and another enemy
                //GameObject enemyClone2 = Instantiate(enemySpawnerSO.enemy2, enemySpawnPoint2);
                //GameObject enemyClone3 = Instantiate(enemySpawnerSO.enemy3, enemySpawnPoint3);
                yield return new WaitForSeconds(enemySpawnerSO.spawnRate);    //There is a dealy betweeen spawning

                Debug.Log("Enemy wave is done:" + enemySpawnerSO.waveIsDone);
            }

            //// Commented below since they are not needed ffor now ( these are to make the waves harder and harder by different waves) 2/2
            //spawnRate += 1f;      // This makes the waves harder and faster with +=1f
            //enemyCount += 3;      // This adds more enemies to waves for making the waves harder and harder

            yield return new WaitForSeconds(enemySpawnerSO.timeBetweenWaves);  //Delay between waves

            eWC--;
            enemySpawnerSO.waveIsDone = true;
            Debug.Log("Enemy wave count left:" + eWC);
            Debug.Log("Enemy wave is done:" + enemySpawnerSO.waveIsDone);
        }


    }






    //IEnumerator waveSpawnerInfinite()       ///test for Wave Spawner  ( THIS IS AN INFINITE SPAWNER THAT GETS HARDER AND HARDER)
    //{

    //    waveIsDone = false;     // (these are an anti-bug measure 2/3)

    //    for (int i = 0; i < enemyCount; i++)    // This Spawn one Wave
    //    {
    //        GameObject enemyClone1 = Instantiate(enemy1);   //Object to spawn

    //        yield return new WaitForSeconds(spawnRate);    //There is a dealy betweeen spawning


    //    }

    //    spawnRate -= 1f;      // These are to make the waves harder and harder
    //    enemyCount += 3;      // These are to make the waves harder and harder


    //    yield return new WaitForSeconds(timeBetweenWaves);  //Delay between waves

    //    waveIsDone = true;  // (these are an anti-bug measure 3/3)

    //}

}








//// Below some shitty testing etc from other scripts etc dont mind these lol--------

//using System;               //needed for EventHandler
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyWaveTrigger : MonoBehaviour
//{

//    public event EventHandler OnPlayerEnterTrigger;




//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        PlayerController player = Collider2D.GetComponent<PlayerController>();
//        if (player != null)
//        {
//            //Player inside trigger area!
//            Debug.Log("Player inside trigger!");
//            OnPlayerEnterTrigger?.Invoke(this, EventArgs.Empty);
//        }



//    }

//}
//public class BattleSystem : MonoBehaviour
//{
//    [SerializeField] private Transform enemyTransform;

//    // Start is called before the first frame update
//    void Start()
//    {
//        StartBattle();
//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }

//    private void StartBattle()
//    {
//        Debug.Log("Start Battle!");
//        enemyTransform.GetComponent<EnemyWaveSpawner>().spawn();
//    }

//}
