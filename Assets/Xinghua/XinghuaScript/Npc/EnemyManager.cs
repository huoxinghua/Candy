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
    [SerializeField] public GameObject[] targetLocation;
    [SerializeField] private float spawnInterval = 5f;
    public AIEnemy enemyScript;


    
    private float timer = 0f;
    private bool isSpawned = false;
    private bool isNeedSpawning = true;
    [SerializeField] private Renderer childRenderer;
    private void Start()
    {
       
    }
    private void SpawnEnemy()
    {
        if (isNeedSpawning)
        {
            if (spawnLocation.Length == 0)
            {
                Debug.LogError("No spawn locations available!");
                return;
            }
            int randomIndex = Random.Range(0, spawnLocation.Length);
            Vector3 randomOffset = new Vector3(
            Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius) );

            enemy = Instantiate(enemyPerfab, spawnLocation[randomIndex].position + randomOffset, Quaternion.identity);
            enemyScript = enemy.GetComponent<AIEnemy>();    
            isSpawned = true;
        }
        
    }
    public void StopSpawnEnemy()
    {
        isNeedSpawning = false;
    }
    public void EnemyMove()
    {
        Debug.Log("0"+ targetLocation[0]);
        CookMachine cookMachine = gameObject.GetComponent<CookMachine>();

    
        for (int i = 0; i < targetLocation.Length; i++)
        {
            if (targetLocation[i] == null)
            {
                continue;
            }
            enemyScript.EnemyMove(targetLocation[i]);
           
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
