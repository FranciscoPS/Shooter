using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;

    public GameObject[] enemyPrefabs; 
    public Transform[] spawnPoints;    
    public float spawnInterval = 5f;  

    private float nextSpawnTime;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else Destroy(this);
    }

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
       
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

       
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

       
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }


    public void DeactivateSpawner()
    {
        gameObject.SetActive(false);
    }
}
