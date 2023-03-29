using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRangeX = 30;
    private float spawnPosZ = -12;
    private float startDelay = 2;
    private float spawnInterval = 5;
    private int enemycounter;
    float timeRemaining = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating ("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        enemycounter = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemycounter < 10)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }else if(timeRemaining < 0)
            {
                SpawnRandomEnemy();
                timeRemaining = spawnInterval;
            }
        }
    }
    void SpawnRandomEnemy() 
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnpos = new Vector3(Random.Range (-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Vector3 spawnposZ = new Vector3(-22, 0, Random.Range(-4,12));
        //randomly generate enemy index and spawn position//
        Instantiate(enemyPrefabs[enemyIndex], spawnpos, enemyPrefabs[enemyIndex].transform.rotation);
        Instantiate(enemyPrefabs[enemyIndex], spawnposZ, enemyPrefabs[enemyIndex].transform.rotation);
    }

        
}

