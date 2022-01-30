using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefab;

    public bool spawnEnemy;

    private void Update()
    {
        if (spawnEnemy)
        {
            int randEnemy = Random.Range(0, enemyPrefab.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefab[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);

            spawnEnemy = false;
        }
    }
}
