using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private GameObject enemyPerfab;
    private GameObject enemy;
    [SerializeField] private Transform[] spawnLocation;
    private float spawnRadius;
    [SerializeField] private GameObject targetLocation;
    [SerializeField] private float spawnInterval = 5f;
    private AIEnemy enemyScript;


    
    private float timer = 0f;
    private bool isSpawned = false;
    private bool isNeedSpawning = true;
    [SerializeField] private Renderer childRenderer;
    private void SpawnEnemy()
    {
        if (isNeedSpawning)
        {
            //if (spawnLocation.Length == 0)
            //{
            //    Debug.LogError("No spawn locations available!");
            //    return;
            //}
            int randomIndex = Random.Range(0, spawnLocation.Length);
            Vector3 randomOffset = new Vector3(
            Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius) );

            enemy = Instantiate(enemyPerfab, spawnLocation[randomIndex].position + randomOffset, Quaternion.identity);
            enemyScript = enemy.AddComponent<AIEnemy>();    
            isSpawned = true;
        }
        
    }
    public void StopSpawnEnemy()
    {
        isNeedSpawning = false;
    }
    private void EnemyMove()
    {
        //Debug.Log("enemyScript"+ enemyScript);
        //Debug.Log("targetLocation" + targetLocation);
        if (targetLocation != null)
        {

            enemyScript.SetTarget(targetLocation);
           // Debug.Log("targetLocation" + targetLocation);
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
        else if (enemyScript !=null)
        {
            EnemyMove();
        }
       
            
    }
    public void Interact()
    {

    }
}
