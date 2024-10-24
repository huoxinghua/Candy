using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPerfab;
    [SerializeField] private Transform[] spawnLocation;
    [SerializeField] private Transform targetLocation;
    [SerializeField] private float spawnInterval = 5f;
    private GameObject enemy;
    private AIEnemy enemyScript;
    private float timer = 0f;
    private bool isSpawned =false  ;

    private void SpawnEnemy()
    {
        if (spawnLocation.Length == 0)
        {
            Debug.LogError("No spawn locations available!");
            return;
        }
        int randomIndex = Random.Range(0, spawnLocation.Length);
        
        enemy = Instantiate(enemyPerfab, spawnLocation[randomIndex].position, Quaternion.identity);
        isSpawned = true;
        
    }
    private void EnemyMove()
    {
        enemyScript = enemy.GetComponent<AIEnemy>();

        if (enemyScript != null && targetLocation != null)
        {
            //enemyScript.NpcMove();
            enemyScript.SetTarget(targetLocation);
        }
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();  
            timer = 0f;
        }
        if (isSpawned)
        {
            EnemyMove();
        }
    }
}
