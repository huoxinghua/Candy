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
    [SerializeField] public GameObject cookMachine1;
    [SerializeField] public GameObject cookMachine2;
    [SerializeField] public GameObject boss;

    public List<GameObject> cookMachines;
    public int currentTargetIndex = 0;
    [SerializeField] private float spawnInterval = 5f;
    public AIEnemy enemyScript;


    
    private float timer = 0f;
    private bool isSpawned = false;
    private bool isNeedSpawning = true;
    [SerializeField] private Renderer childRenderer;
    private void Start()
    {
        cookMachines = new List<GameObject>();
        cookMachines.Add(cookMachine1);
        cookMachines.Add(cookMachine2);
        cookMachines.Add(boss);
        //CookMachine cookMachine = gameObject.GetComponent<CookMachine>();
        CookMachine.onCookMachineAllDestroyed += AllCookMachineDestroyed;
        CookMachine.onCookMachineDestroyed += OnCookMachineDestroyed;
        
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
    private void OnCookMachineDestroyed(CookMachine destroyedCookMachine)
    {
        //Debug.Log("enemyManager OnCookmachine destroyed");
        if (cookMachines[currentTargetIndex] !=null && cookMachines[currentTargetIndex]== destroyedCookMachine)
        {
            SetNextTargrt();
           // Debug.Log("enemyManager OnCookmachine destroyed set next target");
        }
    }

    private void OnDestroy()
    {
        CookMachine.onCookMachineDestroyed -= OnCookMachineDestroyed;
    }

    public void AllCookMachineDestroyed()
    {
        if (!enemyScript)
        {
            enemyScript.EnemyMove(EnemyManager.Instance.boss);
        }
    }

    public void StopSpawnEnemy()
    {
        isNeedSpawning = false;
    }
 
    public void SetNextTargrt()
    {

        while (currentTargetIndex < cookMachines.Count && cookMachines[currentTargetIndex].IsDestroyed())
        {
            currentTargetIndex++;
        }
        
        //Debug.Log("enemyScript" +enemyScript);
        if (enemyScript != null)
        {
            enemyScript.EnemyMove(cookMachines[currentTargetIndex]);
        }
        
        //Debug.Log(cookMachines[currentTargetIndex]);
    }


    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();  
            timer = 0f;
        }
        else if (enemyScript !=null)
        {
       
            SetNextTargrt();
        }       
    }
    public void Interact()
    {

    }
}
