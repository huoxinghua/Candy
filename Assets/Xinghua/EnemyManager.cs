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
    private float timer = 0f;

    private void SpawnEnemy()
    {
        if (spawnLocation.Length == 0)
        {
            Debug.LogError("No spawn locations available!");
            return;
        }
        int randomIndex = Random.Range(0, spawnLocation.Length);
        
        var enemy = Instantiate(enemyPerfab, spawnLocation[randomIndex].position, Quaternion.identity);
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        if (enemyScript != null && targetLocation != null)
        {
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
    }
}
