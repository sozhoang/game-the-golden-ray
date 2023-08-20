using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemy;
    public float startTimeBtwSpawns;
    public int numEnemyPerSpawns;
    public float radius;

    public Database data;
    float timeBtwSpawns;

    private void Start()
    {
        startTimeBtwSpawns = data.spawner.TimebtwSpawns;
        numEnemyPerSpawns = data.spawner.numEnemiesPerSpawns;
        radius = data.spawner.radius;

    }

    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            Vector3 spawnPosition = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            for(int i = 0; i<numEnemyPerSpawns; i++)
                Instantiate(enemy, spawnPosition + new Vector3(Random.Range(-radius, radius), Random.Range(-radius, radius), 0), Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }

    }

}
