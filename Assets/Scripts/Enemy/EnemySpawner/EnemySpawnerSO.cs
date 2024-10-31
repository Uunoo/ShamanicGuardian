using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnemySpawnScriptableObject", menuName = "Scriptable Object Enemy Spawn/Create Enemy Spawn SO", order = 0)]

public class EnemySpawnerSO : ScriptableObject
{
    public string Description;
    public float spawnRate;   // = 1.0f;
    public float timeBetweenWaves;   // = 3.0f;

    public int enemyCount;
    public int enemyWaveCount;
    public bool waveIsDone; /// = true;
    public bool enemyWaveTriggered = false;

    public GameObject enemy1;
    //public GameObject enemy2;  // You can add more enemies to Spawn from different spawn points
    //public GameObject enemy3;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
