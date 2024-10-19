using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject enemyPerfab;
    [SerializeField] private Transform[] spawnLocation;
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
        Instantiate(enemyPerfab, spawnLocation[randomIndex].position, Quaternion.identity);
        
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
