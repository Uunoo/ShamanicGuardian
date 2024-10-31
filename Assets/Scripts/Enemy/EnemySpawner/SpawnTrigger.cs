using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public EnemyWaveSpawner waveSpawner;
    public BoxCollider2D boxCollider2D;

    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player entered trigger");
            StartCoroutine(waveSpawner.enemyWaveSpawner());

            boxCollider2D.enabled = false;
            Debug.Log("boxcollider dísabled"+ boxCollider2D.enabled);

            //boxCollider2D.isTrigger = false;
            //Debug.Log("Trigger off"+ boxCollider2D.isTrigger);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
