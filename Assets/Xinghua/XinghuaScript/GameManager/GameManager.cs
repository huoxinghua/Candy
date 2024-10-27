using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("door")]
    public float pushThreshold = 10;
    public float currentPushThreshold;
    public float doorDamageAmount;
    public float doorIncreaseAmount;

    [Header("candy devourer")]
    public float bossCurrentDurability;
    public float maxBossDurability = 100f;
    public float candyEatMaxAmount;
    public float candyEatAlready;
    public float candyEnergy =2f;
    [Header("candy spawn")]
    [SerializeField] private GameObject candyPerfab;
    [SerializeField] private GameObject candySpawnLocation;
    [SerializeField]private float spawnRadius;
    [Header("CookMachine devourer")]
    public float currentCookDurability;
    public float maxCookDurability = 2f;

    public bool isGameBegining=false;

    [Header("candy value")]
    private float candy;
    private void Start()
    {
      //  doorDamageAmount = 2f;
        candyEatAlready = 0;
        bossCurrentDurability = maxBossDurability;
        isGameBegining = true;
}
    private void Update()
    {
        if (UIManager.Instance.timeRemaining <= 0f && bossCurrentDurability <= 0)
        {
            GameOver();
        }
        //boss servive
        else if((UIManager.Instance.timeRemaining <= 0f && bossCurrentDurability > 0))
        {
            WinGame();
        }
    }
    public void GameOver()
    {

        Debug.Log("Game over");
        Time.timeScale = 0f;
        UIManager.Instance.timeRemaining = 0;
    }
    public void WinGame()
    {
        //if boss survive in certain amount of time player will win
        Debug.Log("you win");
        // all the enemy and changed people will back to normal

        //stop spaw enemy 
        EnemyManager.Instance.StopSpawnEnemy();
        //show win menu
        Time.timeScale = 0f;
    }
    public void SpawnCandy()
    {
        // Generate a random offset
        Vector3 randomOffset = new Vector3(
            Random.Range(-spawnRadius, spawnRadius), 0, Random.Range(-spawnRadius, spawnRadius) );

        // Calculate the spawn position
        Vector3 spawnPosition = candySpawnLocation.transform.position + randomOffset;

        // Instantiate the candy
        Instantiate(candyPerfab, spawnPosition, Quaternion.identity);
    }
    
}
